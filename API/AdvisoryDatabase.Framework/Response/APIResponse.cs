using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvisoryDatabase.Framework.Response
{
    public class APIResponse<T>
    {
        /// <summary>
        /// Gets or sets error message
        /// </summary>
        public string ErrorMessage { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether success
        /// </summary>
        public bool Success { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether duplicate session
        /// </summary>
        public bool IsDuplicateSession { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether show message
        /// </summary>
        public bool ShowMessage { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether show message text
        /// </summary>
        public string ShowMessageText { get; set; }

        /// <summary>
        /// Gets or sets count
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// Gets or sets data
        /// </summary>
        public T Data { get; set; }
    }
}
