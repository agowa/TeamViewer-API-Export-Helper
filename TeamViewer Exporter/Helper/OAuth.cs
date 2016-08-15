/*
 * Copyright (c) 2014 TeamViewer GmbH
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 *
 * The above copyright notice and this permission notice shall be included in
 * all copies or substantial portions of the Software.
 *
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
 * THE SOFTWARE.
 *
 * When reusing or redistributing the software please respect any licenses of
 * included software from third parties, if applicable.
 */

using System;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using TeamViewer_Exporter.CustomException;
using TeamViewer_Exporter.DataType;
using TeamViewer_Exporter.Ressources;
using TeamViewer_Exporter.Views;
using Newtonsoft.Json;

namespace TeamViewer_Exporter.Helper
{
    internal delegate void OauthProcessCompleteHandler();

    internal class OAuth
    {
        #region internal fields

        // TODO: Insert your client id here:
        internal const string ClientId = "";

        // TODO: Insert your client secret here:
        internal const string ClientSecret = "";

        // TODO: Insert your redirect uri here:
        internal const string RedirectUri = "";

        #endregion internal fields

        #region private fields

        private static OAuth s_currentinstance;
        private readonly byte[] _additionalEntropy = Encoding.ASCII.GetBytes("Just a sample");

        #endregion private fields

        #region constructors
        #endregion constructors

        #region events

        internal event OauthProcessCompleteHandler OauthProcessComplete;

        #endregion events

        #region properties

        internal static OAuth CurrentCurrentinstance
        {
            get
            {
                if (s_currentinstance == null)
                {
                    s_currentinstance = new OAuth();
                }
                return s_currentinstance;
            }
        }

        internal Token Tokens { get; private set; }

        internal bool TokensAvailable
        {
            get
            {
                return (Tokens != null && !string.IsNullOrEmpty(Tokens.AccessToken) &&
                        !string.IsNullOrEmpty(Tokens.RefreshToken));
            }
        }

        #endregion properties

        #region internal methods

        internal static string ValidateToken(TokenType tokenType, string accessToken)
        {
            if (tokenType == TokenType.SkriptToken && !string.IsNullOrEmpty(accessToken))
            {
                return accessToken;
            }
            if (tokenType == TokenType.AppToken && CurrentCurrentinstance.TokensAvailable)
            {
                if (CurrentCurrentinstance.AccessTokenIsExpired())
                {
                    CurrentCurrentinstance.RefreshAccesToken();
                }
                return CurrentCurrentinstance.Tokens.AccessToken;
            }
            throw new AuthorizationException(Resources.Error_AccessTokenRequired);
        }

        /// <summary>
        ///     Pings the API to validate the access tokens
        /// </summary>
        /// <returns></returns>
        internal bool AccessTokenIsExpired()
        {
            var rp = new RestProperties
            {
                Url = TvApiUrls.UrlPing,
                Method = WebRequestMethods.Http.Get,
                AccessToken = Tokens.AccessToken
            };

            string jsonResultString = new RestConnection(rp).SendToApi();
            if (string.Empty != jsonResultString)
            {
                var pingResult = new { token_valid = false };
                pingResult = JsonConvert.DeserializeAnonymousType(jsonResultString, pingResult);
                return !pingResult.token_valid;
            }

            return true;
        }

        /// <summary>
        ///     Sets the url and the postdata to get a new access tokens from the api
        /// </summary>
        /// <param name="code">Authorisierungcode zur Erstellung des neuen tokens</param>
        internal void GetNewAccessToken(string code)
        {
            if (code == string.Empty) return;

            var postData = new StringBuilder();
            postData.Append("grant_type=authorization_code");
            postData.Append("&code=" + code);
            postData.Append("&redirect_uri=" + RedirectUri);
            postData.Append("&client_id=" + ClientId);
            postData.Append("&client_secret=" + ClientSecret);

            RetrieveAndSetTokensFromApi(postData.ToString());
        }

        /// <summary>
        ///     Sets the url and the postdata to get a new access tokens from the api after the old one is expired
        /// </summary>
        internal void RefreshAccesToken()
        {
            if (Tokens.RefreshToken == string.Empty) return;

            var postData = new StringBuilder();
            postData.Append("grant_type=refresh_token");
            postData.Append("&refresh_token=" + Tokens.RefreshToken);
            postData.Append("&client_id=" + ClientId);
            postData.Append("&client_secret=" + ClientSecret);

            RetrieveAndSetTokensFromApi(postData.ToString());
        }

        /// <summary>
        ///     Calling the API for the new tokens and save them
        /// </summary>
        /// <param name="postData"></param>
        internal void RetrieveAndSetTokensFromApi(string postData)
        {
            var restProperties = new RestProperties
            {
                Url = TvApiUrls.UrlToken,
                Method = WebRequestMethods.Http.Post,
                ContentType = HttpContentTypes.ApplicationXWwwFormUrlEncoded,
                PostData = postData
            };

            string jsonResultString = new RestConnection(restProperties).SendToApi();
            if (string.Empty != jsonResultString)
            {
                Tokens = JsonConvert.DeserializeObject<Token>(jsonResultString);
                // Check if someone is listening to the OauthProcessComplete-Event
                if (OauthProcessComplete != null)
                {
                    // Event to inform the main thread that the OAuth-Process is complete and that he can use the new tokens to create a new session via the API
                    OauthProcessComplete();
                }
            }
        }
        #endregion internal methods
    }
}