using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdvisoryDatabase.DataAccess.Common;
using AdvisoryDatabase.DataAccess.Repository;
using AdvisoryDatabase.Framework.Entities;
using System.Data;
using System.Data.Common;

namespace AdvisoryDatabase.DataAccess.DataAccessService
{
    public class DataAccessCourseDetailService : DataAccessRepository<Course, Int32>
    {
        protected override string GetProcedureName(OperationType operation)
        {
            string spName = string.Empty;
            switch (operation)
            {
                case OperationType.Get:
                    spName = "USP_GetCourse";
                    break;
                case OperationType.GetAll:
                    spName = "USP_GetCourse";
                    break;
                case OperationType.Add:
                    spName = "USP_ManageCourse";
                    break;
                case OperationType.Update:
                    spName = "USP_ManageCourse";
                    break;
                case OperationType.Delete:
                    spName = "USP_ManageCourse";
                    break;
                default:
                    spName = string.Empty;
                    break;
            }
            return spName;
        }
        protected override void FillParameters(OperationType operation, Course instance, List<DbParameter> parameters)
        {
            if (operation == OperationType.Get || operation == OperationType.GetAll)
            {
                parameters.Add(DbHelper.CreateParameter("CourseMasterID", instance.CourseMasterID));
                parameters.Add(DbHelper.CreateParameter("IsActive", instance.IsActive));
            }
            else if (operation == OperationType.Add || operation == OperationType.Update)
            {

                parameters.Add(DbHelper.CreateParameter("CourseMasterID", instance.CourseMasterID));
                parameters.Add(DbHelper.CreateParameter("CourseName", instance.CourseName));
                parameters.Add(DbHelper.CreateParameter("CourseID", instance.CourseID));
                parameters.Add(DbHelper.CreateParameter("DeploymentFiscalYear", instance.DeploymentFiscalYear));
                parameters.Add(DbHelper.CreateParameter("DevelopmentYear", instance.DevelopmentYear));
                parameters.Add(DbHelper.CreateParameter("CompetencyMasterID", instance.CompetencyMasterID));
                parameters.Add(DbHelper.CreateParameter("ProgramKnowledgeLevelMasterID", instance.ProgramKnowledgeLevelMasterID));
                parameters.Add(DbHelper.CreateParameter("CourseOverviewObjective", instance.CourseOverviewObjective));
                parameters.Add(DbHelper.CreateParameter("TargetAudience", instance.TargetAudience));
                parameters.Add(DbHelper.CreateParameter("EstimatedCPE", instance.EstimatedCPE));
                parameters.Add(DbHelper.CreateParameter("StatusMasterID", instance.StatusMasterID));
                //parameters.Add(DbHelper.CreateParameter("AudienceLevelMasterID", instance.AudienceLevelMasterID));
                parameters.Add(DbHelper.CreateParameter("SpecialNoticeMasterID", instance.SpecialNoticeMasterID));
                parameters.Add(DbHelper.CreateParameter("FunctionMasterID", instance.FunctionMasterID));
                parameters.Add(DbHelper.CreateParameter("CourseSponsor", instance.CourseSponsor));
                parameters.Add(DbHelper.CreateParameter("WhichSGSLSNSponsorLearning", instance.WhichSGSLSNSponsorLearning));
                parameters.Add(DbHelper.CreateParameter("SubjectMatterProfessional", instance.SubjectMatterProfessional));
                parameters.Add(DbHelper.CreateParameter("Vendor", instance.Vendor));
                parameters.Add(DbHelper.CreateParameter("ServiceNowID", instance.ServiceNowID));
                parameters.Add(DbHelper.CreateParameter("Descriptions", instance.Descriptions));
                parameters.Add(DbHelper.CreateParameter("IsRegulatoryOrLegalRequirement", instance.IsRegulatoryOrLegalRequirement));
                parameters.Add(DbHelper.CreateParameter("ProgramTypeID", instance.ProgramTypeID));
                parameters.Add(DbHelper.CreateParameter("DeliveryTypeID", instance.DeliveryTypeID));
                parameters.Add(DbHelper.CreateParameter("Duration", instance.Duration));
                parameters.Add(DbHelper.CreateParameter("FirstDeliveryDate", instance.FirstDeliveryDate));
                parameters.Add(DbHelper.CreateParameter("MaximumAttendeeCount", instance.MaximumAttendeeCount));
                parameters.Add(DbHelper.CreateParameter("MinimumAttendeeCount", instance.MinimumAttendeeCount));
                parameters.Add(DbHelper.CreateParameter("MaximumAttendeeWaitlist", instance.MaximumAttendeeWaitlist));
                parameters.Add(DbHelper.CreateParameter("MaterialMasterID", instance.MaterialMasterID));
                parameters.Add(DbHelper.CreateParameter("Collateral", instance.Collateral));
                parameters.Add(DbHelper.CreateParameter("RoomSetUpComments", instance.RoomSetUpComments));
                parameters.Add(DbHelper.CreateParameter("DeploymentFacilitatorConsideration", instance.DeploymentFacilitatorConsideration));
                parameters.Add(DbHelper.CreateParameter("LDIntakeOwner", instance.LDIntakeOwner));
                parameters.Add(DbHelper.CreateParameter("ProjectManagerContact", instance.ProjectManagerContact));
                parameters.Add(DbHelper.CreateParameter("InstructionalDesigner", instance.InstructionalDesigner));
                parameters.Add(DbHelper.CreateParameter("LevelofEffortMasterId", instance.LevelofEffortMasterId));
                parameters.Add(DbHelper.CreateParameter("CourseNotes", instance.CourseNotes));


            }
            else if (operation == OperationType.Delete)
            {
                parameters.Add(DbHelper.CreateParameter("IsActive", instance.IsActive));
                parameters.Add(DbHelper.CreateParameter("CourseMasterID", instance.CourseMasterID));

            }
        }

