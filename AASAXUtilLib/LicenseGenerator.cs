﻿using Azure.Identity;
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
            int num;
            if (this.licenseInfo.ExpirationDate.HasValue)
            {
                DateTime dateTime = this.licenseInfo.ExpirationDate.Value;
                string[] strArray = new string[5]
                {
                  dateTime.Day.ToString((IFormatProvider) numberFormat),
                  ".",
                  null,
                  null,
                  null
                };
                num = dateTime.Month;
                strArray[2] = num.ToString((IFormatProvider)numberFormat);
                strArray[3] = ".";
                num = dateTime.Year;
                strArray[4] = num.ToString((IFormatProvider)numberFormat);
                this.formattedDate = string.Concat(strArray);
            }
            if (this.licenseInfo.UserCount.HasValue)
            {
                int? userCount = this.licenseInfo.UserCount;
                num = 0;
                if (userCount.GetValueOrDefault() > num & userCount.HasValue)
                {
                    num = this.licenseInfo.UserCount.Value;
                    this.formattedUserCount = num.ToString((IFormatProvider)numberFormat);
                    goto label_6;
                }
            }
            this.formattedUserCount = string.Empty;
        label_6:            
            string[] strArray1 = new string[5];
            num = this.licenseInfo.Timestamp.Day;
            strArray1[0] = num.ToString((IFormatProvider)numberFormat);
            strArray1[1] = ".";
            DateTime timestamp = this.licenseInfo.Timestamp;
            num = timestamp.Month;
            strArray1[2] = num.ToString((IFormatProvider)numberFormat);
            strArray1[3] = ".";
            timestamp = this.licenseInfo.Timestamp;
            num = timestamp.Year;
            strArray1[4] = num.ToString((IFormatProvider)numberFormat);
            this.formattedTimestamp = string.Concat(strArray1);
        }

        internal bool GenerateLicense(X509Certificate2 usbCertificate)
        {
            X509Certificate2 certificate = usbCertificate;
            return certificate != null && this.GenerateLicenseFile(this.GenerateSignature(certificate), certificate);
        }

        internal bool GenerateLicenseKeyVault(string keyVaultDNS, string keyName, string tenantId, string clientId, string clientSecret)
        {
            return this.GenerateLicenseFileKeyVault(keyVaultDNS, keyName, tenantId, clientId, clientSecret);
        }

        private bool ValidateCertificate(X509Certificate2 certificate)
        {
            if (certificate.HasPrivateKey)
                return true;
            this.context.ReportError(string.Format((IFormatProvider)CultureInfo.CurrentCulture, Resources.CertificateLoadFailure, (object)Resources.MissingPrivateKey));
            return false;
        }

        private bool GenerateLicenseFile(string signature, X509Certificate2 certificate)
        {
            try
            {
                XElement xelement1 = new XElement((XName)"License");
                xelement1.Add((object)new XAttribute((XName)"version", (object)this.version));
                xelement1.Add((object)new XAttribute((XName)"certificateSerialNumer", (object)certificate.SerialNumber));
                xelement1.Add((object)new XAttribute((XName)"licensecode", (object)this.licenseInfo.LicenseCode));
                xelement1.Add((object)new XAttribute((XName)"serialnumber", (object)this.licenseInfo.SerialNumber));
                if (this.licenseInfo.ExpirationDate.HasValue)
                    xelement1.Add((object)new XAttribute((XName)"expiration", (object)this.formattedDate));
                int? userCount = this.licenseInfo.UserCount;
                if (userCount.HasValue)
                {
                    XElement xelement2 = xelement1;
                    XName name = (XName)"usercount";
                    userCount = this.licenseInfo.UserCount;
                    // ISSUE: variable of a boxed type
                    int local = (int)userCount.Value;
                    XAttribute content = new XAttribute(name, (object)local);
                    xelement2.Add((object)content);
                }
                xelement1.Add((object)new XAttribute((XName)"timestamp", (object)this.formattedTimestamp));
                xelement1.Add((object)new XAttribute((XName)nameof(signature), (object)signature));
                xelement1.Save(this.licenseInfo.FilePath);
            }
            catch (IOException ex)
            {
                this.context.ReportError(string.Format((IFormatProvider)CultureInfo.CurrentCulture, Resources.FailToCreateLicenseFile, (object)ex.Message));
                return false;
            }
            return true;
        }

        private bool GenerateLicenseFileKeyVault(string keyVaultDNS, string keyName, string tenantId, string clientId, string clientSecret)
        {
            try
            {
                var credential = new ClientSecretCredential(tenantId, clientId, clientSecret);

                //var credential = new DefaultAzureCredential();                
                var client = new CertificateClient(new Uri(keyVaultDNS), credential);
                KeyVaultCertificateWithPolicy certificate = client.GetCertificate(keyName);

                // Extract the serial number                
                string serialNumber = certificate.Properties.X509ThumbprintString.ToUpper();

                string signature = this.GenerateSignatureKeyVault(credential, keyVaultDNS, keyName);

                XElement xelement1 = new XElement((XName)"License");
                xelement1.Add((object)new XAttribute((XName)"version", (object)this.version));
                xelement1.Add((object)new XAttribute((XName)"certificateSerialNumer", (object)serialNumber));
                xelement1.Add((object)new XAttribute((XName)"licensecode", (object)this.licenseInfo.LicenseCode));
                xelement1.Add((object)new XAttribute((XName)"serialnumber", (object)this.licenseInfo.SerialNumber));
                if (this.licenseInfo.ExpirationDate.HasValue)
                    xelement1.Add((object)new XAttribute((XName)"expiration", (object)this.formattedDate));
                int? userCount = this.licenseInfo.UserCount;
                if (userCount.HasValue)
                {
                    XElement xelement2 = xelement1;
                    XName name = (XName)"usercount";
                    userCount = this.licenseInfo.UserCount;
                    // ISSUE: variable of a boxed type
                    int local = (int)userCount.Value;
                    XAttribute content = new XAttribute(name, (object)local);
                    xelement2.Add((object)content);
                }
                xelement1.Add((object)new XAttribute((XName)"timestamp", (object)this.formattedTimestamp));
                xelement1.Add((object)new XAttribute((XName)nameof(signature), (object)signature));
                xelement1.Save(this.licenseInfo.FilePath);
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
            byte[] inArray = new byte[((IEnumerable<byte>)numArray1).Count<byte>() + 1];
            int num1 = 0;
            byte[] numArray2 = inArray;
            int index = num1;
            int num2 = index + 1;
            int num3 = (int)Convert.ToByte(this.SignatureVersion);
            numArray2[index] = (byte)num3;
            foreach (byte num4 in ((IEnumerable<byte>)numArray1).Reverse<byte>())
                inArray[num2++] = num4;
            return Convert.ToBase64String(inArray);
        }

        private string GenerateSignatureKeyVault(ClientSecretCredential credential, string keyVaultDNS, string keyName)
        {
            byte[] bytes = new UnicodeEncoding().GetBytes((this.licenseInfo.SerialNumber + this.formattedDate + this.licenseInfo.LicenseCode + this.formattedUserCount + this.formattedTimestamp + this.version).ToUpperInvariant());
            var client = new KeyClient(new Uri(keyVaultDNS), credential);
            var cryptoClient = client.GetCryptographyClient(keyName);

            // Sign the data
            SignResult signResult = cryptoClient.SignData(SignatureAlgorithm.RS256, bytes);
            byte[] signature = signResult.Signature;
            
            byte[] numArray1 = signature;
            byte[] inArray = new byte[((IEnumerable<byte>)numArray1).Count<byte>() + 1];
            int num1 = 0;
            byte[] numArray2 = inArray;
            int index = num1;
            int num2 = index + 1;
            int num3 = (int)Convert.ToByte(this.SignatureVersion);
            numArray2[index] = (byte)num3;
            
            foreach (byte num4 in ((IEnumerable<byte>)numArray1).Reverse<byte>())
                inArray[num2++] = num4;

            return Convert.ToBase64String(inArray);
        }

        private byte[] SignData(RSA rsa, byte[] data)
        {
            try
            {
                return rsa.SignData(data, HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);
            }
            catch
            {
                throw;
            }
        }
    }
}
