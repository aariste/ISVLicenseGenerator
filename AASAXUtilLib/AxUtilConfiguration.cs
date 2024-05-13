using System;

namespace AASAXUtilLib
{
    [Serializable]
    public class AxUtilConfiguration
    {
        public LicenseInfo LicenseInfo { get; set; }

        public int SignatureVersion { get; set; }
    }
}