using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvisoryDatabase.Framework.Common
{
    /// <summary>
    /// Class for error response. 
    /// </summary>
    public class ErrorResponse
    {
        /// <summary>
        /// Local variable for list of error.
        /// </summary>
        private List<string> localError;

        /// <summary>
        /// Gets or sets value for internal error property.
        /// </summary>
        public string InternalError { get; set; }

        /// <summary>
        /// Gets value for list of errors. 
        /// </summary>
        public List<string> Errors
        {
            get
            {
                return this.localError ?? (this.localError = new List<string>());
            }
        }
    }
}
