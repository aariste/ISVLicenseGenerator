using Microsoft.Dynamics.AX.Framework.Tools.ModelManagement.Properties;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Xml.Linq;

namespace Microsoft.Dynamics.AX.Framework.Tools.ModelManagement
{
    internal class LicenseGenerator
    {
        private LicenseInfo licenseInfo;
        private AxUtilContext context;
        private string formattedDate;
        private string formattedUserCount;
        private string formattedTimestamp;
        private const byte SignatureVersion = 1;

        internal LicenseGenerator(LicenseInfo licenseInfo, AxUtilContext context)
        {
            this.licenseInfo = licenseInfo;
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
          dateTime.Month.ToString((IFormatProvider) numberFormat),
          ".",
          null
                };
                num = dateTime.Year;
                strArray[4] = num.ToString((IFormatProvider)numberFormat);
                this.formattedDate = string.Concat(strArray);
            }
            int? userCount = this.licenseInfo.UserCount;
            if (userCount.HasValue)
            {
                userCount = this.licenseInfo.UserCount;
                num = 0;
                if ((userCount.GetValueOrDefault() > num ? (userCount.HasValue ? 1 : 0) : 0) != 0)
                {
                    userCount = this.licenseInfo.UserCount;
                    num = userCount.Value;
                    this.formattedUserCount = num.ToString((IFormatProvider)numberFormat);
                    goto label_6;
                }
            }
            this.formattedUserCount = string.Empty;
        label_6:
            string[] strArray1 = new string[5];
            num = licenseInfo.Timestamp.Day;
            strArray1[0] = num.ToString((IFormatProvider)numberFormat);
            strArray1[1] = ".";
            DateTime timestamp = licenseInfo.Timestamp;
            num = timestamp.Month;
            strArray1[2] = num.ToString((IFormatProvider)numberFormat);
            strArray1[3] = ".";
            timestamp = licenseInfo.Timestamp;
            num = timestamp.Year;
            strArray1[4] = num.ToString((IFormatProvider)numberFormat);
            this.formattedTimestamp = string.Concat(strArray1);
        }

        internal bool GenerateLicense()
        {
            X509Certificate2 certificate = this.LoadCertificate();
            if (certificate == null)
                return false;
            return this.GenerateLicenseFile(this.GenerateSignature(certificate), certificate);
        }

        internal bool GenerateLicense(X509Certificate2 usbCertificate)
        {
            X509Certificate2 certificate = usbCertificate;
            if (certificate == null)
                return false;
            return this.GenerateLicenseFile(this.GenerateSignature(certificate), certificate);
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
                xelement1.Add((object)new XAttribute((XName)"certificateSerialNumer", (object)certificate.SerialNumber));
                xelement1.Add((object)new XAttribute((XName)"licensecode", (object)this.licenseInfo.LicenseCode));
                xelement1.Add((object)new XAttribute((XName)"serialnumber", (object)this.licenseInfo.SerialNumber));
                xelement1.Add((object)new XAttribute((XName)"customer", (object)this.licenseInfo.Customer));
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
                    XAttribute xattribute = new XAttribute(name, (object)local);
                    xelement2.Add((object)xattribute);
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

        private X509Certificate2 LoadCertificate()
        {
            X509Certificate2 certificate;
            try
            {
                certificate = new X509Certificate2(this.licenseInfo.CertificatePath, this.licenseInfo.Password);
            }
            catch (CryptographicException ex)
            {
                this.context.ReportError(string.Format((IFormatProvider)CultureInfo.CurrentCulture, Resources.CertificateLoadFailure, (object)ex.Message));
                return (X509Certificate2)null;
            }
            if (!this.ValidateCertificate(certificate))
                return (X509Certificate2)null;
            return certificate;
        }

        [SuppressMessage("Microsoft.Cryptographic.Standard", "CA5354:SHA1CannotBeUsed", Justification = "Supporting SHA1 due to business decisions that industry has not taken SHA2 widely, exception will be fired on this case.")]
        private string GenerateSignature(X509Certificate2 certificate)
        {
            byte[] bytes = new UnicodeEncoding().GetBytes((this.licenseInfo.Customer + this.licenseInfo.SerialNumber + this.formattedDate + this.licenseInfo.LicenseCode + this.formattedUserCount + this.formattedTimestamp).ToUpperInvariant());
            RSACryptoServiceProvider privateKey = certificate.PrivateKey as RSACryptoServiceProvider;
            //SecurityManagementEventSource.EventWriteHashingCallStackMethod("LicenseGenerator_GenerateSignature", "SHA1", 160, string.Empty, Environment.StackTrace);
            byte[] buffer = bytes;
            SHA1Managed shA1Managed = new SHA1Managed();
            byte[] numArray1 = privateKey.SignData(buffer, (object)shA1Managed);
            byte[] inArray = new byte[((IEnumerable<byte>)numArray1).Count<byte>() + 1];
            int num1 = 0;
            byte[] numArray2 = inArray;
            int index = num1;
            int num2 = index + 1;
            numArray2[index] = (byte)1;
            foreach (byte num3 in ((IEnumerable<byte>)numArray1).Reverse<byte>())
                inArray[num2++] = num3;
            return Convert.ToBase64String(inArray);
        }
    }
}
