using AdvisoryDatabase.Framework.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvisoryDatabase.Framework.Entities
{
    public class AudienceTypeMapping : BaseEntity<Int32>
    {
        public int CourseMasterID { get; set; }
        public string AudienceType { get; set; }
    }
}
