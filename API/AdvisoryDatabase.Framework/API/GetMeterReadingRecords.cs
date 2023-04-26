using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdvisoryDatabase.Framework.Common;

namespace AdvisoryDatabase.Framework.API
{
    public class GetMeterReadingRecords : BaseEntity<Int32>
    {
        public string RequestKey { get; set; }
        public string MeterReading { get; set; }
        public string ReadingOn { get; set; }
        public string MeterID { get; set; }
    }
}
