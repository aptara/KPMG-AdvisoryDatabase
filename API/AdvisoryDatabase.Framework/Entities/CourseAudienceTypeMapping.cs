using AdvisoryDatabase.Framework.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvisoryDatabase.Framework.Entities
{
    public class CourseAudienceTypeMapping : BaseEntity<Int32>
    {
        public int AudienceLevelMasterID { get; set; }
        public int CourseMasterID { get; set; }
        public string AudienceType { get; set; }
    }
}
