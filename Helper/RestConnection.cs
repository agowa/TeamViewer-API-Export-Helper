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

using System.IO;
using System.Net;
using System.Text;
using $safeprojectname$.DataType;

namespace $safeprojectname$.Helper
{
	internal class RestConnection
	{
		private readonly RestProperties rp;

		internal RestConnection(RestProperties restProperties)
		{
			rp = restProperties;
		}

		internal string SendToApi()
		{
			var webRequest = (HttpWebRequest)WebRequest.Create(rp.Url);
			webRequest.ContentType = rp.ContentType;
			webRequest.Method = rp.Method;
			if (!string.IsNullOrEmpty(rp.AccessToken))
			{
				webRequest.Headers.Add("Authorization", "Bearer " + rp.AccessToken);
			}

			if (webRequest.Method == WebRequestMethods.Http.Post)
			{
				if (!string.IsNullOrEmpty(rp.PostData))
				{
					var postBytes = Encoding.UTF8.GetBytes(rp.PostData);
					webRequest.ContentLength = postBytes.Length;

					using (var dataStream = webRequest.GetRequestStream())
					{
						dataStream.Write(postBytes, 0, postBytes.Length);
					}
				}
			}

			try
			{
				using (var httpResponse = (HttpWebResponse)webRequest.GetResponse())
				{
					using (var responseStream = httpResponse.GetResponseStream())
					{
						if (responseStream != null)
						{
							using (var streamReader = new StreamReader(responseStream))
							{
								return streamReader.ReadToEnd();
							}
						}
					}
				}
			}
			catch (WebException error)
			{
				ApiErrorMessage.PrintError(error);
			}

			return string.Empty;
		}
	}
}