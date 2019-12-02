namespace Microsoft.Dynamics.AX.Framework.Tools.ModelManagement.ConsoleSupport
{
    internal struct ParameterInfo
    {
        public ParameterType Type;
        public string Name;
        public bool Optional;
        public string Value;
        public bool Present;
        public ParameterValue RequiresValue;

        public ParameterInfo(
          ParameterType type,
          string name,
          bool optional,
          ParameterValue requiresValue)
        {
            this.Type = type;
            this.Name = name;
            this.Optional = optional;
            this.Present = false;
            this.Value = string.Empty;
            this.RequiresValue = requiresValue;
        }
    }
}