        protected override List<Course> ParseGetAllData(System.Data.DataSet data)
        {
            List<Course> courses = new List<Course>();
            Course course = new Course();

            var GetAllData = data.Tables[0].AsEnumerable().Select(row =>
                new Course
                {
                    CourseMasterID = row.Read<int>("CourseMasterID"),
                    CourseName = row.ReadString("CourseName"),
                    CourseID = row.ReadString("CourseID"),
                    DeploymentFiscalYear = row.ReadString("DeploymentFiscalYear"),
                    CompetencyMasterID = row.Read<long>("CompetencyMasterID"),
                    SkillMasterID = row.Read<long>("SkillMasterID"),
                    IndustryMasterID = row.Read<long>("IndustryMasterID"),
                    ProgramKnowledgeLevelMasterID = row.Read<long>("ProgramKnowledgeLevelMasterID"),
                    CourseOverviewObjective = row.ReadString("CourseOverviewObjective"),
                    TargetAudience = row.ReadString("TargetAudience"),
                    DevelopmentYear = row.ReadString("DevelopmentYear"),
                    //AudienceLevelMasterID = row.Read<long>("AudienceLevelMasterID"),
                    EstimatedCPE = row.ReadString("EstimatedCPE"),
                    PrerequisiteCourseID = row.ReadString("PrerequisiteCourseID"),
                    EquivalentCourseID = row.ReadString("EquivalentCourseID"),
                    SpecialNoticeMasterID = row.Read<long>("SpecialNoticeMasterID"),
                    FunctionMasterID = row.Read<long>("FunctionMasterID"),
                    CourseSponsor = row.ReadString("CourseSponsor"),
                    WhichSGSLSNSponsorLearning = row.ReadString("WhichSGSLSNSponsorLearning"),
                    SubjectMatterProfessional = row.ReadString("SubjectMatterProfessional"),
                    Vendor = row.ReadString("Vendor"),
                    ServiceNowID = row.ReadString("ServiceNowID"),
                    Descriptions = row.ReadString("Descriptions"),
                    IsRegulatoryOrLegalRequirement = row.Read<bool>("IsRegulatoryOrLegalRequirement"),
                    ProgramTypeID = row.Read<int>("ProgramTypeID"),
                    DeliveryTypeID = row.Read<int>("DeliveryTypeID"),
                    Duration = row.ReadString("Duration"),
                    FirstDeliveryDate = row.Read<DateTime>("FirstDeliveryDate"),
                    MaximumAttendeeCount = row.Read<decimal>("MaximumAttendeeCount"),
                    MinimumAttendeeCount = row.Read<decimal>("MinimumAttendeeCount"),
                    MaximumAttendeeWaitlist = row.Read<decimal>("MaximumAttendeeWaitlist"),
                    MaterialMasterID = row.Read<long>("MaterialMasterID"),
                    Collateral = row.Read<bool>("Collateral"),
                    RoomSetUpComments = row.ReadString("RoomSetUpComments"),
                    DeploymentFacilitatorConsideration = row.ReadString("DeploymentFacilitatorConsideration"),
                    LDIntakeOwner = row.ReadString("LDIntakeOwner"),
                    ProjectManagerContact = row.ReadString("ProjectManagerContact"),
                    InstructionalDesigner = row.ReadString("InstructionalDesigner"),
                    LevelofEffortMasterId = row.Read<long>("LevelofEffortMasterId"),
                    FoucsCourseOwner1 = row.ReadString("FoucsCourseOwner1"),
                    FocusCourseOwner2 = row.ReadString("FocusCourseOwner2"),
                    CourseNotes = row.ReadString("CourseNotes"),
                    ProjectStatusID = row.Read<int>("ProjectStatusID"),
                    FocusDomain = row.ReadString("FocusDomain"),
                    FocusRetired = row.ReadString("FocusRetired"),
                    FocusDiscFrom = row.ReadString("FocusDiscFrom"),
                    FocusDisplayedToLearner = row.ReadString("FocusDisplayedToLearner"),
                    CourseRecordURL = row.ReadString("CourseRecordURL"),
                    CreatedBy = row.Read<int>("CreatedBy"),
                    CreatedOn = row.Read<DateTime>("CreatedOn"),
                    LastUpdatedBy = row.Read<int>("LastUpdatedBy"),
                    LastUpdatedOn = row.Read<DateTime>("LastUpdatedOn"),
                    IsActive = row.Read<bool>("IsActive"),
                    ClarizenStartDate = row.Read<DateTime>("ClarizenStartDate"),
                    Price = row.ReadString("Price"),
                    Currency = row.ReadString("Currency"),
                    DisplayCallCenter = row.ReadString("DisplayCallCenter"),
                    FieldOfStudyMasterID = row.Read<int>("FieldOfStudyMasterID"),
                    FuntionMasterID = row.Read<long>("FuntionMasterID"),
                    StatusMasterID = row.Read<int>("StatusMasterID"),
                    LDIIntakeOwnerText = row.ReadString("LDIIntakeOwnerText"),
                    ProjectManagerContactMasterText = row.ReadString("ProjectManagerContactMasterText"),
                    StatusText = row.ReadString("StatusText"),

                }).ToList();
            if (GetAllData.Count == 1)
            {
                course = GetAllData.SingleOrDefault();
            }
            if (data.Tables[1].Rows.Count > 0)
            {
                course.AudienceLevels = data.Tables[1].AsEnumerable().Select(row =>
                new CourseMasterData
                {
                    Id = row.Read<int>("Id"),
                    DisplayName = row.ReadString("DisplayName"),
                }).ToList();
            }
            else{
                course.AudienceLevels = new List<CourseMasterData>();
            }
            if (data.Tables[2].Rows.Count > 0)
            {
                course.AudienceTypeFormGroup = data.Tables[2].AsEnumerable().Select(row =>
                new AudienceTypeFormData
                {
                    AudienceType = row.ReadString("AudienceType"),
                }).ToList();
            }
            else
            {
                course.AudienceTypeFormGroup = new List<AudienceTypeFormData>();
            }
            if (data.Tables[3].Rows.Count > 0)
            {
                course.FieldOfStudyFormGroup = data.Tables[3].AsEnumerable().Select(row =>
                new FieldOfStudyFormData
                {
                    FieldOfStudy = new CourseMasterData
                    {
                        Id = row.Read<long>("Id"),
                        DisplayName = row.ReadString("DisplayName")
                    },
                    FieldOfStudyCredit = row.ReadString("FOSCredit"),
                }).ToList();
            }
            else
            {
                course.FieldOfStudyFormGroup = new List<FieldOfStudyFormData>();
            }
            if (data.Tables[4].Rows.Count > 0)
            {
                course.FunctionMasterIDs = data.Tables[4].AsEnumerable().Select(row =>
                   new CourseMasterData
                   {
                       Id = row.Read<int>("Id"),
                       DisplayName = row.ReadString("DisplayName"),
                   }).ToList();
            }
            else
            {
                course.FunctionMasterIDs = new List<CourseMasterData>();
            }
            if (data.Tables[5].Rows.Count > 0)
            {
                course.Industries = data.Tables[5].AsEnumerable().Select(row =>
                   new CourseMasterData
                   {
                       Id = row.Read<int>("Id"),
                       DisplayName = row.ReadString("DisplayName"),
                   }).ToList();
            }
            else
            {
                course.Industries = new List<CourseMasterData>();
            }
            if (data.Tables[6].Rows.Count > 0)
            {
                course.SGSLSNFormGroups = data.Tables[6].AsEnumerable().Select(row =>
                   new SGSLSNFormData
                   {
                       ServiceGroup = new CourseMasterData
                       {
                           Id = row.Read<long>("ServiceGroupId"),
                           DisplayName = row.ReadString("ServiceGroup")
                       },
                       ServiceLine = new CourseMasterData
                       {
                           Id = row.Read<long>("ServiceLineId"),
                           DisplayName = row.ReadString("ServiceLine")
                       },
                       ServiceNetwork = new CourseMasterData
                       {
                           Id = row.Read<long>("ServiceNetworkID"),
                           DisplayName = row.ReadString("ServiceNetwork")
                       },
                   }).ToList();
            }
            else
            {
                course.SGSLSNFormGroups = new List<SGSLSNFormData>();
            }
            if (data.Tables[7].Rows.Count > 0)
            {
                course.SkillMasterIDs = data.Tables[7].AsEnumerable().Select(row =>
                   new CourseMasterData
                   {
                       Id = row.Read<long>("Id"),
                       DisplayName = row.ReadString("DisplayName"),
                   }).ToList();
            }
            else
            {
                course.SkillMasterIDs = new List<CourseMasterData>();
            }
            if (data.Tables[8].Rows.Count > 0)
            {
                course.EquivalentCourseIDFormGroup = data.Tables[8].AsEnumerable().Select(row =>
                   new EquivalentCourseIDFormData
                   {
                       EquivalentCourseID = row.ReadString("EquivalentCourseID"),
                   }).ToList();
            }
            else
            {
                course.EquivalentCourseIDFormGroup = new List<EquivalentCourseIDFormData>();
            }
            if (data.Tables[9].Rows.Count > 0)
            {
                course.FOCUSCourseOwnerFormGroup = data.Tables[9].AsEnumerable().Select(row =>
                     new CourseMasterData
                     {
                         Id = row.Read<int>("Id"),
                         DisplayName = row.ReadString("DisplayName"),
                     }).ToList();
            }
            else
            {
                course.FOCUSCourseOwnerFormGroup = new List<CourseMasterData>();
            }
            if (data.Tables[10].Rows.Count > 0)
            {
                course.PrerequisiteCourseIDFormGroup = data.Tables[10].AsEnumerable().Select(row =>
                   new PrerequisiteCourseIDFormData
                   {
                       PrerequisiteCourseID = row.ReadString("PrerequisiteCourseID"),
                   }).ToList();
            }
            else
            {
                course.PrerequisiteCourseIDFormGroup = new List<PrerequisiteCourseIDFormData>();
            }
            if (GetAllData.Count == 1)
            {
                courses.Add(course);
                return courses;
            }
            else
            {
                return GetAllData;
            }
        }

