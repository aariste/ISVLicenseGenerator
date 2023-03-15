using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Microsoft.Dynamics.AX.Framework.Tools.ModelManagement;
using System.Security.Cryptography.X509Certificates;

namespace ISVLicenseGeneratorCore
{
    public partial class ISVLicenseGeneratorForm : Form
    {
        AxUtilConfiguration config;

        public ISVLicenseGeneratorForm()
        {
            InitializeComponent();

            config = new AxUtilConfiguration();

            config.SignatureVersion = 2;
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

            X509Store store = new X509Store("My", StoreLocation.CurrentUser);
            store.Open(OpenFlags.ReadOnly | OpenFlags.OpenExistingOnly);

            X509Certificate2Collection collection = (X509Certificate2Collection)store.Certificates;
            X509Certificate2Collection fcollection = (X509Certificate2Collection)collection.Find(X509FindType.FindByTimeValid, DateTime.Now, false);
            X509Certificate2Collection scollection = X509Certificate2UI.SelectFromCollection(fcollection, "Certificate Select", "Select a certificate from the following list to sign the license", X509SelectionFlag.SingleSelection);

            Boolean result = util.GenerateLicense(scollection);

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
            string url = "https://github.com/aariste/ISVLicenseGenerator/blob/master/README.md";
            try
            {
                Process.Start(url);
            }
            catch
            {
                // hack because of this: https://github.com/dotnet/corefx/issues/10361
                if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                {
                    url = url.Replace("&", "^&");
                    Process.Start(new ProcessStartInfo("cmd", $"/c start {url}") { CreateNoWindow = true });
                }
                else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                {
                    Process.Start("xdg-open", url);
                }
                else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                {
                    Process.Start("open", url);
                }
                else
                {
                    throw;
                }
            }
        }
    }
}
