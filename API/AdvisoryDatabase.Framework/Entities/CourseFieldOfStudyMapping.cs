using AdvisoryDatabase.Framework.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvisoryDatabase.Framework.Entities
{
    public class CourseFieldOfStudyMapping : BaseEntity<Int32>
    {
        public int CourseFieldOfStudyID { get; set; }
        public int CourseMasterID { get; set; }
        public int FieldOfStudyMasterID { get; set; }
        public string FOSCredit { get; set; }
    }
}
