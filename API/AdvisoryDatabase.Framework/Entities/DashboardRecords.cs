using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdvisoryDatabase.Framework.Common;

namespace AdvisoryDatabase.Framework.Entities
{
    public class DashboardRecords : BaseEntity<Int32>
    {
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }

        public string BayID { get; set; }

        public string MeterID { get; set; }
        public string Reading { get; set; }
        public DateTime ReadingDate { get; set; }

        public string ReadingDatestring { get; set; }
        public string MeterName { get; set; }
    }
}
