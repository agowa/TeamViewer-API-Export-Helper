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
using System.Windows.Forms;
using $safeprojectname$.Views;

namespace $safeprojectname$
{
	internal static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
        private static void Main(string[] args)
        {
            Properties.Settings.Default.Upgrade();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            //Get arguments
            if (args.Length == 0)
            {
                Application.Run(new MainWindow());
            }
            else if (args.Length == 1)
            {
                MessageBox.Show("Syntax:" + Environment.NewLine +
                                "/token <User-Token> \t Tocken from TeamViwer Management Console"+ Environment.NewLine +
                                "/run \t\t\t Automatically click the quarry button" + Environment.NewLine +
                                "/devices \t\t\t Automatically check the devices checkbox" + Environment.NewLine +
                                "/account \t\t\t Automatically check the account checkbox" + Environment.NewLine +
                                "/users \t\t\t Automatically check the users checkbox" + Environment.NewLine +
                                "/groups \t\t\t Automatically check the groups checkbox" + Environment.NewLine +
                                "/save <Save-Directory> \t Autosave to given directory");
            }
            else if (args.Length > 2)
            {
                int i = 1;
                string token = "";
                bool autostart = false;
                bool devices = false;
                bool account = false;
                bool users = false;
                bool groups = false;
                string autosavedirectory = "";
                foreach (string s in args)
                {
                    switch (s.ToLower())
                    {
                        case "/token":
                            token = args[i];
                            break;
                        case "/run":
                            autostart = true;
                            break;
                        case "/devices":
                            devices = true;
                            break;
                        case "/account":
                            account = true;
                            break;
                        case "/users":
                            users = true;
                            break;
                        case "/groups":
                            groups = true;
                            break;
                        case "/save":
                            autosavedirectory = args[i];
                            break;
                        default:
                            break;
                    }
                    i++;
                }
                Application.Run(new MainWindow(token, autostart, autosavedirectory, devices, account, users, groups));
            }
        }
    }
}
