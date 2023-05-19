using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using AdvisoryDatabase.Framework.Common;

namespace AdvisoryDatabase.Framework.Entities
{
/*  [Serializable]*/
  public class UserDetail : BaseEntity<Int32>
    {
        public int UserMasterID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int LocationID { get; set; }       
    }

}
