using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvisoryDatabase.Framework.CustomException
{
    public class MSBException : ApplicationException
    {
        public MSBException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        public MSBException(string message)
            : base(message, null)
        {
        }
    }
}
