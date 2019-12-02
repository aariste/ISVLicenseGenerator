using System;
using System.Globalization;

namespace Microsoft.Dynamics.AX.Framework.Tools.ModelManagement
{
    [Serializable]
    public struct LicenseInfo
    {
        public LicenseInfo(
          string filePath,
          string certificatePath,
          string licenseCode,
          string customer,
          string serialNumber,
          DateTime? expirationDate,
          int? userCount,
          string password)
        {
            this.FilePath = filePath;
            this.CertificatePath = certificatePath;
            this.LicenseCode = licenseCode;
            this.Customer = customer;
            this.SerialNumber = serialNumber;
            this.ExpirationDate = expirationDate;
            this.UserCount = userCount;
            this.Password = password;
            this.Timestamp = DateTime.Now;
        }

        public string FilePath { get; set; }

        public string CertificatePath { get; set; }

        public string LicenseCode { get; set; }

        public string Customer { get; set; }

        public string SerialNumber { get; set; }

        public DateTime? ExpirationDate { get; set; }

        public int? UserCount { get; set; }

        public string Password { get; set; }

        public DateTime Timestamp { get; set; }

        public static bool operator ==(LicenseInfo LicenseInfo1, LicenseInfo LicenseInfo2)
        {
            if (LicenseInfo1.FilePath == LicenseInfo2.FilePath && LicenseInfo1.CertificatePath == LicenseInfo2.CertificatePath && (LicenseInfo1.Customer == LicenseInfo2.Customer && LicenseInfo1.SerialNumber == LicenseInfo2.SerialNumber))
            {
                DateTime? expirationDate1 = LicenseInfo1.ExpirationDate;
                DateTime? expirationDate2 = LicenseInfo2.ExpirationDate;
                if ((expirationDate1.HasValue == expirationDate2.HasValue ? (expirationDate1.HasValue ? (expirationDate1.GetValueOrDefault() == expirationDate2.GetValueOrDefault() ? 1 : 0) : 1) : 0) != 0)
                {
                    int? userCount1 = LicenseInfo1.UserCount;
                    int? userCount2 = LicenseInfo2.UserCount;
                    if ((userCount1.GetValueOrDefault() == userCount2.GetValueOrDefault() ? (userCount1.HasValue == userCount2.HasValue ? 1 : 0) : 0) != 0 && LicenseInfo1.Timestamp == LicenseInfo2.Timestamp && LicenseInfo1.Password == LicenseInfo2.Password)
                        return LicenseInfo1.LicenseCode == LicenseInfo2.LicenseCode;
                }
            }
            return false;
        }

        public static bool operator !=(LicenseInfo LicenseInfo1, LicenseInfo LicenseInfo2)
        {
            return !(LicenseInfo1 == LicenseInfo2);
        }

        public override bool Equals(object obj)
        {
            if (obj == null || this.GetType() != obj.GetType())
                return false;
            return this == (LicenseInfo)obj;
        }

        public override int GetHashCode()
        {
            return this.FilePath.GetHashCode() ^ this.CertificatePath.GetHashCode() ^ this.Customer.GetHashCode() ^ this.SerialNumber.GetHashCode() ^ this.ExpirationDate.GetHashCode() ^ this.UserCount.GetHashCode() ^ this.Timestamp.GetHashCode() ^ this.Password.GetHashCode() ^ this.LicenseCode.GetHashCode();
        }

        public override string ToString()
        {
            CultureInfo invariantCulture = CultureInfo.InvariantCulture;
            object[] objArray = new object[9]
            {
        (object) this.LicenseCode,
        (object) this.Customer,
        (object) this.SerialNumber,
        (object) this.FilePath,
        (object) this.CertificatePath,
        (object) this.Password,
        null,
        null,
        null
            };
            DateTime timestamp;
            string str1;
            if (!this.ExpirationDate.HasValue)
            {
                str1 = "[None]";
            }
            else
            {
                timestamp = this.ExpirationDate.Value;
                str1 = timestamp.ToLongDateString();
            }
            objArray[6] = (object)str1;
            string str2;
            if (!this.UserCount.HasValue)
                str2 = "[None]";
            else
                str2 = string.Format((IFormatProvider)CultureInfo.InvariantCulture, "{0}", (object)this.UserCount.Value);
            objArray[7] = (object)str2;
            timestamp = this.Timestamp;
            objArray[8] = (object)timestamp.ToLongDateString();
            return string.Format((IFormatProvider)invariantCulture, "LicenseCode: {0}, Customer: {1}, SerialNumber: {2}, FilePath: {3}, CertificatePath: {4}, Password: {5}, ExpirationDate: {6}, UserCount: {7}, Timestamp: {8}", objArray);
        }
    }
}
