using System;
using System.Collections.Generic;

namespace AASAXUtilLib
{
    /// <summary>
    /// Context class for managing error reporting during license generation operations.
    /// </summary>
    [Serializable]
    public class AxUtilContext : MarshalByRefObject
    {
        private List<string> errors = new List<string>();

        /// <summary>
        /// Gets a read-only collection of all errors that have been reported.
        /// </summary>
        public IReadOnlyList<string> Errors => errors.AsReadOnly();

        /// <summary>
        /// Reports an error by adding it to the error collection.
        /// </summary>
        /// <param name="errorText">The error message to report.</param>
        public virtual void ReportError(string errorText)
        {
            this.errors.Add(errorText);
        }
    }
}
