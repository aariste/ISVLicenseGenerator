using System;
using System.Collections.Generic;
using System.Runtime.Remoting.Lifetime;
using System.Security.Permissions;

namespace Microsoft.Dynamics.AX.Framework.Tools.ModelManagement
{
    [Serializable]
    public class AxUtilContext : MarshalByRefObject
    {
        private List<string> errors = new List<string>();
        private List<string> warnings = new List<string>();
        private bool noPrompt;

        public ICollection<string> Errors
        {
            get
            {
                return (ICollection<string>)this.errors;
            }
        }

        public ICollection<string> Warnings
        {
            get
            {
                return (ICollection<string>)this.warnings;
            }
        }

        public virtual void ReportWarning(string warning)
        {
            this.warnings.Add(warning);
        }

        public virtual void ReportError(string errorText)
        {
            this.errors.Add(errorText);
        }

        public ExecutionStatus ExecutionStatus
        {
            get
            {
                if (this.HasError)
                    return ExecutionStatus.Error;
                return this.warnings.Count > 0 ? ExecutionStatus.Warning : ExecutionStatus.Ok;
            }
        }

        public bool HasError
        {
            get
            {
                return this.errors.Count > 0;
            }
        }

        public bool NoPrompt
        {
            get
            {
                return this.noPrompt;
            }
            set
            {
                this.noPrompt = value;
            }
        }

        public virtual void DisplayHelp()
        {
        }

        public virtual void DisplayResult(string result)
        {
        }

        public virtual void DisplayStatus(string status)
        {
        }

        [SecurityPermission(SecurityAction.Demand, Flags = SecurityPermissionFlag.Infrastructure)]
        public override object InitializeLifetimeService()
        {
            ILease lease = (ILease)base.InitializeLifetimeService();
            lease.InitialLeaseTime = TimeSpan.Zero;
            return (object)lease;
        }
    }
}
