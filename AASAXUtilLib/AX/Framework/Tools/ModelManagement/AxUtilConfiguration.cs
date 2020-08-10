using System;

namespace Microsoft.Dynamics.AX.Framework.Tools.ModelManagement
{
    [Serializable]
    public class AxUtilConfiguration
    {
        public LicenseInfo LicenseInfo { get; set; }

        public int SignatureVersion { get; set; }
    }
}