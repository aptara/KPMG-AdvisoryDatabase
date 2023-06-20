using AdvisoryDatabase.Framework.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvisoryDatabase.Framework.Entities
{
    public class DropdownData : BaseEntity<long>
    {
        public List<CourseMasterData> CompetencyMasterData { get; set; }
        public List<CourseMasterData> SkillMasterData { get; set; }
        public List<CourseMasterData> IndustryMasterData { get; set; }
        public List<CourseMasterData> ProgramKnowledgeLevelMasterData { get; set; }
        public List<CourseMasterData> AudienceLevelMasterData { get; set; }
        public List<CourseMasterData> ServiceGroupMasterData { get; set; }
        public List<CourseMasterData> ServiceLineMasterData { get; set; }
        public List<CourseMasterData> ServiceNetworkMasterData { get; set; }
        public List<CourseMasterData> FieldOfStudyMasterData { get; set; }
        public List<CourseMasterData> FunctionMasterData { get; set; }
        public List<CourseMasterData> DeliveryTypeMasterData { get; set; }
        public List<CourseMasterData> ProgramTypeMasterData { get; set; }
        public List<CourseMasterData> CourseOwnerMasterData { get; set; }
        public List<CourseMasterData> MaterialMasterData { get; set; }
        public List<CourseMasterData> LevelOfEffortMasterData { get; set; }
        public List<CourseMasterData> InstructionalDesignerMaster { get; set; }
        public List<CourseMasterData> ProjectManagerContactMaster { get; set; }
        public List<CourseMasterData> LDIntakeOwnerMaster { get; set; }
        public List<CourseMasterData> SpecialNoticeMasterData { get; set; }
        public List<CourseMasterData> StatusMasterData { get; set; }
    }

    public class CourseMasterData : BaseEntity<long>
    {
        public string DisplayName { get; set; }
    }

    public class PrerequisiteCourseIDFormData
    {
        public string PrerequisiteCourseID { get; set; }
    }
    public class EquivalentCourseIDFormData
    {
        public string EquivalentCourseID { get; set; }
    }
    public class AudienceTypeFormData
    {
        public string AudienceType { get; set; }
    }
    public class SGSLSNFormData
    {
        public CourseMasterData ServiceGroup { get; set; }
        public CourseMasterData ServiceLine { get; set; }
        public CourseMasterData ServiceNetwork { get; set; }
    }
    public class FieldOfStudyFormData
    {
        public CourseMasterData FieldOfStudy { get; set; }
        public string FieldOfStudyCredit { get; set; }
    }
}
