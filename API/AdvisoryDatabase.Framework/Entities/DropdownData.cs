using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvisoryDatabase.Framework.Entities
{
    public class DropdownData
    {
        public List<CourseOwnerMaster> CourseOwnerMasters { get; set; }
        public List<ProjectStatusMaster> ProjectStatusMasters { get; set; }
        public List<StatusMaster> StatusMasters { get; set; }
        public List<DeliveryTypeMaster> DeliveryTypeMasters { get; set; }
        public List<ProgramTypeMaster> ProgramTypeMasters { get; set; }
    }
}
