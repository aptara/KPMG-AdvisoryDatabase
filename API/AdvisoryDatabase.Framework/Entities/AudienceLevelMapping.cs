using AdvisoryDatabase.Framework.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvisoryDatabase.Framework.Entities
{
    public class AudienceLevelMapping : BaseEntity<Int32>
    {
        public int CourseMasterID { get; set; }
        public int AudienceLevelId { get; set; }
    }
}
