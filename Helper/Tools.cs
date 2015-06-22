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

using System.Windows.Forms;

namespace $safeprojectname$.Helper
{
	/// <summary>
	/// A static class for useful helper-functions which could be useful in multiple other classes
	/// </summary>
	internal static class Tools
	{
		internal const char Tab = '\t';

		/// <summary>
		/// Converts a String into a byte array
		/// </summary>
		/// <param name="str">String to convert</param>
		/// <returns></returns>
		internal static byte[] StringToByteArray(string str)
		{
			var enc = new System.Text.ASCIIEncoding();
			return enc.GetBytes(str);
		}

		/// <summary>
		/// Converts a byte array into a string
		/// </summary>
		/// <param name="arr"></param>
		/// <returns></returns>
		internal static string ByteArrayToString(byte[] arr)
		{
			var enc = new System.Text.ASCIIEncoding();
			return enc.GetString(arr);
		}

		/// <summary>
		/// Standard error message with MessageBoxButtons.OK and MessageBoxIcon.Error
		/// </summary>
		/// <param name="message">Error message</param>
		/// <param name="title">Error title (default: "Error")</param>
		internal static void StandardErrorMessage(string message, string title = "Error")
		{
			MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
		}
	}
}