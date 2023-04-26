using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdvisoryDatabase.Framework.Common;

namespace AdvisoryDatabase.Framework.Entities
{
    public class BayDetails : BaseEntity<Int32>
    {
        public string BayID { get; set; }
        public int SubStationID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
