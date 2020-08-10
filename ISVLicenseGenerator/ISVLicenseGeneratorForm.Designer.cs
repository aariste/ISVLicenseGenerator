namespace ISVLicenseGenerator
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ISVLicenseGeneratorForm));
            this.PathTB = new System.Windows.Forms.TextBox();
            this.LicenseCodeTB = new System.Windows.Forms.TextBox();
            this.CustomerTB = new System.Windows.Forms.TextBox();
            this.SerialNumberTB = new System.Windows.Forms.TextBox();
            this.PathLbl = new System.Windows.Forms.Label();
            this.UserCountLbl = new System.Windows.Forms.Label();
            this.ExpirationDateLbl = new System.Windows.Forms.Label();
            this.SerialNumberLbl = new System.Windows.Forms.Label();
            this.CustomerTenantLbl = new System.Windows.Forms.Label();
            this.LicenseCodeLbl = new System.Windows.Forms.Label();
            this.GenerateBtn = new System.Windows.Forms.Button();
            this.OutputTB = new System.Windows.Forms.TextBox();
            this.ResultLbl = new System.Windows.Forms.Label();
            this.BrowseBtn = new System.Windows.Forms.Button();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.ExpirationDatePicker = new System.Windows.Forms.DateTimePicker();
            this.UserCount = new System.Windows.Forms.NumericUpDown();
            this.MandatoryLbl = new System.Windows.Forms.Label();
            this.MainMenuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.usageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SHA1LicenceRadioBtn = new System.Windows.Forms.RadioButton();
            this.SHA256LicenceRadioBtn = new System.Windows.Forms.RadioButton();
            this.SigningAlgorithmLbl = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.UserCount)).BeginInit();
            this.MainMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // PathTB
            // 
            this.PathTB.BackColor = System.Drawing.SystemColors.Control;
            this.PathTB.Location = new System.Drawing.Point(217, 70);
            this.PathTB.Name = "PathTB";
            this.PathTB.ReadOnly = true;
            this.PathTB.Size = new System.Drawing.Size(330, 22);
            this.PathTB.TabIndex = 0;
            // 
            // LicenseCodeTB
            // 
            this.LicenseCodeTB.Location = new System.Drawing.Point(217, 98);
            this.LicenseCodeTB.Name = "LicenseCodeTB";
            this.LicenseCodeTB.Size = new System.Drawing.Size(430, 22);
            this.LicenseCodeTB.TabIndex = 1;
            // 
            // CustomerTB
            // 
            this.CustomerTB.Location = new System.Drawing.Point(217, 126);
            this.CustomerTB.Name = "CustomerTB";
            this.CustomerTB.Size = new System.Drawing.Size(430, 22);
            this.CustomerTB.TabIndex = 2;
            // 
            // SerialNumberTB
            // 
            this.SerialNumberTB.Location = new System.Drawing.Point(217, 154);
            this.SerialNumberTB.Name = "SerialNumberTB";
            this.SerialNumberTB.Size = new System.Drawing.Size(430, 22);
            this.SerialNumberTB.TabIndex = 3;
            // 
            // PathLbl
            // 
            this.PathLbl.AutoSize = true;
            this.PathLbl.Location = new System.Drawing.Point(11, 73);
            this.PathLbl.Name = "PathLbl";
            this.PathLbl.Size = new System.Drawing.Size(56, 17);
            this.PathLbl.TabIndex = 6;
            this.PathLbl.Text = "Path (*)";
            // 
            // UserCountLbl
            // 
            this.UserCountLbl.AutoSize = true;
            this.UserCountLbl.Location = new System.Drawing.Point(11, 212);
            this.UserCountLbl.Name = "UserCountLbl";
            this.UserCountLbl.Size = new System.Drawing.Size(77, 17);
            this.UserCountLbl.TabIndex = 8;
            this.UserCountLbl.Text = "User count";
            // 
            // ExpirationDateLbl
            // 
            this.ExpirationDateLbl.AutoSize = true;
            this.ExpirationDateLbl.Location = new System.Drawing.Point(11, 187);
            this.ExpirationDateLbl.Name = "ExpirationDateLbl";
            this.ExpirationDateLbl.Size = new System.Drawing.Size(102, 17);
            this.ExpirationDateLbl.TabIndex = 9;
            this.ExpirationDateLbl.Text = "Expiration date";
            // 
            // SerialNumberLbl
            // 
            this.SerialNumberLbl.AutoSize = true;
            this.SerialNumberLbl.Location = new System.Drawing.Point(11, 157);
            this.SerialNumberLbl.Name = "SerialNumberLbl";
            this.SerialNumberLbl.Size = new System.Drawing.Size(115, 17);
            this.SerialNumberLbl.TabIndex = 10;
            this.SerialNumberLbl.Text = "Serial number (*)";
            // 
            // CustomerTenantLbl
            // 
            this.CustomerTenantLbl.AutoSize = true;
            this.CustomerTenantLbl.Location = new System.Drawing.Point(11, 129);
            this.CustomerTenantLbl.Name = "CustomerTenantLbl";
            this.CustomerTenantLbl.Size = new System.Drawing.Size(131, 17);
            this.CustomerTenantLbl.TabIndex = 11;
            this.CustomerTenantLbl.Text = "Customer tenant (*)";
            // 
            // LicenseCodeLbl
            // 
            this.LicenseCodeLbl.AutoSize = true;
            this.LicenseCodeLbl.Location = new System.Drawing.Point(11, 101);
            this.LicenseCodeLbl.Name = "LicenseCodeLbl";
            this.LicenseCodeLbl.Size = new System.Drawing.Size(111, 17);
            this.LicenseCodeLbl.TabIndex = 12;
            this.LicenseCodeLbl.Text = "License code (*)";
            // 
            // GenerateBtn
            // 
            this.GenerateBtn.Location = new System.Drawing.Point(544, 238);
            this.GenerateBtn.Name = "GenerateBtn";
            this.GenerateBtn.Size = new System.Drawing.Size(103, 32);
            this.GenerateBtn.TabIndex = 13;
            this.GenerateBtn.Text = "Generate";
            this.GenerateBtn.UseVisualStyleBackColor = true;
            this.GenerateBtn.Click += new System.EventHandler(this.GenerateBtn_Click);
            // 
            // OutputTB
            // 
            this.OutputTB.Enabled = false;
            this.OutputTB.Location = new System.Drawing.Point(12, 285);
            this.OutputTB.Multiline = true;
            this.OutputTB.Name = "OutputTB";
            this.OutputTB.ReadOnly = true;
            this.OutputTB.Size = new System.Drawing.Size(635, 63);
            this.OutputTB.TabIndex = 14;
            // 
            // ResultLbl
            // 
            this.ResultLbl.AutoSize = true;
            this.ResultLbl.Location = new System.Drawing.Point(11, 265);
            this.ResultLbl.Name = "ResultLbl";
            this.ResultLbl.Size = new System.Drawing.Size(48, 17);
            this.ResultLbl.TabIndex = 15;
            this.ResultLbl.Text = "Result";
            // 
            // BrowseBtn
            // 
            this.BrowseBtn.Location = new System.Drawing.Point(553, 69);
            this.BrowseBtn.Name = "BrowseBtn";
            this.BrowseBtn.Size = new System.Drawing.Size(94, 23);
            this.BrowseBtn.TabIndex = 16;
            this.BrowseBtn.Text = "Browse...";
            this.BrowseBtn.UseVisualStyleBackColor = true;
            this.BrowseBtn.Click += new System.EventHandler(this.BrowseBtn_Click);
            // 
            // ExpirationDatePicker
            // 
            this.ExpirationDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.ExpirationDatePicker.Location = new System.Drawing.Point(217, 182);
            this.ExpirationDatePicker.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.ExpirationDatePicker.Name = "ExpirationDatePicker";
            this.ExpirationDatePicker.Size = new System.Drawing.Size(430, 22);
            this.ExpirationDatePicker.TabIndex = 17;
            this.ExpirationDatePicker.Value = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            // 
            // UserCount
            // 
            this.UserCount.Location = new System.Drawing.Point(217, 210);
            this.UserCount.Name = "UserCount";
            this.UserCount.Size = new System.Drawing.Size(430, 22);
            this.UserCount.TabIndex = 18;
            // 
            // MandatoryLbl
            // 
            this.MandatoryLbl.AutoSize = true;
            this.MandatoryLbl.Location = new System.Drawing.Point(6, 238);
            this.MandatoryLbl.Name = "MandatoryLbl";
            this.MandatoryLbl.Size = new System.Drawing.Size(135, 17);
            this.MandatoryLbl.TabIndex = 19;
            this.MandatoryLbl.Text = " (*) Mandatory fields";
            // 
            // MainMenuStrip
            // 
            this.MainMenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.MainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.MainMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.MainMenuStrip.Name = "MainMenuStrip";
            this.MainMenuStrip.Size = new System.Drawing.Size(663, 28);
            this.MainMenuStrip.TabIndex = 20;
            this.MainMenuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(46, 24);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(116, 26);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.usageToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(55, 24);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // usageToolStripMenuItem
            // 
            this.usageToolStripMenuItem.Name = "usageToolStripMenuItem";
            this.usageToolStripMenuItem.Size = new System.Drawing.Size(133, 26);
            this.usageToolStripMenuItem.Text = "Usage";
            this.usageToolStripMenuItem.Click += new System.EventHandler(this.usageToolStripMenuItem_Click);
            // 
            // SHA1LicenceRadioBtn
            // 
            this.SHA1LicenceRadioBtn.AutoSize = true;
            this.SHA1LicenceRadioBtn.Location = new System.Drawing.Point(217, 43);
            this.SHA1LicenceRadioBtn.Name = "SHA1LicenceRadioBtn";
            this.SHA1LicenceRadioBtn.Size = new System.Drawing.Size(65, 21);
            this.SHA1LicenceRadioBtn.TabIndex = 21;
            this.SHA1LicenceRadioBtn.Text = "SHA1";
            this.SHA1LicenceRadioBtn.UseVisualStyleBackColor = true;
            this.SHA1LicenceRadioBtn.CheckedChanged += new System.EventHandler(this.SHA1LicenceRadioBtn_CheckedChanged);
            // 
            // SHA256LicenceRadioBtn
            // 
            this.SHA256LicenceRadioBtn.AutoSize = true;
            this.SHA256LicenceRadioBtn.Checked = true;
            this.SHA256LicenceRadioBtn.Location = new System.Drawing.Point(333, 43);
            this.SHA256LicenceRadioBtn.Name = "SHA256LicenceRadioBtn";
            this.SHA256LicenceRadioBtn.Size = new System.Drawing.Size(81, 21);
            this.SHA256LicenceRadioBtn.TabIndex = 22;
            this.SHA256LicenceRadioBtn.TabStop = true;
            this.SHA256LicenceRadioBtn.Text = "SHA256";
            this.SHA256LicenceRadioBtn.UseVisualStyleBackColor = true;
            this.SHA256LicenceRadioBtn.CheckedChanged += new System.EventHandler(this.SHA256LicenceRadioBtn_CheckedChanged);
            // 
            // SigningAlgorithmLbl
            // 
            this.SigningAlgorithmLbl.AutoSize = true;
            this.SigningAlgorithmLbl.Location = new System.Drawing.Point(12, 45);
            this.SigningAlgorithmLbl.Name = "SigningAlgorithmLbl";
            this.SigningAlgorithmLbl.Size = new System.Drawing.Size(117, 17);
            this.SigningAlgorithmLbl.TabIndex = 23;
            this.SigningAlgorithmLbl.Text = "Signing algorithm";
            // 
            // ISVLicenseGeneratorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(663, 359);
            this.Controls.Add(this.SigningAlgorithmLbl);
            this.Controls.Add(this.SHA256LicenceRadioBtn);
            this.Controls.Add(this.SHA1LicenceRadioBtn);
            this.Controls.Add(this.MandatoryLbl);
            this.Controls.Add(this.UserCount);
            this.Controls.Add(this.ExpirationDatePicker);
            this.Controls.Add(this.BrowseBtn);
            this.Controls.Add(this.ResultLbl);
            this.Controls.Add(this.OutputTB);
            this.Controls.Add(this.GenerateBtn);
            this.Controls.Add(this.LicenseCodeLbl);
            this.Controls.Add(this.CustomerTenantLbl);
            this.Controls.Add(this.SerialNumberLbl);
            this.Controls.Add(this.ExpirationDateLbl);
            this.Controls.Add(this.UserCountLbl);
            this.Controls.Add(this.PathLbl);
            this.Controls.Add(this.SerialNumberTB);
            this.Controls.Add(this.CustomerTB);
            this.Controls.Add(this.LicenseCodeTB);
            this.Controls.Add(this.PathTB);
            this.Controls.Add(this.MainMenuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ISVLicenseGeneratorForm";
            this.Text = "ISV License Generator";
            ((System.ComponentModel.ISupportInitialize)(this.UserCount)).EndInit();
            this.MainMenuStrip.ResumeLayout(false);
            this.MainMenuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private System.Windows.Forms.RadioButton SHA1LicenceRadioBtn;
        private System.Windows.Forms.RadioButton SHA256LicenceRadioBtn;
        private System.Windows.Forms.Label SigningAlgorithmLbl;
    }
}

