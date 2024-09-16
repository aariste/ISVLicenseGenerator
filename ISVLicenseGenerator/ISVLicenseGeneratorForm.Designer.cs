using ISVLicenseGenerator.Properties;
using Microsoft.VisualBasic.CompilerServices;
using System.Windows.Forms.PropertyGridInternal;

namespace ISVLicenseGeneratorCore
{
    partial class ISVLicenseGeneratorForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            PathTB = new System.Windows.Forms.TextBox();
            LicenseCodeTB = new System.Windows.Forms.TextBox();
            CustomerTB = new System.Windows.Forms.TextBox();
            SerialNumberTB = new System.Windows.Forms.TextBox();
            PathLbl = new System.Windows.Forms.Label();
            UserCountLbl = new System.Windows.Forms.Label();
            ExpirationDateLbl = new System.Windows.Forms.Label();
            SerialNumberLbl = new System.Windows.Forms.Label();
            CustomerTenantLbl = new System.Windows.Forms.Label();
            LicenseCodeLbl = new System.Windows.Forms.Label();
            GenerateBtn = new System.Windows.Forms.Button();
            OutputTB = new System.Windows.Forms.TextBox();
            ResultLbl = new System.Windows.Forms.Label();
            BrowseBtn = new System.Windows.Forms.Button();
            saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            ExpirationDatePicker = new System.Windows.Forms.DateTimePicker();
            UserCount = new System.Windows.Forms.NumericUpDown();
            MandatoryLbl = new System.Windows.Forms.Label();
            MainMenuStrip = new System.Windows.Forms.MenuStrip();
            fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            usageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            keyVauiltBtn = new System.Windows.Forms.RadioButton();
            usbBtn = new System.Windows.Forms.RadioButton();
            CertLocationLbl = new System.Windows.Forms.Label();
            keyVaultDNSlbl = new System.Windows.Forms.Label();
            keyNameLbl = new System.Windows.Forms.Label();
            keyVaultNameTB = new System.Windows.Forms.TextBox();
            keyNameTB = new System.Windows.Forms.TextBox();
            EntraIDTenantLbl = new System.Windows.Forms.Label();
            EntraIDTenantTB = new System.Windows.Forms.TextBox();
            AppIdTB = new System.Windows.Forms.TextBox();
            SecretTB = new System.Windows.Forms.TextBox();
            AppIDLbl = new System.Windows.Forms.Label();
            secretLbl = new System.Windows.Forms.Label();
            allowCrossDomainInstallationLbl = new System.Windows.Forms.Label();
            allowCrossDomainInstallationCheckBox = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)UserCount).BeginInit();
            MainMenuStrip.SuspendLayout();
            SuspendLayout();
            // 
            // PathTB
            // 
            PathTB.BackColor = System.Drawing.SystemColors.Control;
            PathTB.Location = new System.Drawing.Point(189, 198);
            PathTB.Name = "PathTB";
            PathTB.ReadOnly = true;
            PathTB.Size = new System.Drawing.Size(289, 23);
            PathTB.TabIndex = 0;
            // 
            // LicenseCodeTB
            // 
            LicenseCodeTB.Location = new System.Drawing.Point(189, 227);
            LicenseCodeTB.Name = "LicenseCodeTB";
            LicenseCodeTB.Size = new System.Drawing.Size(377, 23);
            LicenseCodeTB.TabIndex = 1;
            // 
            // CustomerTB
            // 
            CustomerTB.Location = new System.Drawing.Point(188, 256);
            CustomerTB.Name = "CustomerTB";
            CustomerTB.Size = new System.Drawing.Size(377, 23);
            CustomerTB.TabIndex = 2;
            // 
            // SerialNumberTB
            // 
            SerialNumberTB.Location = new System.Drawing.Point(189, 285);
            SerialNumberTB.Name = "SerialNumberTB";
            SerialNumberTB.Size = new System.Drawing.Size(377, 23);
            SerialNumberTB.TabIndex = 3;
            // 
            // PathLbl
            // 
            PathLbl.AutoSize = true;
            PathLbl.Location = new System.Drawing.Point(12, 206);
            PathLbl.Name = "PathLbl";
            PathLbl.Size = new System.Drawing.Size(47, 15);
            PathLbl.TabIndex = 6;
            PathLbl.Text = "Path (*)";
            // 
            // UserCountLbl
            // 
            UserCountLbl.AutoSize = true;
            UserCountLbl.Location = new System.Drawing.Point(12, 351);
            UserCountLbl.Name = "UserCountLbl";
            UserCountLbl.Size = new System.Drawing.Size(64, 15);
            UserCountLbl.TabIndex = 8;
            UserCountLbl.Text = "User count";
            // 
            // ExpirationDateLbl
            // 
            ExpirationDateLbl.AutoSize = true;
            ExpirationDateLbl.Location = new System.Drawing.Point(12, 322);
            ExpirationDateLbl.Name = "ExpirationDateLbl";
            ExpirationDateLbl.Size = new System.Drawing.Size(86, 15);
            ExpirationDateLbl.TabIndex = 9;
            ExpirationDateLbl.Text = "Expiration date";
            // 
            // SerialNumberLbl
            // 
            SerialNumberLbl.AutoSize = true;
            SerialNumberLbl.Location = new System.Drawing.Point(12, 293);
            SerialNumberLbl.Name = "SerialNumberLbl";
            SerialNumberLbl.Size = new System.Drawing.Size(96, 15);
            SerialNumberLbl.TabIndex = 10;
            SerialNumberLbl.Text = "Serial number (*)";
            // 
            // CustomerTenantLbl
            // 
            CustomerTenantLbl.AutoSize = true;
            CustomerTenantLbl.Location = new System.Drawing.Point(12, 264);
            CustomerTenantLbl.Name = "CustomerTenantLbl";
            CustomerTenantLbl.Size = new System.Drawing.Size(112, 15);
            CustomerTenantLbl.TabIndex = 11;
            CustomerTenantLbl.Text = "Customer tenant (*)";
            // 
            // LicenseCodeLbl
            // 
            LicenseCodeLbl.AutoSize = true;
            LicenseCodeLbl.Location = new System.Drawing.Point(12, 235);
            LicenseCodeLbl.Name = "LicenseCodeLbl";
            LicenseCodeLbl.Size = new System.Drawing.Size(91, 15);
            LicenseCodeLbl.TabIndex = 12;
            LicenseCodeLbl.Text = "License code (*)";
            // 
            // GenerateBtn
            // 
            GenerateBtn.Location = new System.Drawing.Point(474, 413);
            GenerateBtn.Name = "GenerateBtn";
            GenerateBtn.Size = new System.Drawing.Size(90, 30);
            GenerateBtn.TabIndex = 13;
            GenerateBtn.Text = "Generate";
            GenerateBtn.UseVisualStyleBackColor = true;
            GenerateBtn.Click += GenerateBtn_Click;
            // 
            // OutputTB
            // 
            OutputTB.Enabled = false;
            OutputTB.Location = new System.Drawing.Point(12, 449);
            OutputTB.Multiline = true;
            OutputTB.Name = "OutputTB";
            OutputTB.ReadOnly = true;
            OutputTB.Size = new System.Drawing.Size(556, 145);
            OutputTB.TabIndex = 14;
            // 
            // ResultLbl
            // 
            ResultLbl.AutoSize = true;
            ResultLbl.Location = new System.Drawing.Point(12, 534);
            ResultLbl.Name = "ResultLbl";
            ResultLbl.Size = new System.Drawing.Size(39, 15);
            ResultLbl.TabIndex = 15;
            ResultLbl.Text = "Result";
            // 
            // BrowseBtn
            // 
            BrowseBtn.Location = new System.Drawing.Point(484, 199);
            BrowseBtn.Name = "BrowseBtn";
            BrowseBtn.Size = new System.Drawing.Size(82, 22);
            BrowseBtn.TabIndex = 16;
            BrowseBtn.Text = "Browse...";
            BrowseBtn.UseVisualStyleBackColor = true;
            BrowseBtn.Click += BrowseBtn_Click;
            // 
            // ExpirationDatePicker
            // 
            ExpirationDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            ExpirationDatePicker.Location = new System.Drawing.Point(189, 314);
            ExpirationDatePicker.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            ExpirationDatePicker.Name = "ExpirationDatePicker";
            ExpirationDatePicker.Size = new System.Drawing.Size(377, 23);
            ExpirationDatePicker.TabIndex = 17;
            ExpirationDatePicker.Value = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            // 
            // UserCount
            // 
            UserCount.Location = new System.Drawing.Point(188, 343);
            UserCount.Maximum = new decimal(new int[] { int.MaxValue, 0, 0, 0 });
            UserCount.Name = "UserCount";
            UserCount.Size = new System.Drawing.Size(376, 23);
            UserCount.TabIndex = 18;
            // 
            // MandatoryLbl
            // 
            MandatoryLbl.AutoSize = true;
            MandatoryLbl.Location = new System.Drawing.Point(12, 403);
            MandatoryLbl.Name = "MandatoryLbl";
            MandatoryLbl.Size = new System.Drawing.Size(115, 15);
            MandatoryLbl.TabIndex = 19;
            MandatoryLbl.Text = " (*) Mandatory fields";
            // 
            // MainMenuStrip
            // 
            MainMenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            MainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { fileToolStripMenuItem, helpToolStripMenuItem });
            MainMenuStrip.Location = new System.Drawing.Point(0, 0);
            MainMenuStrip.Name = "MainMenuStrip";
            MainMenuStrip.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            MainMenuStrip.Size = new System.Drawing.Size(577, 24);
            MainMenuStrip.TabIndex = 20;
            MainMenuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { exitToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            fileToolStripMenuItem.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new System.Drawing.Size(93, 22);
            exitToolStripMenuItem.Text = "Exit";
            exitToolStripMenuItem.Click += exitToolStripMenuItem_Click;
            // 
            // helpToolStripMenuItem
            // 
            helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { usageToolStripMenuItem });
            helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            helpToolStripMenuItem.Text = "Help";
            // 
            // usageToolStripMenuItem
            // 
            usageToolStripMenuItem.Name = "usageToolStripMenuItem";
            usageToolStripMenuItem.Size = new System.Drawing.Size(106, 22);
            usageToolStripMenuItem.Text = "Usage";
            usageToolStripMenuItem.Click += usageToolStripMenuItem_Click;
            // 
            // keyVauiltBtn
            // 
            keyVauiltBtn.AutoSize = true;
            keyVauiltBtn.Location = new System.Drawing.Point(273, 28);
            keyVauiltBtn.Name = "keyVauiltBtn";
            keyVauiltBtn.Size = new System.Drawing.Size(106, 19);
            keyVauiltBtn.TabIndex = 23;
            keyVauiltBtn.Text = "Azure Key Vault";
            keyVauiltBtn.UseVisualStyleBackColor = true;
            keyVauiltBtn.CheckedChanged += keyVauiltBtn_CheckedChanged;
            // 
            // usbBtn
            // 
            usbBtn.AutoSize = true;
            usbBtn.Checked = true;
            usbBtn.Location = new System.Drawing.Point(188, 28);
            usbBtn.Name = "usbBtn";
            usbBtn.Size = new System.Drawing.Size(79, 19);
            usbBtn.TabIndex = 22;
            usbBtn.TabStop = true;
            usbBtn.Text = "USB/Local";
            usbBtn.UseVisualStyleBackColor = true;
            usbBtn.CheckedChanged += usbBtn_CheckedChanged;
            // 
            // CertLocationLbl
            // 
            CertLocationLbl.AutoSize = true;
            CertLocationLbl.Location = new System.Drawing.Point(12, 30);
            CertLocationLbl.Name = "CertLocationLbl";
            CertLocationLbl.Size = new System.Drawing.Size(107, 15);
            CertLocationLbl.TabIndex = 21;
            CertLocationLbl.Text = "Certificate location";
            // 
            // keyVaultDNSlbl
            // 
            keyVaultDNSlbl.AutoSize = true;
            keyVaultDNSlbl.Location = new System.Drawing.Point(12, 61);
            keyVaultDNSlbl.Name = "keyVaultDNSlbl";
            keyVaultDNSlbl.Size = new System.Drawing.Size(97, 15);
            keyVaultDNSlbl.TabIndex = 24;
            keyVaultDNSlbl.Text = "Key Vault DNS (*)";
            // 
            // keyNameLbl
            // 
            keyNameLbl.AutoSize = true;
            keyNameLbl.Location = new System.Drawing.Point(12, 90);
            keyNameLbl.Name = "keyNameLbl";
            keyNameLbl.Size = new System.Drawing.Size(75, 15);
            keyNameLbl.TabIndex = 25;
            keyNameLbl.Text = "Key name (*)";
            // 
            // keyVaultNameTB
            // 
            keyVaultNameTB.Location = new System.Drawing.Point(189, 53);
            keyVaultNameTB.Name = "keyVaultNameTB";
            keyVaultNameTB.Size = new System.Drawing.Size(377, 23);
            keyVaultNameTB.TabIndex = 26;
            // 
            // keyNameTB
            // 
            keyNameTB.Location = new System.Drawing.Point(189, 82);
            keyNameTB.Name = "keyNameTB";
            keyNameTB.Size = new System.Drawing.Size(377, 23);
            keyNameTB.TabIndex = 27;
            // 
            // EntraIDTenantLbl
            // 
            EntraIDTenantLbl.AutoSize = true;
            EntraIDTenantLbl.Location = new System.Drawing.Point(12, 119);
            EntraIDTenantLbl.Name = "EntraIDTenantLbl";
            EntraIDTenantLbl.Size = new System.Drawing.Size(115, 15);
            EntraIDTenantLbl.TabIndex = 28;
            EntraIDTenantLbl.Text = "Entra ID Tenant Id (*)";
            // 
            // EntraIDTenantTB
            // 
            EntraIDTenantTB.Location = new System.Drawing.Point(188, 111);
            EntraIDTenantTB.Name = "EntraIDTenantTB";
            EntraIDTenantTB.Size = new System.Drawing.Size(377, 23);
            EntraIDTenantTB.TabIndex = 29;
            // 
            // AppIdTB
            // 
            AppIdTB.Location = new System.Drawing.Point(190, 140);
            AppIdTB.Name = "AppIdTB";
            AppIdTB.Size = new System.Drawing.Size(377, 23);
            AppIdTB.TabIndex = 30;
            // 
            // SecretTB
            // 
            SecretTB.Location = new System.Drawing.Point(190, 169);
            SecretTB.Name = "SecretTB";
            SecretTB.Size = new System.Drawing.Size(377, 23);
            SecretTB.TabIndex = 31;
            // 
            // AppIDLbl
            // 
            AppIDLbl.AutoSize = true;
            AppIDLbl.Location = new System.Drawing.Point(12, 148);
            AppIDLbl.Name = "AppIDLbl";
            AppIDLbl.Size = new System.Drawing.Size(55, 15);
            AppIDLbl.TabIndex = 32;
            AppIDLbl.Text = "AppId (*)";
            // 
            // secretLbl
            // 
            secretLbl.AutoSize = true;
            secretLbl.Location = new System.Drawing.Point(12, 177);
            secretLbl.Name = "secretLbl";
            secretLbl.Size = new System.Drawing.Size(55, 15);
            secretLbl.TabIndex = 33;
            secretLbl.Text = "Secret (*)";
            // 
            // allowCrossDomainInstallationLbl
            // 
            allowCrossDomainInstallationLbl.AutoSize = true;
            allowCrossDomainInstallationLbl.Location = new System.Drawing.Point(12, 377);
            allowCrossDomainInstallationLbl.Name = "allowCrossDomainInstallationLbl";
            allowCrossDomainInstallationLbl.Size = new System.Drawing.Size(172, 15);
            allowCrossDomainInstallationLbl.TabIndex = 34;
            allowCrossDomainInstallationLbl.Text = "Allow cross domain installation";
            // 
            // allowCrossDomainInstallationCheckBox
            // 
            allowCrossDomainInstallationCheckBox.AutoSize = true;
            allowCrossDomainInstallationCheckBox.Location = new System.Drawing.Point(188, 377);
            allowCrossDomainInstallationCheckBox.Name = "allowCrossDomainInstallationCheckBox";
            allowCrossDomainInstallationCheckBox.Size = new System.Drawing.Size(15, 14);
            allowCrossDomainInstallationCheckBox.TabIndex = 35;
            allowCrossDomainInstallationCheckBox.UseVisualStyleBackColor = true;
            // 
            // ISVLicenseGeneratorForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(577, 613);
            Controls.Add(allowCrossDomainInstallationCheckBox);
            Controls.Add(allowCrossDomainInstallationLbl);
            Controls.Add(secretLbl);
            Controls.Add(AppIDLbl);
            Controls.Add(SecretTB);
            Controls.Add(AppIdTB);
            Controls.Add(EntraIDTenantTB);
            Controls.Add(EntraIDTenantLbl);
            Controls.Add(keyNameTB);
            Controls.Add(keyVaultNameTB);
            Controls.Add(keyNameLbl);
            Controls.Add(keyVaultDNSlbl);
            Controls.Add(keyVauiltBtn);
            Controls.Add(usbBtn);
            Controls.Add(CertLocationLbl);
            Controls.Add(MandatoryLbl);
            Controls.Add(UserCount);
            Controls.Add(ExpirationDatePicker);
            Controls.Add(BrowseBtn);
            Controls.Add(ResultLbl);
            Controls.Add(OutputTB);
            Controls.Add(GenerateBtn);
            Controls.Add(LicenseCodeLbl);
            Controls.Add(CustomerTenantLbl);
            Controls.Add(SerialNumberLbl);
            Controls.Add(ExpirationDateLbl);
            Controls.Add(UserCountLbl);
            Controls.Add(PathLbl);
            Controls.Add(SerialNumberTB);
            Controls.Add(CustomerTB);
            Controls.Add(LicenseCodeTB);
            Controls.Add(PathTB);
            Controls.Add(MainMenuStrip);
            Icon = Resources.Icon;
            Name = "ISVLicenseGeneratorForm";
            Text = "ISV License Generator";
            ((System.ComponentModel.ISupportInitialize)UserCount).EndInit();
            MainMenuStrip.ResumeLayout(false);
            MainMenuStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.TextBox PathTB;
        private System.Windows.Forms.TextBox LicenseCodeTB;
        private System.Windows.Forms.TextBox CustomerTB;
        private System.Windows.Forms.TextBox SerialNumberTB;
        private System.Windows.Forms.Label PathLbl;
        private System.Windows.Forms.Label UserCountLbl;
        private System.Windows.Forms.Label ExpirationDateLbl;
        private System.Windows.Forms.Label SerialNumberLbl;
        private System.Windows.Forms.Label CustomerTenantLbl;
        private System.Windows.Forms.Label LicenseCodeLbl;
        private System.Windows.Forms.Button GenerateBtn;
        private System.Windows.Forms.TextBox OutputTB;
        private System.Windows.Forms.Label ResultLbl;
        private System.Windows.Forms.Button BrowseBtn;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.DateTimePicker ExpirationDatePicker;
        private System.Windows.Forms.NumericUpDown UserCount;
        private System.Windows.Forms.Label MandatoryLbl;
        private new System.Windows.Forms.MenuStrip MainMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem usageToolStripMenuItem;
        private System.Windows.Forms.RadioButton keyVauiltBtn;
        private System.Windows.Forms.RadioButton usbBtn;
        private System.Windows.Forms.Label CertLocationLbl;
        private System.Windows.Forms.Label keyVaultDNSlbl;
        private System.Windows.Forms.Label keyNameLbl;
        private System.Windows.Forms.TextBox keyVaultNameTB;
        private System.Windows.Forms.TextBox keyNameTB;
        private System.Windows.Forms.Label EntraIDTenantLbl;
        private System.Windows.Forms.TextBox EntraIDTenantTB;
        private System.Windows.Forms.TextBox AppIdTB;
        private System.Windows.Forms.TextBox SecretTB;
        private System.Windows.Forms.Label AppIDLbl;
        private System.Windows.Forms.Label secretLbl;
        private System.Windows.Forms.Label allowCrossDomainInstallationLbl;
        private System.Windows.Forms.CheckBox allowCrossDomainInstallationCheckBox;
    }
}

