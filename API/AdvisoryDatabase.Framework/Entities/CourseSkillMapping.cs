using AdvisoryDatabase.Framework.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvisoryDatabase.Framework.Entities
{
    public class CourseSkillMapping : BaseEntity<Int32>
    {
        public long CourseSkillMasterID { get; set; }
        public int CourseMasterID { get; set; }
        public int SkillMasterID { get; set; }
    }
}
