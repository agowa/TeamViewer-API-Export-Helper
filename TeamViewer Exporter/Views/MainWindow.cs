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
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using TeamViewer_Exporter.CustomException;
using TeamViewer_Exporter.DataType;
using TeamViewer_Exporter.Helper;
using TeamViewer_Exporter.Ressources;
using Newtonsoft.Json;
using System.Threading;

namespace TeamViewer_Exporter.Views
{
    /// <summary>
    /// Main Dialog with its functions
    /// </summary>
    internal partial class MainWindow : Form
    {
        private QuarryInformation[] quarry = new QuarryInformation[4];
        private const string Placeholder = "Enter your script token here ...";
        public static bool autostart = false; //Is used without object reference
        private string autosavedirectory = "";

        /// <summary>
        /// Constructor of the Main Dialog
        /// </summary>
        internal MainWindow()
        {
            // Initialising the gui und filling it with sample values
            InitializeComponent();

            ScriptTokenTextBox.Text = Placeholder;
            ScriptTokenTextBox.ForeColor = Color.LightGray;
        }
        //Application.Run(new MainWindow(token, autostart, autosavedirectory, devices, account, users, groups));
        internal MainWindow(string token, bool autostart, string autosavedirectory, bool devices, bool account, bool users, bool groups)
        {
            InitializeComponent();
            Shown += MainWindow_Shown;
            ScriptTokenTextBox.Text = token;
            MainWindow.autostart = autostart;
            this.autosavedirectory = autosavedirectory;
            this.chb_Devices.Checked = devices;
            this.chb_Account.Checked = account;
            this.chb_Users.Checked = users;
            this.chb_Groups.Checked = groups;
        }

        /// <summary>
        /// Catching the event if someone has clicked on the "Get names"-Button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void getRequestedDataFromApi_Click(object sender, EventArgs e)
        {
            resultTextBox.Clear();
            quarry[0] = null;
            quarry[1] = null;
            quarry[2] = null;
            quarry[3] = null;
            if (ScriptTokenTextBox.Text != string.Empty)
            {
                if (chb_Devices.Checked)
                {
                    ApiFunctions.QuarryDevices(TokenType.SkriptToken, ScriptTokenTextBox.Text, ref quarry[0]);
                }
                if (chb_Account.Checked)
                {
                    ApiFunctions.QuarryAccount(TokenType.SkriptToken, ScriptTokenTextBox.Text, ref quarry[1]);
                }
                if (chb_Users.Checked)
                {
                    ApiFunctions.QuarryUsers(TokenType.SkriptToken, ScriptTokenTextBox.Text, ref quarry[2]);
                }
                if (chb_Groups.Checked)
                {
                    ApiFunctions.QuarryGroups(TokenType.SkriptToken, ScriptTokenTextBox.Text, ref quarry[3]);
                }

                String result = null;
                foreach (QuarryInformation element in quarry)
                {
                    if (element != null)
                    {
                        result = result + element.FormatedJsonString + Environment.NewLine;
                    }
                }
                resultTextBox.Text = result;

                //Enable save to file dialogue
                save_to_file.Enabled = true;
            }
            else
            {
                if (!MainWindow.autostart)
                {
                    MessageBox.Show(Resources.Error_AccessTokenRequired);
                }
            }
        }

        /// <summary>
        /// Catching the event if someone changed the text in the ScriptTokenTextBox -> Updating the GUI
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ScriptTokenTextBox_TextChanged(object sender, EventArgs e)
        {
            getRequestedDataFromApi.Enabled = (ScriptTokenTextBox.Text != string.Empty && ScriptTokenTextBox.Text != Placeholder);
            chb_Account.Enabled = (ScriptTokenTextBox.Text != string.Empty && ScriptTokenTextBox.Text != Placeholder);
            chb_Devices.Enabled = (ScriptTokenTextBox.Text != string.Empty && ScriptTokenTextBox.Text != Placeholder);
            chb_Groups.Enabled = (ScriptTokenTextBox.Text != string.Empty && ScriptTokenTextBox.Text != Placeholder);
            chb_Users.Enabled = (ScriptTokenTextBox.Text != string.Empty && ScriptTokenTextBox.Text != Placeholder);
        }

        /// <summary>
        /// Check if the data the API requires for creating  session is available
        /// </summary>
        /// <returns></returns>
        internal bool NecessaryDataIsAvailable()
        {
            return (ScriptTokenTextBox.Text != string.Empty && ScriptTokenTextBox.Text != Placeholder);
        }

