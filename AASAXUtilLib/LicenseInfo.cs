using System;

namespace AASAXUtilLib
{
    /// <summary>
    /// Data structure containing all information required to generate an ISV license.
    /// </summary>
    [Serializable]
    public struct LicenseInfo
    {
        /// <summary>
        /// Gets or sets the file path where the license file will be saved.
        /// </summary>
        public string FilePath { get; set; }

        /// <summary>
        /// Gets or sets the ISV license code from Microsoft Visual Studio.
        /// </summary>
        public string LicenseCode { get; set; }

        /// <summary>
        /// Gets or sets the customer's tenant name.
        /// </summary>
        public string Customer { get; set; }

        /// <summary>
        /// Gets or sets the customer's tenant ID (serial number).
        /// </summary>
        public string SerialNumber { get; set; }

        /// <summary>
        /// Gets or sets the optional expiration date for the license.
        /// </summary>
        public DateTime? ExpirationDate { get; set; }

        /// <summary>
        /// Gets or sets the optional maximum number of users allowed.
        /// </summary>
        public int? UserCount { get; set; }

        /// <summary>
        /// Gets or sets the timestamp when the license was generated.
        /// </summary>
        public DateTime Timestamp { get; set; }
    }
}
