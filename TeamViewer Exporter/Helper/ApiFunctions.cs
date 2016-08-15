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

using System.Net;
using TeamViewer_Exporter.DataType;
using TeamViewer_Exporter.Ressources;
using Newtonsoft.Json;

namespace TeamViewer_Exporter.Helper
{
    internal class ApiFunctions
    {
        internal static void QuarryDevices(TokenType tokenType, string accessToken, ref QuarryInformation instantSupportInfo)
        {
            var restProperties = new RestProperties
            {
                Url = TvApiUrls.UrlDevices,
                Method = WebRequestMethods.Http.Get,
                PostData = JsonConvert.SerializeObject(instantSupportInfo),
                AccessToken = OAuth.ValidateToken(tokenType, accessToken)
            };
            CreateApiQuarry(tokenType, accessToken, ref instantSupportInfo, restProperties);
        }

        internal static void QuarryAccount(TokenType tokenType, string accessToken, ref QuarryInformation instantSupportInfo)
        {
            var restProperties = new RestProperties
            {
                Url = TvApiUrls.UrlAccount,
                Method = WebRequestMethods.Http.Get,
                PostData = JsonConvert.SerializeObject(instantSupportInfo),
                AccessToken = OAuth.ValidateToken(tokenType, accessToken)
            };
            CreateApiQuarry(tokenType, accessToken, ref instantSupportInfo, restProperties);
        }

        internal static void QuarryUsers(TokenType tokenType, string accessToken, ref QuarryInformation instantSupportInfo)
        {
            var restProperties = new RestProperties
            {
                Url = TvApiUrls.UrlUsers,
                Method = WebRequestMethods.Http.Get,
                PostData = JsonConvert.SerializeObject(instantSupportInfo),
                AccessToken = OAuth.ValidateToken(tokenType, accessToken)
            };
            CreateApiQuarry(tokenType, accessToken, ref instantSupportInfo, restProperties);
        }

        internal static void QuarryGroups(TokenType tokenType, string accessToken, ref QuarryInformation instantSupportInfo)
        {
            var restProperties = new RestProperties
            {
                Url = TvApiUrls.UrlGetGroupIds,
                Method = WebRequestMethods.Http.Get,
                PostData = JsonConvert.SerializeObject(instantSupportInfo),
                AccessToken = OAuth.ValidateToken(tokenType, accessToken)
            };
            CreateApiQuarry(tokenType, accessToken, ref instantSupportInfo, restProperties);
        }


        private static void CreateApiQuarry(TokenType tokenType, string accessToken, ref QuarryInformation quarryInformation, RestProperties restProperties)
        {


            // Create a new RestConnection with the completed RestProperties
            var rc = new RestConnection(restProperties);

            // Send data to the API and retrieve the JSON data
            var resultJsonString = rc.SendToApi();

            // Extract the session data from the JSON string
            if (string.Empty != resultJsonString)
            {
                quarryInformation = JsonConvert.DeserializeObject<QuarryInformation>(resultJsonString);
                quarryInformation.UnformatedJsonString = resultJsonString;

                dynamic parsedJson = JsonConvert.DeserializeObject(resultJsonString);
                quarryInformation.FormatedJsonString = JsonConvert.SerializeObject(parsedJson, Formatting.Indented);

            }
            else
            {
                quarryInformation = null;
            }
        }
    }
}
