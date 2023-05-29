using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvisoryDatabase.Framework.Response.User
{
    /// <summary>
    /// Login response class
    /// </summary>
    public class LoginResponse
    {
        /// <summary>
        /// Gets or sets authentication token
        /// </summary>
        public string AuthToken { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether connection issue
        /// </summary>
        public bool IsConnectionIssue { get; set; }

        /// <summary>
        /// Gets or sets user instance
        /// </summary>
        //public User User { get; set; }

        /// <summary>
        /// Gets or sets error message
        /// </summary>
        public string ErrorMessage { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether authenticated
        /// </summary>
        public bool IsAuthenticated { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether duplicate session
        /// </summary>
        public bool IsDuplicateSession { get; set; }
    }
}
