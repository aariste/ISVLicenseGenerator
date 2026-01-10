using Azure.Identity;
using Azure.Security.KeyVault.Certificates;
using Azure.Security.KeyVault.Keys;
using Azure.Security.KeyVault.Keys.Cryptography;
using Microsoft.Dynamics.AX.Framework.Tools.ModelManagement.Properties;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AASAXUtilLib
{
    internal class LicenseGenerator
    {
        private LicenseInfo licenseInfo;
        private AxUtilContext context;
        private string formattedDate;
        private string formattedUserCount;
        private string formattedTimestamp;
        private string version = "2";

        internal int SignatureVersion { get; set; }

        internal LicenseGenerator(AxUtilConfiguration configuration, AxUtilContext context)
        {
            this.licenseInfo = configuration.LicenseInfo;
            this.context = context;
            NumberFormatInfo numberFormat = CultureInfo.InvariantCulture.NumberFormat;
            if (this.licenseInfo.ExpirationDate.HasValue)
            {
                DateTime dateTime = this.licenseInfo.ExpirationDate.Value;
                this.formattedDate = $"{dateTime.Day.ToString(numberFormat)}.{dateTime.Month.ToString(numberFormat)}.{dateTime.Year.ToString(numberFormat)}";
            }

            if (this.licenseInfo.UserCount.HasValue && this.licenseInfo.UserCount.Value > 0)
            {
                this.formattedUserCount = this.licenseInfo.UserCount.Value.ToString(numberFormat);
            }
            else
            {
                this.formattedUserCount = string.Empty;
            }

            DateTime timestamp = this.licenseInfo.Timestamp;
            this.formattedTimestamp = $"{timestamp.Day.ToString(numberFormat)}.{timestamp.Month.ToString(numberFormat)}.{timestamp.Year.ToString(numberFormat)}";
        }

        internal bool GenerateLicense(X509Certificate2 usbCertificate)
        {
            X509Certificate2 certificate = usbCertificate;
            if (certificate == null)
                return false;

            if (!this.ValidateCertificate(certificate))
                return false;

            return this.GenerateLicenseFile(this.GenerateSignature(certificate), certificate);
        }

        internal async Task<bool> GenerateLicenseKeyVaultAsync(string keyVaultDNS, string keyName, string tenantId, string clientId, string clientSecret)
        {
            return await this.GenerateLicenseFileKeyVaultAsync(keyVaultDNS, keyName, tenantId, clientId, clientSecret);
        }

        private bool ValidateCertificate(X509Certificate2 certificate)
        {
            if (certificate.HasPrivateKey)
                return true;
            this.context.ReportError(string.Format((IFormatProvider)CultureInfo.CurrentCulture, Resources.CertificateLoadFailure, (object)Resources.MissingPrivateKey));
            return false;
        }

        private XElement BuildLicenseXml(string signature, string certificateIdentifier)
        {
            XElement xelement = new XElement((XName)"License");
            xelement.Add((object)new XAttribute((XName)"version", (object)this.version));
            xelement.Add((object)new XAttribute((XName)"certificateSerialNumber", (object)certificateIdentifier));
            xelement.Add((object)new XAttribute((XName)"licensecode", (object)this.licenseInfo.LicenseCode));
            xelement.Add((object)new XAttribute((XName)"serialnumber", (object)this.licenseInfo.SerialNumber));

            if (this.licenseInfo.ExpirationDate.HasValue)
                xelement.Add((object)new XAttribute((XName)"expiration", (object)this.formattedDate));

            if (this.licenseInfo.UserCount.HasValue)
                xelement.Add((object)new XAttribute((XName)"usercount", (object)this.licenseInfo.UserCount.Value));

            xelement.Add((object)new XAttribute((XName)"timestamp", (object)this.formattedTimestamp));
            xelement.Add((object)new XAttribute((XName)nameof(signature), (object)signature));

            return xelement;
        }

        private bool GenerateLicenseFile(string signature, X509Certificate2 certificate)
        {
            try
            {
                XElement licenseXml = BuildLicenseXml(signature, certificate.SerialNumber);
                licenseXml.Save(this.licenseInfo.FilePath);
            }
            catch (IOException ex)
            {
                this.context.ReportError(string.Format((IFormatProvider)CultureInfo.CurrentCulture, Resources.FailToCreateLicenseFile, (object)ex.Message));
                return false;
            }
            return true;
        }

        private async Task<bool> GenerateLicenseFileKeyVaultAsync(string keyVaultDNS, string keyName, string tenantId, string clientId, string clientSecret)
        {
            try
            {
                var credential = new ClientSecretCredential(tenantId, clientId, clientSecret);

                //var credential = new DefaultAzureCredential();
                var client = new CertificateClient(new Uri(keyVaultDNS), credential);
                KeyVaultCertificateWithPolicy certificate = await client.GetCertificateAsync(keyName);

                // Extract the serial number
                string serialNumber = certificate.Properties.X509ThumbprintString.ToUpper();

                string signature = await this.GenerateSignatureKeyVaultAsync(credential, keyVaultDNS, keyName);

                XElement licenseXml = BuildLicenseXml(signature, serialNumber);
                licenseXml.Save(this.licenseInfo.FilePath);
            }
            catch (IOException ex)
            {
                this.context.ReportError(string.Format((IFormatProvider)CultureInfo.CurrentCulture, Resources.FailToCreateLicenseFile, (object)ex.Message));
                return false;
            }
            return true;
        }        

        private string GenerateSignature(X509Certificate2 certificate)
        {
            byte[] bytes = new UnicodeEncoding().GetBytes((this.licenseInfo.SerialNumber + this.formattedDate + this.licenseInfo.LicenseCode + this.formattedUserCount + this.formattedTimestamp + this.version).ToUpperInvariant());
            RSA rsa = certificate.GetRSAPrivateKey();
            byte[] numArray1 = this.SignData(rsa, bytes);
            byte[] inArray = new byte[numArray1.Length + 1];
            inArray[0] = (byte)this.SignatureVersion;

            // Reverse the signature bytes
            Array.Reverse(numArray1);
            Array.Copy(numArray1, 0, inArray, 1, numArray1.Length);

            return Convert.ToBase64String(inArray);
        }

        private async Task<string> GenerateSignatureKeyVaultAsync(ClientSecretCredential credential, string keyVaultDNS, string keyName)
        {
            byte[] bytes = new UnicodeEncoding().GetBytes((this.licenseInfo.SerialNumber + this.formattedDate + this.licenseInfo.LicenseCode + this.formattedUserCount + this.formattedTimestamp + this.version).ToUpperInvariant());
            var client = new KeyClient(new Uri(keyVaultDNS), credential);
            var cryptoClient = client.GetCryptographyClient(keyName);

            // Sign the data
            SignResult signResult = await cryptoClient.SignDataAsync(SignatureAlgorithm.RS256, bytes);
            byte[] signature = signResult.Signature;

            byte[] inArray = new byte[signature.Length + 1];
            inArray[0] = (byte)this.SignatureVersion;

            // Reverse the signature bytes
            Array.Reverse(signature);
            Array.Copy(signature, 0, inArray, 1, signature.Length);

            return Convert.ToBase64String(inArray);
        }

        private byte[] SignData(RSA rsa, byte[] data)
        {
            return rsa.SignData(data, HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);
        }
    }
}
