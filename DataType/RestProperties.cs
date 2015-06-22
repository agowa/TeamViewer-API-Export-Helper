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
using $safeprojectname$.Ressources;

namespace $safeprojectname$.DataType
{
	/// <summary>
	/// Wrapper class for the parameters an API call requires
	/// </summary>
	internal class RestProperties
	{
		private string _method;
		private string _accessToken = string.Empty;

		internal string PostData { get; set; }

		internal string Url { get; set; }

		internal string ContentType { get; set; }

		internal string AccessToken
		{
			get { return _accessToken; }
			set { _accessToken = value; }
		}

		internal string Method
		{
			get { return _method; }
			set
			{
				if (value.Equals(WebRequestMethods.Http.Post) || value.Equals(WebRequestMethods.Http.Get))
				{
					_method = value;
				}
			}
		}

		internal RestProperties()
		{
			Url = String.Empty;
			_method = WebRequestMethods.Http.Post;
			PostData = String.Empty;
			ContentType = HttpContentTypes.ApplicationJson;
		}
	}
}