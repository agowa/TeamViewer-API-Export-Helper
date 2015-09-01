using System.Security.AccessControl;

namespace $safeprojectname$.Views
{
    partial class MainWindow
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.ScriptTokenTextBox = new System.Windows.Forms.TextBox();
            this.getRequestedDataFromApi = new System.Windows.Forms.Button();
            this.resultLabel = new System.Windows.Forms.Label();
            this.resultTextBox = new System.Windows.Forms.TextBox();
            this.ScriptTokenLabel = new System.Windows.Forms.Label();
            this.groupBoxAccessToken = new System.Windows.Forms.GroupBox();
            this.groupBoxSessionProperties = new System.Windows.Forms.GroupBox();
            this.chb_Groups = new System.Windows.Forms.CheckBox();
            this.chb_Users = new System.Windows.Forms.CheckBox();
            this.chb_Account = new System.Windows.Forms.CheckBox();
            this.chb_Devices = new System.Windows.Forms.CheckBox();
            this.groupBoxResult = new System.Windows.Forms.GroupBox();
            this.mainMenu = new System.Windows.Forms.MainMenu(this.components);
            this.menuItemApplication = new System.Windows.Forms.MenuItem();
            this.menuItemExitApplication = new System.Windows.Forms.MenuItem();
            this.helpMenu = new System.Windows.Forms.MenuItem();
            this.menuItemVisitWebsite = new System.Windows.Forms.MenuItem();
            this.about = new System.Windows.Forms.MenuItem();
            this.save_to_file = new System.Windows.Forms.Button();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.groupBoxAccessToken.SuspendLayout();
            this.groupBoxSessionProperties.SuspendLayout();
            this.groupBoxResult.SuspendLayout();
            this.SuspendLayout();
            // 
            // ScriptTokenTextBox
            // 
            this.ScriptTokenTextBox.Location = new System.Drawing.Point(76, 22);
            this.ScriptTokenTextBox.Name = "ScriptTokenTextBox";
            this.ScriptTokenTextBox.Size = new System.Drawing.Size(361, 20);
            this.ScriptTokenTextBox.TabIndex = 1;
            this.ScriptTokenTextBox.TextChanged += new System.EventHandler(this.ScriptTokenTextBox_TextChanged);
            this.ScriptTokenTextBox.Enter += new System.EventHandler(this.ScriptTokenTextBox_Enter);
            this.ScriptTokenTextBox.Leave += new System.EventHandler(this.ScriptTokenTextBox_Leave);
            // 
            // getRequestedDataFromApi
            // 
            this.getRequestedDataFromApi.Font = new System.Drawing.Font("Microsoft Sans Serif", 40F);
            this.getRequestedDataFromApi.Location = new System.Drawing.Point(6, 19);
            this.getRequestedDataFromApi.Name = "getRequestedDataFromApi";
            this.getRequestedDataFromApi.Size = new System.Drawing.Size(431, 64);
            this.getRequestedDataFromApi.TabIndex = 4;
            this.getRequestedDataFromApi.Text = "Quarry request";
            this.getRequestedDataFromApi.UseVisualStyleBackColor = true;
            this.getRequestedDataFromApi.Click += new System.EventHandler(this.getRequestedDataFromApi_Click);
            // 
            // resultLabel
            // 
            this.resultLabel.AutoSize = true;
            this.resultLabel.Location = new System.Drawing.Point(6, 16);
            this.resultLabel.Name = "resultLabel";
            this.resultLabel.Size = new System.Drawing.Size(168, 13);
            this.resultLabel.TabIndex = 12;
            this.resultLabel.Text = "Complete result string from the API";
            // 
            // resultTextBox
            // 
            this.resultTextBox.AcceptsReturn = true;
            this.resultTextBox.Location = new System.Drawing.Point(9, 32);
            this.resultTextBox.Multiline = true;
            this.resultTextBox.Name = "resultTextBox";
            this.resultTextBox.ReadOnly = true;
            this.resultTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.resultTextBox.Size = new System.Drawing.Size(431, 261);
            this.resultTextBox.TabIndex = 13;
            // 
            // ScriptTokenLabel
            // 
            this.ScriptTokenLabel.AutoSize = true;
            this.ScriptTokenLabel.Location = new System.Drawing.Point(6, 25);
            this.ScriptTokenLabel.Name = "ScriptTokenLabel";
            this.ScriptTokenLabel.Size = new System.Drawing.Size(64, 13);
            this.ScriptTokenLabel.TabIndex = 0;
            this.ScriptTokenLabel.TabStop = true;
            this.ScriptTokenLabel.Text = "Script token";
            // 
            // groupBoxAccessToken
            // 
            this.groupBoxAccessToken.Controls.Add(this.ScriptTokenLabel);
            this.groupBoxAccessToken.Controls.Add(this.ScriptTokenTextBox);
            this.groupBoxAccessToken.Location = new System.Drawing.Point(12, 11);
            this.groupBoxAccessToken.Name = "groupBoxAccessToken";
            this.groupBoxAccessToken.Size = new System.Drawing.Size(443, 57);
            this.groupBoxAccessToken.TabIndex = 21;
            this.groupBoxAccessToken.TabStop = false;
            this.groupBoxAccessToken.Text = "Access token";
            // 
            // groupBoxSessionProperties
            // 
            this.groupBoxSessionProperties.Controls.Add(this.chb_Groups);
            this.groupBoxSessionProperties.Controls.Add(this.chb_Users);
            this.groupBoxSessionProperties.Controls.Add(this.chb_Account);
            this.groupBoxSessionProperties.Controls.Add(this.chb_Devices);
            this.groupBoxSessionProperties.Controls.Add(this.getRequestedDataFromApi);
            this.groupBoxSessionProperties.Location = new System.Drawing.Point(12, 74);
            this.groupBoxSessionProperties.Name = "groupBoxSessionProperties";
            this.groupBoxSessionProperties.Size = new System.Drawing.Size(443, 106);
            this.groupBoxSessionProperties.TabIndex = 22;
            this.groupBoxSessionProperties.TabStop = false;
            this.groupBoxSessionProperties.Text = "Session properties";
            // 
            // chb_Groups
            // 
            this.chb_Groups.AutoSize = true;
            this.chb_Groups.Enabled = false;
            this.chb_Groups.Location = new System.Drawing.Point(377, 86);
            this.chb_Groups.Name = "chb_Groups";
            this.chb_Groups.Size = new System.Drawing.Size(60, 17);
            this.chb_Groups.TabIndex = 8;
            this.chb_Groups.Text = "Groups";
            this.chb_Groups.UseVisualStyleBackColor = true;
            // 
            // chb_Users
            // 
            this.chb_Users.AutoSize = true;
            this.chb_Users.Enabled = false;
            this.chb_Users.Location = new System.Drawing.Point(278, 86);
            this.chb_Users.Name = "chb_Users";
            this.chb_Users.Size = new System.Drawing.Size(53, 17);
            this.chb_Users.TabIndex = 7;
            this.chb_Users.Text = "Users";
            this.chb_Users.UseVisualStyleBackColor = true;
            // 
            // chb_Account
            // 
            this.chb_Account.AutoSize = true;
            this.chb_Account.Enabled = false;
            this.chb_Account.Location = new System.Drawing.Point(130, 86);
            this.chb_Account.Name = "chb_Account";
            this.chb_Account.Size = new System.Drawing.Size(66, 17);
            this.chb_Account.TabIndex = 6;
            this.chb_Account.Text = "Account";
            this.chb_Account.UseVisualStyleBackColor = true;
            // 
            // chb_Devices
            // 
            this.chb_Devices.AutoSize = true;
            this.chb_Devices.Checked = true;
            this.chb_Devices.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chb_Devices.Enabled = false;
            this.chb_Devices.Location = new System.Drawing.Point(9, 86);
            this.chb_Devices.Name = "chb_Devices";
            this.chb_Devices.Size = new System.Drawing.Size(65, 17);
            this.chb_Devices.TabIndex = 5;
            this.chb_Devices.Text = "Devices";
            this.chb_Devices.UseVisualStyleBackColor = true;
            // 
            // groupBoxResult
            // 
            this.groupBoxResult.Controls.Add(this.resultTextBox);
            this.groupBoxResult.Controls.Add(this.resultLabel);
            this.groupBoxResult.Location = new System.Drawing.Point(12, 186);
            this.groupBoxResult.Name = "groupBoxResult";
            this.groupBoxResult.Size = new System.Drawing.Size(443, 299);
            this.groupBoxResult.TabIndex = 23;
            this.groupBoxResult.TabStop = false;
            this.groupBoxResult.Text = "Result";
            // 
            // mainMenu
            // 
            this.mainMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItemApplication,
            this.helpMenu});
            // 
            // menuItemApplication
            // 
            this.menuItemApplication.Index = 0;
            this.menuItemApplication.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItemExitApplication});
            this.menuItemApplication.Text = "Application";
            // 
            // menuItemExitApplication
            // 
            this.menuItemExitApplication.Index = 0;
            this.menuItemExitApplication.Text = "Exit";
            this.menuItemExitApplication.Click += new System.EventHandler(this.menuItemExitApplication_Click);
            // 
            // helpMenu
            // 
            this.helpMenu.Index = 1;
            this.helpMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItemVisitWebsite,
            this.about});
            this.helpMenu.Text = "Help";
            // 
            // menuItemVisitWebsite
            // 
            this.menuItemVisitWebsite.Index = 0;
            this.menuItemVisitWebsite.Text = "Visit website";
            this.menuItemVisitWebsite.Click += new System.EventHandler(this.menuItemOnlineHelp_Click);
            // 
            // about
            // 
            this.about.Index = 1;
            this.about.Text = "About";
            this.about.Click += new System.EventHandler(this.about_Click);
            // 
            // save_to_file
            // 
            this.save_to_file.Enabled = false;
            this.save_to_file.Location = new System.Drawing.Point(12, 491);
            this.save_to_file.Name = "save_to_file";
            this.save_to_file.Size = new System.Drawing.Size(443, 23);
            this.save_to_file.TabIndex = 24;
            this.save_to_file.Text = "Save to file";
            this.save_to_file.UseVisualStyleBackColor = true;
            this.save_to_file.Click += new System.EventHandler(this.save_to_file_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(467, 530);
            this.Controls.Add(this.save_to_file);
            this.Controls.Add(this.groupBoxResult);
            this.Controls.Add(this.groupBoxSessionProperties);
            this.Controls.Add(this.groupBoxAccessToken);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(483, 765);
            this.Menu = this.mainMenu;
            this.MinimumSize = new System.Drawing.Size(483, 480);
            this.Name = "MainWindow";
            this.Text = "$safeprojectname$";
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.groupBoxAccessToken.ResumeLayout(false);
            this.groupBoxAccessToken.PerformLayout();
            this.groupBoxSessionProperties.ResumeLayout(false);
            this.groupBoxSessionProperties.PerformLayout();
            this.groupBoxResult.ResumeLayout(false);
            this.groupBoxResult.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox ScriptTokenTextBox;
        private System.Windows.Forms.Button getRequestedDataFromApi;
        private System.Windows.Forms.Label resultLabel;
        private System.Windows.Forms.TextBox resultTextBox;
        private System.Windows.Forms.Label ScriptTokenLabel;
        private System.Windows.Forms.GroupBox groupBoxAccessToken;
        private System.Windows.Forms.GroupBox groupBoxSessionProperties;
        private System.Windows.Forms.GroupBox groupBoxResult;
        private System.Windows.Forms.MainMenu mainMenu;
        private System.Windows.Forms.MenuItem menuItemApplication;
        private System.Windows.Forms.MenuItem menuItemExitApplication;
        private System.Windows.Forms.MenuItem helpMenu;
        private System.Windows.Forms.MenuItem about;
        private System.Windows.Forms.MenuItem menuItemVisitWebsite;
        private System.Windows.Forms.Button save_to_file;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.CheckBox chb_Groups;
        private System.Windows.Forms.CheckBox chb_Users;
        private System.Windows.Forms.CheckBox chb_Account;
        private System.Windows.Forms.CheckBox chb_Devices;
    }
}

