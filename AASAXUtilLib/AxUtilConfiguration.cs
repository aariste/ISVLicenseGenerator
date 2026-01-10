using System;

namespace AASAXUtilLib
{
    /// <summary>
    /// Configuration class containing license information and signature version settings.
    /// </summary>
    [Serializable]
    public class AxUtilConfiguration
    {
        /// <summary>
        /// Gets or sets the license information including customer details and expiration.
        /// </summary>
        public LicenseInfo LicenseInfo { get; set; }

        /// <summary>
        /// Gets or sets the signature version (typically 2 for SHA-256 signatures).
        /// </summary>
        public int SignatureVersion { get; set; }
    }
}