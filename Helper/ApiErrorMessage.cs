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
using System.Windows.Forms;
using $safeprojectname$.DataType;
using Newtonsoft.Json;

namespace $safeprojectname$.Helper
{
	/// <summary>
	/// A derived of Exception for handling the API-Errors und Displaying them
	/// </summary>
	internal class ApiErrorMessage
	{
		/// <summary>
		/// Prints the error message
		/// </summary>
		/// <param name="message">Error message</param>
		internal static void PrintError(string message)
		{
			MessageBox.Show(message, @"API Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
		}

		/// <summary>
		/// Prints the error message plus its description
		/// </summary>
		/// <param name="message"></param>
		/// <param name="description"></param>
		internal static void PrintError(string message, string description)
		{
			var errorMessage = message;
			if (!string.IsNullOrEmpty(description))
			{
				var jsonError = JsonConvert.DeserializeObject<ErrorResponse>(description);
				errorMessage += string.Format(@"

JSON error response:
Error category:	{0}
Error description:	{1}
Error code:	{2}",
				  jsonError.Error,
				  jsonError.ErrorDescription,
				  jsonError.ErrorCode);

				if (!string.IsNullOrEmpty(jsonError.ErrorSignature))
				{
					errorMessage += string.Format("\nError signature:\t{0}\n", jsonError.ErrorSignature);
				}
			}

			MessageBox.Show(errorMessage, @"API Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
		}

		/// <summary>
		/// Tries to read the content of the WebException and calls the corresponding print-method
		/// </summary>
		/// <param name="webException"></param>
		internal static void PrintError(WebException webException)
		{
			var errorDescription = string.Empty;
			using (var stream = webException.Response.GetResponseStream())
			{
				if (stream != null)
				{
					using (var reader = new StreamReader(stream))
					{
						errorDescription = reader.ReadToEnd();
					}
				}
			}
			if (!string.IsNullOrEmpty(errorDescription))
			{
				PrintError(webException.Message, errorDescription);
			}
			else
			{
				PrintError(webException.Message);
			}
		}
	}
}