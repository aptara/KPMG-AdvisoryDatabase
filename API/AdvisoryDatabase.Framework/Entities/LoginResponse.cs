using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvisoryDatabase.Framework.Entities
{
    public class LoginResponse
    {
        public User User { get; set; }
        public string ErrorMessage { get; set; }
        public bool IsAuthenticated { get; set; }
    }
}
