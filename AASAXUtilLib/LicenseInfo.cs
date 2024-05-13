using System;

namespace AASAXUtilLib
{
    [Serializable]
    public struct LicenseInfo
    {        

        public string FilePath { get; set; }

        public string CertificatePath { get; set; }

        public string LicenseCode { get; set; }

        public string Customer { get; set; }

        public string SerialNumber { get; set; }

        public DateTime? ExpirationDate { get; set; }

        public int? UserCount { get; set; }

        public DateTime Timestamp { get; set; }

    }
}
