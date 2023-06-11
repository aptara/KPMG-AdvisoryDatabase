using AdvisoryDatabase.Framework.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvisoryDatabase.Framework.Entities
{
    public class CourseIndustryMapping : BaseEntity<Int32>
    {
        public int CourseIndustryMasterID { get; set; }
        public int CourseMasterID { get; set; }
        public int IndustryID { get; set; }
    }
}
