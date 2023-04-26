using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdvisoryDatabase.Framework.Common;

namespace AdvisoryDatabase.Framework.Entities
{
    public class MeterDetails : BaseEntity<Int32>
    {
        public string MeterID { get; set; }
        public string MeterName { get; set; }
        public string MeterDescription { get; set; }
        public int BayMasterId { get; set; }
    }
}
