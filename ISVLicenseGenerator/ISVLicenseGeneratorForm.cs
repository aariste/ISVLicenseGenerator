using System;
using System.Diagnostics;
using System.Windows.Forms;
using Microsoft.Dynamics.AX.Framework.Tools.ModelManagement;

namespace ISVLicenseGenerator
{
    public partial class ISVLicenseGeneratorForm : Form
    {
        AxUtilConfiguration config;

        public ISVLicenseGeneratorForm()
        {
            InitializeComponent();

            config = new AxUtilConfiguration();
        }

        private void GenerateBtn_Click(object sender, EventArgs e)
        {
            try
            {
                this.GenerateLicense();
            }
            catch (Exception ex)
            {
                OutputTB.Text = ex.Message;
            }
        }

        private Boolean ValidateFields()
        {
            return !String.IsNullOrEmpty(PathTB.Text) && !String.IsNullOrEmpty(LicenseCodeTB.Text) && !String.IsNullOrEmpty(CustomerTB.Text) && !String.IsNullOrEmpty(SerialNumberTB.Text);
        }

        private void BrowseBtn_Click(object sender, EventArgs e)
        {
            saveFileDialog.Filter = "TXT file|*.txt";
            saveFileDialog.Title = "Save license";
            saveFileDialog.ShowDialog();

            if (!String.IsNullOrEmpty(saveFileDialog.FileName))
            {
                System.IO.FileStream fs = (System.IO.FileStream)saveFileDialog.OpenFile();

                PathTB.Text = saveFileDialog.FileName;

                fs.Close();
            }
        }

        private void GenerateLicense()
        {
            LicenseInfo licenseInfo = new LicenseInfo
            {
                FilePath = PathTB.Text,
                LicenseCode = LicenseCodeTB.Text,
                Customer = CustomerTB.Text,
                SerialNumber = SerialNumberTB.Text,
                Timestamp = DateTime.Now
            };

            if (ExpirationDatePicker.Value != ExpirationDatePicker.MinDate)
            {
                licenseInfo.ExpirationDate = ExpirationDatePicker.Value;
            }

            if (UserCount.Value > 0)
            {
                licenseInfo.UserCount = (int)UserCount.Value;
            }

            if (!this.ValidateFields())
            {
                MessageBox.Show("Please fill all mandatory fields.");
                throw new System.MissingFieldException("Please fill all mandatory fields.");
            }
            
            AxUtilContext context = new AxUtilContext();

            config.LicenseInfo = licenseInfo;

            AxUtil util = new AxUtil(context, config);

            Boolean result = util.GenerateLicense();

            if (result == true)
            {
                MessageBox.Show(String.Format("License generated successfully. Saved at {0}", PathTB.Text));
                OutputTB.Text = String.Format("License generated successfully. Saved at {0}", PathTB.Text);
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void usageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.com/aariste/ISVLicenseGenerator/blob/master/README.md");
        }

        private void SHA1LicenceRadioBtn_CheckedChanged(object sender, EventArgs e)
        {
            SHA1LicenceRadioBtn.Checked = !SHA256LicenceRadioBtn.Checked;

            config.SignatureVersion = SHA1LicenceRadioBtn.Checked ? 1 : 0;
        }

        private void SHA256LicenceRadioBtn_CheckedChanged(object sender, EventArgs e)
        {
            SHA256LicenceRadioBtn.Checked = !SHA1LicenceRadioBtn.Checked;
            
            config.SignatureVersion = SHA256LicenceRadioBtn.Checked ? 0 : 1;
        }
    }
}