        private void menuItemExitApplication_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ScriptTokenTextBox_Enter(object sender, EventArgs e)
        {
            if (ScriptTokenTextBox.Text == Placeholder)
            {
                ScriptTokenTextBox.Text = string.Empty;
                ScriptTokenTextBox.ForeColor = Color.Black;
            }
        }

        private void ScriptTokenTextBox_Leave(object sender, EventArgs e)
        {
            if (ScriptTokenTextBox.Text == string.Empty)
            {
                ScriptTokenTextBox.Text = Placeholder;
                ScriptTokenTextBox.ForeColor = Color.LightGray;
            }
        }

        private void about_Click(object sender, EventArgs e)
        {
            var appInfo = @"Product:" + Tools.Tab + Tools.Tab + ApplicationInfo.AssemblyProduct;
            appInfo += Environment.NewLine;
            appInfo += @"Build date:" + Tools.Tab + ApplicationInfo.RetrieveLinkerTimestamp();
            appInfo += Environment.NewLine;
            appInfo += @"Copyright:" + Tools.Tab + ApplicationInfo.AssemblyCopyright;
            appInfo += Environment.NewLine;
            appInfo += " " + Tools.Tab + Tools.Tab + ApplicationInfo.AssemblyCompany;
            if (!MainWindow.autostart)
            {
                MessageBox.Show(appInfo, @"Application info");
            }
        }

        private void menuItemOnlineHelp_Click(object sender, EventArgs e)
        {
            Process.Start("http://integrate.teamviewer.com");
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            try
            {
                var testObject = new JsonSerializer(); // Create an Object from the Newtonsoft.Json.dll to check if the dll is available
            }
            catch (Exception exception)
            {
                if (!MainWindow.autostart)
                {
                    MessageBox.Show(exception.Message, @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                Close();
            }
        }

        private void MainWindow_Shown(object sender, EventArgs e)
        {
            //Only called, if programm was launched with parameters
            if (autostart)
            {
                getRequestedDataFromApi.PerformClick();
                if (autosavedirectory != "")
                {
                    System.Text.UnicodeEncoding unicodeEncoding = new System.Text.UnicodeEncoding();
                    string fileContent;
                    int fileNr = 1;
                    foreach (QuarryInformation element in quarry)
                    {
                        if (element != null)
                        {
                            string fileName = "TeamViewer_" + timestamp.GetTimestamp() + "_00" + fileNr++ + ".csv";
                            string pathString = System.IO.Path.Combine(autosavedirectory, fileName);
                            System.IO.FileStream fileStream = System.IO.File.Create(pathString);
                            fileContent = jsonToCsv.getCsv(element.FormatedJsonString);
                            var streamWriter = new System.IO.StreamWriter(fileStream, unicodeEncoding);
                            try
                            {
                                streamWriter.Write(fileContent);
                                streamWriter.Flush();
                                streamWriter.Close();
                            }
                            finally
                            {
                                streamWriter.Dispose();
                            }
                            fileStream.Close();
                            fileStream.Dispose();
                        }
                    }
                    //TODO: Find a way to timeout the MessageBox
                    Close();
                    //if (!MainWindow.autostart)
                    //{
                    //MessageBox.Show("Files saved to: " + autosavedirectory);
                    //}
                }
            }
        }

        private void save_to_file_Click(object sender, EventArgs e)
        {
            System.Text.UnicodeEncoding unicodeEncoding = new System.Text.UnicodeEncoding();
            string fileContent;
            saveFileDialog.Filter = "Json File(*.json)|*.json|CSV File(*.csv)|*.csv";

            int fileNr = 1;
            foreach (QuarryInformation element in quarry)
            {
                if (element != null)
                {
                    saveFileDialog.FileName = "TeamViewer_" + timestamp.GetTimestamp() + "_00" + fileNr++;
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        switch (saveFileDialog.FilterIndex)
                        {
                            case 2://CSV File
                                //Converting output to CSV
                                fileContent = jsonToCsv.getCsv(element.FormatedJsonString);
                                break;
                            case 1://Json File == default
                            default://Output formated as Json
                                fileContent = element.FormatedJsonString;
                                break;
                        }
                        System.IO.Stream myStream;
                        if ((myStream = saveFileDialog.OpenFile()) != null)
                        {
                            var streamWriter = new System.IO.StreamWriter(myStream, unicodeEncoding);
                            try
                            {
                                streamWriter.Write(fileContent);
                                streamWriter.Flush();
                                streamWriter.Close();
                            }
                            finally
                            {
                                streamWriter.Dispose();
                            }
                            myStream.Close();
                            myStream.Dispose();
                        }
                    }
                }
            }
            if (!MainWindow.autostart)
            {
                MessageBox.Show("Files saved");
            }
        }
    }
}