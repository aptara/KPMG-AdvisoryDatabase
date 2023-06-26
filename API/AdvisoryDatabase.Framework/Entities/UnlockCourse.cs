using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdvisoryDatabase.Framework.Common;

namespace AdvisoryDatabase.Framework.Entities
{
    public class UnlockCourseMap : BaseEntity<Int32>
    {
        public string CourseMasterIDs { get; set; }
        public int CourseMasterID { get; set; }



    }

}
