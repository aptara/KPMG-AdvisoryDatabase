using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdvisoryDatabase.Framework.Common;

namespace AdvisoryDatabase.Framework.Entities
{
    public class CourseOwnerDetails : BaseEntity<Int32>
    {
        public string CourseOwnerID { get; set; }
        public string CourseOwner { get; set; } 

    }
}
