using System;
using System.Security.Cryptography.X509Certificates;

namespace AASAXUtilLib
{
    public class AxUtil
    {
        private AxUtilConfiguration config;
        private AxUtilContext context;

        public AxUtil()
        {
        }

        public AxUtil(AxUtilContext context, AxUtilConfiguration config)
          : this()
        {
            ValidateContextAndConfigNotNull(context, config);
            Context = context;
            Config = config;
        }

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

        public bool GenerateLicense(X509Certificate2Collection scollection)
        {
            if (scollection.Count == 0)
            {
                throw new NullReferenceException("No certificate loaded.");
            }

            foreach (X509Certificate2 x509 in scollection)
            {
                X509Certificate2 certificate = x509;

                return new LicenseGenerator(config, context).GenerateLicense(certificate);
            }

            return false;
        }

        public bool GenerateLicenseKeyVault(string keyVaultDNS, string keyName, string tenantId, string clientId, string clientSecret)
        {
            return new LicenseGenerator(config, context).GenerateLicenseKeyVault(keyVaultDNS, keyName, tenantId, clientId, clientSecret);
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
