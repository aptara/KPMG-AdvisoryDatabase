using AdvisoryDatabase.Framework.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvisoryDatabase.Framework.Entities
{
    public class DropdownData : BaseEntity<Int32>
    {
        public List<CourseMasterData> CourseOwnerMasters { get; set; }
        public List<CourseMasterData> ProjectStatusMasters { get; set; }
        public List<CourseMasterData> StatusMasters { get; set; }
        public List<CourseMasterData> DeliveryTypeMasters { get; set; }
        public List<CourseMasterData> ProgramTypeMasters { get; set; }
        public List<CourseMasterData> CompetencyMasters { get; set; }
        public List<CourseMasterData> ServiceGroupMasters { get; set; }
        public List<CourseMasterData> ServiceLineMasters { get; set; }
        public List<CourseMasterData> ServiceNetworkMasters { get; set; }
        public List<CourseMasterData> AudienceLevelMasters { get; set; }
        public List<CourseMasterData> FieldOfFieldOfStudyMaster { get; set; }
        public List<CourseMasterData> ProgramKnowledgeLevelMaster { get; set; }
        public List<CourseMasterData> CourseFunctionMasters { get; set; }
    }

    public class CourseMasterData : BaseEntity<Int32>
    {
        public string DisplayName { get; set; }
    }
}
