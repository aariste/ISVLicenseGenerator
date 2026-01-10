using System;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace AASAXUtilLib
{
    /// <summary>
    /// Main utility class for generating ISV licenses for Microsoft Dynamics 365 Finance and Operations.
    /// Supports both USB token-based certificates and Azure Key Vault HSM signing.
    /// </summary>
    public class AxUtil
    {
        private AxUtilConfiguration config;
        private AxUtilContext context;

        /// <summary>
        /// Initializes a new instance of the AxUtil class.
        /// </summary>
        public AxUtil()
        {
        }

        /// <summary>
        /// Initializes a new instance of the AxUtil class with specified context and configuration.
        /// </summary>
        /// <param name="context">The context for error reporting.</param>
        /// <param name="config">The configuration containing license information and signature version.</param>
        /// <exception cref="ArgumentNullException">Thrown when context or config is null.</exception>
        public AxUtil(AxUtilContext context, AxUtilConfiguration config)
          : this()
        {
            ValidateContextAndConfigNotNull(context, config);
            Context = context;
            Config = config;
        }

        /// <summary>
        /// Gets or sets the context for error reporting.
        /// </summary>
        /// <exception cref="ArgumentNullException">Thrown when setting a null value.</exception>
        public AxUtilContext Context
        {
            get
            {
                return context;
            }
            set
            {
                ValidateContextNotNull(value);
                context = value;
            }
        }

        /// <summary>
        /// Gets or sets the configuration containing license information and signature version.
        /// </summary>
        /// <exception cref="ArgumentNullException">Thrown when setting a null value.</exception>
        public AxUtilConfiguration Config
        {
            get
            {
                return config;
            }
            set
            {
                ValidateConfigNotNull(value);
                config = value;
            }
        }

        /// <summary>
        /// Generates a license file using the first certificate from the collection.
        /// </summary>
        /// <param name="scollection">The certificate collection containing at least one certificate.</param>
        /// <returns>True if the license was generated successfully; otherwise, false.</returns>
        /// <exception cref="ArgumentException">Thrown when the collection is empty.</exception>
        public bool GenerateLicense(X509Certificate2Collection scollection)
        {
            if (scollection.Count == 0)
            {
                throw new ArgumentException("No certificate loaded.", nameof(scollection));
            }

            // Use the first certificate from the collection
            X509Certificate2 certificate = scollection[0];
            return new LicenseGenerator(config, context).GenerateLicense(certificate);
        }

        /// <summary>
        /// Generates a license file using the specified certificate from a USB token.
        /// </summary>
        /// <param name="certificate">The X509 certificate containing the private key for signing.</param>
        /// <returns>True if the license was generated successfully; otherwise, false.</returns>
        public bool GenerateLicense(X509Certificate2 certificate)
        {
            return new LicenseGenerator(config, context).GenerateLicense(certificate);
        }

        /// <summary>
        /// Asynchronously generates a license file using Azure Key Vault as the signing source.
        /// </summary>
        /// <param name="keyVaultDNS">The DNS name of the Azure Key Vault.</param>
        /// <param name="keyName">The name of the key/certificate in the Key Vault.</param>
        /// <param name="tenantId">The Azure AD tenant ID.</param>
        /// <param name="clientId">The client ID (application ID) for authentication.</param>
        /// <param name="clientSecret">The client secret for authentication.</param>
        /// <returns>A task representing the asynchronous operation, with a result of true if successful; otherwise, false.</returns>
        public async Task<bool> GenerateLicenseKeyVaultAsync(string keyVaultDNS, string keyName, string tenantId, string clientId, string clientSecret)
        {
            return await new LicenseGenerator(config, context).GenerateLicenseKeyVaultAsync(keyVaultDNS, keyName, tenantId, clientId, clientSecret);
        }

        private static void ValidateContextNotNull(AxUtilContext context)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));
        }

        private static void ValidateConfigNotNull(AxUtilConfiguration config)
        {
            if (config == null)
                throw new ArgumentNullException(nameof(config));
        }

        private static void ValidateContextAndConfigNotNull(
          AxUtilContext context,
          AxUtilConfiguration config)
        {
            ValidateContextNotNull(context);
            ValidateConfigNotNull(config);
        }
    }
}
