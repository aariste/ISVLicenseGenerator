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
            ((System.ComponentModel.ISupportInitialize)UserCount).BeginInit();
            MainMenuStrip.SuspendLayout();
            SuspendLayout();
            // 
            // PathTB
            // 
            PathTB.BackColor = System.Drawing.SystemColors.Control;
            PathTB.Location = new System.Drawing.Point(217, 45);
            PathTB.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            PathTB.Name = "PathTB";
            PathTB.ReadOnly = true;
            PathTB.Size = new System.Drawing.Size(330, 27);
            PathTB.TabIndex = 0;
            // 
            // LicenseCodeTB
            // 
            LicenseCodeTB.Location = new System.Drawing.Point(217, 80);
            LicenseCodeTB.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            LicenseCodeTB.Name = "LicenseCodeTB";
            LicenseCodeTB.Size = new System.Drawing.Size(430, 27);
            LicenseCodeTB.TabIndex = 1;
            // 
            // CustomerTB
            // 
            CustomerTB.Location = new System.Drawing.Point(217, 115);
            CustomerTB.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            CustomerTB.Name = "CustomerTB";
            CustomerTB.Size = new System.Drawing.Size(430, 27);
            CustomerTB.TabIndex = 2;
            // 
            // SerialNumberTB
            // 
            SerialNumberTB.Location = new System.Drawing.Point(217, 149);
            SerialNumberTB.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            SerialNumberTB.Name = "SerialNumberTB";
            SerialNumberTB.Size = new System.Drawing.Size(430, 27);
            SerialNumberTB.TabIndex = 3;
            // 
            // PathLbl
            // 
            PathLbl.AutoSize = true;
            PathLbl.Location = new System.Drawing.Point(11, 48);
            PathLbl.Name = "PathLbl";
            PathLbl.Size = new System.Drawing.Size(57, 20);
            PathLbl.TabIndex = 6;
            PathLbl.Text = "Path (*)";
            // 
            // UserCountLbl
            // 
            UserCountLbl.AutoSize = true;
            UserCountLbl.Location = new System.Drawing.Point(11, 223);
            UserCountLbl.Name = "UserCountLbl";
            UserCountLbl.Size = new System.Drawing.Size(79, 20);
            UserCountLbl.TabIndex = 8;
            UserCountLbl.Text = "User count";
            // 
            // ExpirationDateLbl
            // 
            ExpirationDateLbl.AutoSize = true;
            ExpirationDateLbl.Location = new System.Drawing.Point(11, 192);
            ExpirationDateLbl.Name = "ExpirationDateLbl";
            ExpirationDateLbl.Size = new System.Drawing.Size(110, 20);
            ExpirationDateLbl.TabIndex = 9;
            ExpirationDateLbl.Text = "Expiration date";
            // 
            // SerialNumberLbl
            // 
            SerialNumberLbl.AutoSize = true;
            SerialNumberLbl.Location = new System.Drawing.Point(11, 153);
            SerialNumberLbl.Name = "SerialNumberLbl";
            SerialNumberLbl.Size = new System.Drawing.Size(121, 20);
            SerialNumberLbl.TabIndex = 10;
            SerialNumberLbl.Text = "Serial number (*)";
            // 
            // CustomerTenantLbl
            // 
            CustomerTenantLbl.AutoSize = true;
            CustomerTenantLbl.Location = new System.Drawing.Point(11, 119);
            CustomerTenantLbl.Name = "CustomerTenantLbl";
            CustomerTenantLbl.Size = new System.Drawing.Size(138, 20);
            CustomerTenantLbl.TabIndex = 11;
            CustomerTenantLbl.Text = "Customer tenant (*)";
            // 
            // LicenseCodeLbl
            // 
            LicenseCodeLbl.AutoSize = true;
            LicenseCodeLbl.Location = new System.Drawing.Point(11, 83);
            LicenseCodeLbl.Name = "LicenseCodeLbl";
            LicenseCodeLbl.Size = new System.Drawing.Size(114, 20);
            LicenseCodeLbl.TabIndex = 12;
            LicenseCodeLbl.Text = "License code (*)";
            // 
            // GenerateBtn
            // 
            GenerateBtn.Location = new System.Drawing.Point(544, 256);
            GenerateBtn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            GenerateBtn.Name = "GenerateBtn";
            GenerateBtn.Size = new System.Drawing.Size(103, 40);
            GenerateBtn.TabIndex = 13;
            GenerateBtn.Text = "Generate";
            GenerateBtn.UseVisualStyleBackColor = true;
            GenerateBtn.Click += GenerateBtn_Click;
            // 
            // OutputTB
            // 
            OutputTB.Enabled = false;
            OutputTB.Location = new System.Drawing.Point(11, 313);
            OutputTB.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            OutputTB.Multiline = true;
            OutputTB.Name = "OutputTB";
            OutputTB.ReadOnly = true;
            OutputTB.Size = new System.Drawing.Size(635, 79);
            OutputTB.TabIndex = 14;
            // 
            // ResultLbl
            // 
            ResultLbl.AutoSize = true;
            ResultLbl.Location = new System.Drawing.Point(11, 288);
            ResultLbl.Name = "ResultLbl";
            ResultLbl.Size = new System.Drawing.Size(49, 20);
            ResultLbl.TabIndex = 15;
            ResultLbl.Text = "Result";
            // 
            // BrowseBtn
            // 
            BrowseBtn.Location = new System.Drawing.Point(553, 43);
            BrowseBtn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            BrowseBtn.Name = "BrowseBtn";
            BrowseBtn.Size = new System.Drawing.Size(94, 29);
            BrowseBtn.TabIndex = 16;
            BrowseBtn.Text = "Browse...";
            BrowseBtn.UseVisualStyleBackColor = true;
            BrowseBtn.Click += BrowseBtn_Click;
            // 
            // ExpirationDatePicker
            // 
            ExpirationDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            ExpirationDatePicker.Location = new System.Drawing.Point(217, 185);
            ExpirationDatePicker.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            ExpirationDatePicker.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            ExpirationDatePicker.Name = "ExpirationDatePicker";
            ExpirationDatePicker.Size = new System.Drawing.Size(430, 27);
            ExpirationDatePicker.TabIndex = 17;
            ExpirationDatePicker.Value = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            // 
            // UserCount
            // 
            UserCount.Location = new System.Drawing.Point(217, 219);
            UserCount.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            UserCount.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            UserCount.Name = "UserCount";
            UserCount.Size = new System.Drawing.Size(430, 27);
            UserCount.TabIndex = 18;
            // 
            // MandatoryLbl
            // 
            MandatoryLbl.AutoSize = true;
            MandatoryLbl.Location = new System.Drawing.Point(6, 256);
            MandatoryLbl.Name = "MandatoryLbl";
            MandatoryLbl.Size = new System.Drawing.Size(145, 20);
            MandatoryLbl.TabIndex = 19;
            MandatoryLbl.Text = " (*) Mandatory fields";
            // 
            // MainMenuStrip
            // 
            MainMenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            MainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { fileToolStripMenuItem, helpToolStripMenuItem });
            MainMenuStrip.Location = new System.Drawing.Point(0, 0);
            MainMenuStrip.Name = "MainMenuStrip";
            MainMenuStrip.Padding = new System.Windows.Forms.Padding(6, 3, 0, 3);
            MainMenuStrip.Size = new System.Drawing.Size(663, 30);
            MainMenuStrip.TabIndex = 20;
            MainMenuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { exitToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new System.Drawing.Size(46, 24);
            fileToolStripMenuItem.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new System.Drawing.Size(116, 26);
            exitToolStripMenuItem.Text = "Exit";
            exitToolStripMenuItem.Click += exitToolStripMenuItem_Click;
            // 
            // helpToolStripMenuItem
            // 
            helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { usageToolStripMenuItem });
            helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            helpToolStripMenuItem.Size = new System.Drawing.Size(55, 24);
            helpToolStripMenuItem.Text = "Help";
            // 
            // usageToolStripMenuItem
            // 
            usageToolStripMenuItem.Name = "usageToolStripMenuItem";
            usageToolStripMenuItem.Size = new System.Drawing.Size(133, 26);
            usageToolStripMenuItem.Text = "Usage";
            usageToolStripMenuItem.Click += usageToolStripMenuItem_Click;
            // 
            // ISVLicenseGeneratorForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(663, 412);
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
            Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
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
    }
}

