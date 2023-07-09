using AdvisoryDatabase.Framework.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvisoryDatabase.Framework.Entities
{
    public class Course : BaseEntity<int>
    {
        public int CourseMasterID { get; set; }
        public string CourseName { get; set; }
        public string CourseID { get; set; }
        public string DeploymentFiscalYear { get; set; }
        public string DevelopmentYear { get; set; }
        public long? CompetencyMasterID { get; set; }
        public long? SkillMasterID { get; set; }
        public long? IndustryMasterID { get; set; }
        public long? ProgramKnowledgeLevelMasterID { get; set; }
        public string CourseOverviewObjective { get; set; }
        public string TargetAudience { get; set; }
        public long? AudienceLevelMasterID { get; set; }
        public string EstimatedCPE { get; set; }
        public string PrerequisiteCourseID { get; set; }
        public string EquivalentCourseID { get; set; }
        public long? SpecialNoticeMasterID { get; set; }
        public long? FunctionMasterID { get; set; }
        public string CourseSponsor { get; set; }
        public string WhichSGSLSNSponsorLearning { get; set; }
        public string SubjectMatterProfessional { get; set; }
        public string Vendor { get; set; }
        public string ServiceNowID { get; set; }
        public string Descriptions { get; set; }
        public bool? IsRegulatoryOrLegalRequirement { get; set; }
        public int ProgramTypeID { get; set; }
        public int DeliveryTypeID { get; set; }
        public string Duration { get; set; }
        public DateTime FirstDeliveryDate { get; set; }
        public decimal? MaximumAttendeeCount { get; set; }
        public decimal? MinimumAttendeeCount { get; set; }
        public decimal? MaximumAttendeeWaitlist { get; set; }
        public long? MaterialMasterID { get; set; }
        public bool? Collateral { get; set; }
        public string RoomSetUpComments { get; set; }
        public string DeploymentFacilitatorConsideration { get; set; }
        public string LDIntakeOwner { get; set; }
        public string ProjectManagerContact { get; set; }
        public string InstructionalDesigner { get; set; }
        public long? LevelofEffortMasterId { get; set; }
        public string FoucsCourseOwner1 { get; set; }
        public string FocusCourseOwner2 { get; set; }
        public string CourseNotes { get; set; }
        public int? ProjectStatusID { get; set; }
        public string FocusDomain { get; set; }
        public string FocusRetired { get; set; }
        public string FocusDiscFrom { get; set; }
        public string FocusDisplayedToLearner { get; set; }
        public string CourseRecordURL { get; set; }
        public DateTime? ClarizenStartDate { get; set; }
        public string Price { get; set; }
        public string Currency { get; set; }
        public string DisplayCallCenter { get; set; }
        public int? FieldOfStudyMasterID { get; set; }
        public int? StatusMasterID { get; set; }
        public long? FuntionMasterID { get; set; }
        public string LDIIntakeOwnerText { get; set; }
        public string ProjectManagerContactMasterText { get; set; }
        public string StatusText { get; set; }

        public List<CourseMasterData> SkillMasterIDs { get; set; }
        public List<CourseMasterData> Industries { get; set; }
        public List<CourseMasterData> AudienceLevels { get; set; }
        public List<CourseMasterData> FunctionMasterIDs { get; set; }
        public List<SGSLSNFormData> SGSLSNFormGroups { get; set; }
        public List<FieldOfStudyFormData> FieldOfStudyFormGroup { get; set; }
        public List<CourseMasterData> FOCUSCourseOwnerFormGroup { get; set; }
        public List<PrerequisiteCourseIDFormData> PrerequisiteCourseIDFormGroup { get; set; }
        public List<EquivalentCourseIDFormData> EquivalentCourseIDFormGroup { get; set; }
        public List<AudienceTypeFormData> AudienceTypeFormGroup { get; set; }
        public string CurrentData { get; set; }
        public string PreviousData { get; set; }
        public string UpdatedUserName { get; set; }
        public string WorkNotes { get; set; }
    }
}
