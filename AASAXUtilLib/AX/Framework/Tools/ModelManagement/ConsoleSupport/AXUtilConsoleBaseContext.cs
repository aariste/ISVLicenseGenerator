using Microsoft.Dynamics.AX.Framework.Tools.ModelManagement.Properties;
using System;
using System.Globalization;

namespace Microsoft.Dynamics.AX.Framework.Tools.ModelManagement.ConsoleSupport
{
    [Serializable]
    public abstract class AXUtilConsoleBaseContext : AxUtilContext
    {
        private bool hasCopyrightBeenDisplayed;
        private bool hasModeBeenDisplayed;
        private bool suppressStatus;

        public bool SuppressStatus
        {
            get
            {
                return this.suppressStatus;
            }
            set
            {
                this.suppressStatus = value;
            }
        }

        internal void DisplayCopyright()
        {
            if (this.hasCopyrightBeenDisplayed)
                return;
            this.hasCopyrightBeenDisplayed = true;
            this.WriteOutput(string.Format((IFormatProvider)CultureInfo.CurrentCulture, Resources.CopyrightStatement, (object)"7.0", (object)"7.0.5407.16661"));
        }

        internal void DisplayWorkingMode(string mode)
        {
            this.DisplayCopyright();
            if (this.hasModeBeenDisplayed)
                return;
            this.hasModeBeenDisplayed = true;
            this.DisplayStatus(string.Format((IFormatProvider)CultureInfo.CurrentCulture, Resources.UtilMode, (object)mode));
        }

        public override void ReportWarning(string warning)
        {
            base.ReportWarning(warning);
            this.WriteOutput(string.Format((IFormatProvider)CultureInfo.CurrentCulture, Resources.Warning, (object)warning));
        }

        public override void ReportError(string errorText)
        {
            base.ReportError(errorText);
            this.WriteOutput(string.Format((IFormatProvider)CultureInfo.CurrentCulture, Resources.Error, (object)errorText));
        }

        public override void DisplayHelp()
        {
            this.DisplayCopyright();
            this.WriteOutput(Resources.CommandLineHelpCommands);
            this.WriteOutput(Resources.CommandLineHelpParameters);
        }

        public override void DisplayStatus(string status)
        {
            if (this.SuppressStatus)
                return;
            this.WriteOutput(status);
        }

        public override void DisplayResult(string result)
        {
            this.WriteOutput(result);
        }

        public abstract bool DisplayYesNoQuestion(string question);

        protected abstract void WriteLineToOutputUnconditionally(string outputMessage);

        protected abstract void WriteToOutputUnconditionally(string outputMessage);

        protected void WriteOutput(string outputMessage)
        {
            this.WriteLineToOutputUnconditionally(outputMessage);
        }
    }
}
