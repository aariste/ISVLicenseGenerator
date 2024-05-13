using System;
using System.Collections.Generic;

namespace AASAXUtilLib
{
    [Serializable]
    public class AxUtilContext : MarshalByRefObject
    {
        private List<string> errors = new List<string>();        

        public virtual void ReportError(string errorText)
        {
            this.errors.Add(errorText);
        }
    }
}