        protected override Course Parse(System.Data.DataRow data)
        {
            return new Course
            {
                CourseMasterID = data.Read<int>("CourseMasterID"),
                CourseName = data.ReadString("CourseName"),
                CourseID = data.ReadString("CourseID"),
                DeploymentFiscalYear = data.ReadString("DeploymentFiscalYear"),
                CompetencyMasterID = data.Read<long>("CompetencyMasterID"),
                SkillMasterID = data.Read<long>("SkillMasterID"),
                IndustryMasterID = data.Read<long>("IndustryMasterID"),
                ProgramKnowledgeLevelMasterID = data.Read<long>("ProgramKnowledgeLevelMasterID"),
                CourseOverviewObjective = data.ReadString("CourseOverviewObjective"),
                TargetAudience = data.ReadString("TargetAudience"),
                //AudienceLevelMasterID = data.Read<long>("AudienceLevelMasterID "),
                EstimatedCPE = data.ReadString("EstimatedCPE"),
                PrerequisiteCourseID = data.ReadString("PrerequisiteCourseID"),
                EquivalentCourseID = data.ReadString("EquivalentCourseID"),
                SpecialNoticeMasterID = data.Read<long>("SpecialNoticeMasterID"),
                FunctionMasterID = data.Read<long>("FunctionMasterID"),
                CourseSponsor = data.ReadString("CourseSponsor"),
                WhichSGSLSNSponsorLearning = data.ReadString("WhichSGSLSNSponsorLearning"),
                SubjectMatterProfessional = data.ReadString("SubjectMatterProfessional"),
                Vendor = data.ReadString("Vendor"),
                ServiceNowID = data.ReadString("ServiceNowID"),
                Descriptions = data.ReadString("Descriptions"),
                IsRegulatoryOrLegalRequirement = data.Read<bool>("IsRegulatoryOrLegalRequirement"),
                ProgramTypeID = data.Read<int>("ProgramTypeID"),
                DeliveryTypeID = data.Read<int>("DeliveryTypeID"),
                Duration = data.ReadString("Duration"),
                FirstDeliveryDate = data.Read<DateTime>("FirstDeliveryDate"),
                MaximumAttendeeCount = data.Read<decimal>("MaximumAttendeeCount"),
                MinimumAttendeeCount = data.Read<decimal>("MinimumAttendeeCount"),
                MaximumAttendeeWaitlist = data.Read<decimal>("MaximumAttendeeWaitlist"),
                MaterialMasterID = data.Read<long>("MaterialMasterID"),
                Collateral = data.Read<bool>("Collateral"),
                RoomSetUpComments = data.ReadString("RoomSetUpComments"),
                DeploymentFacilitatorConsideration = data.ReadString("DeploymentFacilitatorConsideration"),
                LDIntakeOwner = data.ReadString("LDIntakeOwner"),
                ProjectManagerContact = data.ReadString("ProjectManagerContact"),
                InstructionalDesigner = data.ReadString("InstructionalDesigner"),
                LevelofEffortMasterId = data.Read<long>("LevelofEffortMasterId"),
                FoucsCourseOwner1 = data.ReadString("FoucsCourseOwner1"),
                FocusCourseOwner2 = data.ReadString("FocusCourseOwner2"),
                CourseNotes = data.ReadString("CourseNotes"),
                ProjectStatusID = data.Read<int>("ProjectStatusID"),
                FocusDomain = data.ReadString("FocusDomain"),
                FocusRetired = data.ReadString("FocusRetired"),
                FocusDiscFrom = data.ReadString("FocusDiscFrom"),
                FocusDisplayedToLearner = data.ReadString("FocusDisplayedToLearner"),
                CourseRecordURL = data.ReadString("CourseRecordURL"),
                CreatedBy = data.Read<int>("CreatedBy"),
                CreatedOn = data.Read<DateTime>("CreatedOn"),
                LastUpdatedBy = data.Read<int>("LastUpdatedBy"),
                LastUpdatedOn = data.Read<DateTime>("LastUpdatedOn"),
                IsActive = data.Read<bool>("IsActive"),
                ClarizenStartDate = data.Read<DateTime>("ClarizenStartDate"),
                Price = data.ReadString("Price"),
                Currency = data.ReadString("Currency"),
                DisplayCallCenter = data.ReadString("DisplayCallCenter"),
                FieldOfStudyMasterID = data.Read<int>("FieldOfStudyMasterID"),
                FuntionMasterID = data.Read<long>("FuntionMasterID"),
            };
        }
    }
}

