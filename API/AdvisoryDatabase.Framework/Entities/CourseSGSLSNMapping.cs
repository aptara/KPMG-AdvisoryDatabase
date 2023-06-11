using AdvisoryDatabase.Framework.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvisoryDatabase.Framework.Entities
{
    public class CourseSGSLSNMapping : BaseEntity<Int32>
    {
        public int CourseSGSLSNID { get; set; }
        public int CourseMasterID { get; set; }
        public int ServiceGroupID { get; set; }
        public int ServiceLineID { get; set; }
        public int ServiceNetworkID { get; set; }
    }

}
