using System;
using System.Security.Cryptography.X509Certificates;

namespace Microsoft.Dynamics.AX.Framework.Tools.ModelManagement
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
            AxUtil.ValidateContextAndConfigNotNull(context, config);
            this.Context = context;
            this.Config = config;
        }

        public AxUtilContext Context
        {
            get
            {
                return this.context;
            }
            set
            {
                AxUtil.ValidateContextNotNull(value);
                this.context = value;
            }
        }

        public AxUtilConfiguration Config
        {
            get
            {
                return this.config;
            }
            set
            {
                AxUtil.ValidateConfigNotNull(value);
                this.config = value;
            }
        }

        public bool GenerateLicense(X509Certificate2Collection scollection)
        {
            if (scollection.Count == 0)
            {
                throw new System.NullReferenceException("No certificate loaded.");
            }

            foreach (X509Certificate2 x509 in scollection)
            {
                X509Certificate2 certificate = x509;

                return new LicenseGenerator(this.config, this.context).GenerateLicense(certificate);
            }

            return false;
        }

        public bool GenerateLicenseKeyVault(string keyVaultDNS, string keyName)
        { 
            return new LicenseGenerator(this.config, this.context).GenerateLicenseKeyVault(keyVaultDNS, keyName);
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
            AxUtil.ValidateContextNotNull(context);
            AxUtil.ValidateConfigNotNull(config);
        }
    }
}
