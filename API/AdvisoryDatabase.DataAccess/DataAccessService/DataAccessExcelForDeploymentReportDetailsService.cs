using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AdvisoryDatabase.DataAccess.Common;
using AdvisoryDatabase.DataAccess.Repository;
using AdvisoryDatabase.Framework.Entities;
using System.Data;


namespace AdvisoryDatabase.DataAccess.DataAccessService
{
    public class DataAccessExcelForDeploymentReportDetailsService : DataAccessRepository<ExcelforDeployment, Int32>
    {
        protected override string GetProcedureName(OperationType operation)
        {
            string spName = string.Empty;
            switch (operation)
            {
                case OperationType.GetAll:
                    spName = "USP_ExcelForDepolyment";
                    break;
                default:
                    spName = string.Empty;
                    break;
            }
            return spName;
        }
        protected override void FillParameters(OperationType operation, ExcelforDeployment instance, List<System.Data.Common.DbParameter> parameters)
        {

        }
        protected override List<ExcelforDeployment> ParseGetAllData(System.Data.DataSet data)
        {
            var GetAllData = data.Tables[0].AsEnumerable().Select(row =>
                     new ExcelforDeployment
                     {



                         CourseMasterID = row.ReadString("CourseMasterID"),
                         CourseName = row.ReadString("CourseName"),
                         CourseID = row.ReadString("CourseID"),
                         DeploymentFiscalYear = row.ReadString("DeploymentFiscalYear"),
                         Competency = row.ReadString("Competency"),
                         Skill = row.ReadString("Skill"),
                         Industry = row.ReadString("Industry"),
                         ProgramKnowledgeLevel = row.ReadString("ProgramKnowledgeLevel"),
                         CourseOverviewObjective = row.ReadString("CourseOverviewObjective"),
                         TargetAudience = row.ReadString("TargetAudience"),
                         AudienceLevel = row.ReadString("AudienceLevel"),
                         EstimatedCPE = row.ReadString("EstimatedCPE"),
                         SpecialNotice = row.ReadString("SpecialNotice"),
                         FunctionName = row.ReadString("FunctionName"),
                         CourseSponsor = row.ReadString("CourseSponsor"),
                         WhichSGSLSNSponsorLearning = row.ReadString("WhichSGSLSNSponsorLearning"),
                         SubjectMatterProfessional = row.ReadString("SubjectMatterProfessional"),
                         Vendor = row.ReadString("Vendor"),
                         ServiceNowID = row.ReadString("ServiceNowID"),
                         Descriptions = row.ReadString("Descriptions"),
                         IsRegulatoryorLegalRequirement = row.ReadString("IsRegulatoryorLegalRequirement"),
                         ProgramType = row.ReadString("ProgramType"),
                         DeliveryType = row.ReadString("DeliveryType"),
                         Duration = row.ReadString("Duration"),
                         FirstDeliveryDate = row.ReadString("FirstDeliveryDate"),
                         MaximumAttendeeCount = row.ReadString("MaximumAttendeeCount"),
                         MinimumAttendeeCount = row.ReadString("MinimumAttendeeCount"),
                         MaximumAttendeeWaitlist = row.ReadString("MaximumAttendeeWaitlist"),
                         Material = row.ReadString("Material"),
                         Collateral = row.ReadString("Collateral"),
                         RoomSetUpComments = row.ReadString("RoomSetUpComments"),
                         DeploymentFacilitatorConsideration = row.ReadString("DeploymentFacilitatorConsideration"),
                         LDIIntakeOwner = row.ReadString("LDIIntakeOwner"),
                         ProjectManagerContactMaster = row.ReadString("ProjectManagerContactMaster"),
                         InstructionalDesignerMaster = row.ReadString("InstructionalDesignerMaster"),
                         LevelOfEffort = row.ReadString("LevelOfEffort"),
                        // FoucsCourseOwner1 = row.ReadString("FoucsCourseOwner1"),
                         //FocusCourseOwner2 = row.ReadString("FocusCourseOwner2"),
                         CourseNotes = row.ReadString("CourseNotes"),
                         ProjectStatus = row.ReadString("ProjectStatus"),
                         Price = row.ReadString("Price"),
                         Currency = row.ReadString("Currency"),
                         DisplayCallCenter = row.ReadString("DisplayCallCenter"),

                         FieldOfStudy1 = row.ReadString("FieldOfStudy1"),
                         FieldOfStudy2 = row.ReadString("FieldOfStudy2"),
                         FieldOfStudy3 = row.ReadString("FieldOfStudy3"),
                         FieldOfStudy4 = row.ReadString("FieldOfStudy4"),

                         FOSCredit1 = row.ReadString("FOSCredit1"),
                         FOSCredit2 = row.ReadString("FOSCredit2"),
                         FOSCredit3 = row.ReadString("FOSCredit3"),
                         FOSCredit4 = row.ReadString("FOSCredit4"),

                         Status = row.ReadString("Status"),
                         OFFERING_TEMPLATE_NO = row.ReadString("OFFERING_TEMPLATE_NO"),
                         DevelopmentYear = row.ReadString("DevelopmentYear"),

                         //   IsRecordLocked = row.ReadString("FOSCreIsRecordLockeddit1"),
                         // IsvalueSelected = row.ReadString("IsvalueSelected"),


                         PrerequisiteCourseID1 = row.ReadString("PrerequisiteCourseID1"),
                         PrerequisiteCourseID2 = row.ReadString("PrerequisiteCourseID2"),
                         EquivalentCourseID1 = row.ReadString("EquivalentCourseID1"),
                         EquivalentCourseID2 = row.ReadString("EquivalentCourseID2"),
                         AudienceType1 = row.ReadString("AudienceType1"),
                         AudienceType2 = row.ReadString("AudienceType2"),


                         ServiceGroup1 = row.ReadString("ServiceGroup1"),
                         ServiceGroup2 = row.ReadString("ServiceGroup2"),
                         ServiceGroup3 = row.ReadString("ServiceGroup3"),
                         ServiceGroup4 = row.ReadString("ServiceGroup4"),


                         ServiceLine1 = row.ReadString("ServiceLine1"),
                         ServiceLine2 = row.ReadString("ServiceLine1"),
                         ServiceLine3 = row.ReadString("ServiceLine3"),
                         ServiceLine4 = row.ReadString("ServiceGroup4"),

                         ServiceNetwork1 = row.ReadString("ServiceNetwork1"),
                         ServiceNetwork2 = row.ReadString("ServiceNetwork2"),
                         ServiceNetwork3 = row.ReadString("ServiceNetwork3"),
                         ServiceNetwork4 = row.ReadString("ServiceNetwork4"),


                         CourseRecordURL = row.ReadString("CourseRecordURL"),
                         ClarizenStartDate = row.ReadString("ClarizenStartDate"),

                         FocusDomain = row.ReadString("FocusDomain"),
                         FocusRetired = row.ReadString("FocusRetired"),
                         FocusDiscFrom = row.ReadString("FocusDiscFrom"),
                         FocusDisplayedToLearner = row.ReadString("FocusDisplayedToLearner"),


          























                     }).ToList();

            return GetAllData;
        }
        protected override ExcelforDeployment Parse(System.Data.DataRow data)
        {
            return new ExcelforDeployment
            {


                CourseMasterID = data.ReadString("CourseMasterID"),
                CourseName = data.ReadString("CourseName"),
                CourseID = data.ReadString("CourseID"),
                DeploymentFiscalYear = data.ReadString("DeploymentFiscalYear"),
                Competency = data.ReadString("Competency"),
                Skill = data.ReadString("Skill"),
       
                Industry = data.ReadString("Industry"),
                ProgramKnowledgeLevel = data.ReadString("ProgramKnowledgeLevel"),
                CourseOverviewObjective = data.ReadString("CourseOverviewObjective"),
                TargetAudience = data.ReadString("TargetAudience"),
                AudienceLevel = data.ReadString("AudienceLevel"),
                EstimatedCPE = data.ReadString("EstimatedCPE"),
                SpecialNotice = data.ReadString("SpecialNotice"),
                FunctionName = data.ReadString("FunctionName"),
                CourseSponsor = data.ReadString("CourseSponsor"),
                WhichSGSLSNSponsorLearning = data.ReadString("WhichSGSLSNSponsorLearning"),
                SubjectMatterProfessional = data.ReadString("SubjectMatterProfessional"),
                Vendor = data.ReadString("Vendor"),
                ServiceNowID = data.ReadString("ServiceNowID"),
                Descriptions = data.ReadString("Descriptions"),
                IsRegulatoryorLegalRequirement = data.ReadString("IsRegulatoryorLegalRequirement"),
                ProgramType = data.ReadString("ProgramType"),
                DeliveryType = data.ReadString("DeliveryType"),
                Duration = data.ReadString("Duration"),
                FirstDeliveryDate = data.ReadString("FirstDeliveryDate"),
                MaximumAttendeeCount = data.ReadString("MaximumAttendeeCount"),
                MinimumAttendeeCount = data.ReadString("MinimumAttendeeCount"),
                MaximumAttendeeWaitlist = data.ReadString("MaximumAttendeeWaitlist"),
                Material = data.ReadString("Material"),
                Collateral = data.ReadString("Collateral"),
                RoomSetUpComments = data.ReadString("RoomSetUpComments"),
                DeploymentFacilitatorConsideration = data.ReadString("DeploymentFacilitatorConsideration"),
                LDIIntakeOwner = data.ReadString("LDIIntakeOwner"),
                ProjectManagerContactMaster = data.ReadString("ProjectManagerContactMaster"),
                InstructionalDesignerMaster = data.ReadString("InstructionalDesignerMaster"),
                LevelOfEffort = data.ReadString("LevelOfEffort"),
                //FoucsCourseOwner1 = data.ReadString("FoucsCourseOwner1"),
                //FocusCourseOwner2 = data.ReadString("FocusCourseOwner2"),
                CourseNotes = data.ReadString("CourseNotes"),
                ProjectStatus = data.ReadString("ProjectStatus"),
                Price = data.ReadString("Price"),
                Currency = data.ReadString("Currency"),
                DisplayCallCenter = data.ReadString("DisplayCallCenter"),

                FieldOfStudy1 = data.ReadString("FieldOfStudy1"),
                FieldOfStudy2 = data.ReadString("FieldOfStudy2"),
                FieldOfStudy3 = data.ReadString("FieldOfStudy3"),
                FieldOfStudy4 = data.ReadString("FieldOfStudy4"),


                FOSCredit1 = data.ReadString("FOSCredit1"),
                FOSCredit2 = data.ReadString("FOSCredit2"),
                FOSCredit3 = data.ReadString("FOSCredit3"),
                FOSCredit4 = data.ReadString("FOSCredit4"),

                    


                Status = data.ReadString("Status"),
                OFFERING_TEMPLATE_NO = data.ReadString("OFFERING_TEMPLATE_NO"),
                DevelopmentYear = data.ReadString("DevelopmentYear"),
                 //  IsRecordLocked = data.ReadString("IsRecordLocked"),


                    //IsvalueSelected = data.ReadString("IsvalueSelected"),
                PrerequisiteCourseID1 = data.ReadString("PrerequisiteCourseID1"),
                PrerequisiteCourseID2 = data.ReadString("PrerequisiteCourseID2"),
                EquivalentCourseID1 = data.ReadString("EquivalentCourseID1"),
                EquivalentCourseID2 = data.ReadString("EquivalentCourseID2"),
                AudienceType1 = data.ReadString("AudienceType1"),
                AudienceType2 = data.ReadString("AudienceType2"),

                ServiceGroup1 = data.ReadString("ServiceGroup1"),
                ServiceGroup2 = data.ReadString("ServiceGroup2"),
                ServiceGroup3 = data.ReadString("ServiceGroup3"),
                ServiceGroup4 = data.ReadString("ServiceGroup4"),
                ServiceLine1 = data.ReadString("ServiceLine1"),
                ServiceLine2= data.ReadString("ServiceLine2"),
                ServiceLine3 = data.ReadString("ServiceLine3"),
                ServiceLine4 = data.ReadString("ServiceLine4"),
                ServiceNetwork1 = data.ReadString("ServiceNetwork1"),
                ServiceNetwork2 = data.ReadString("ServiceNetwork2"),
                ServiceNetwork3 = data.ReadString("ServiceNetwork3"),
                ServiceNetwork4 = data.ReadString("ServiceNetwork4"),

                CourseRecordURL = data.ReadString("CourseRecordURL"),
                ClarizenStartDate = data.ReadString("ClarizenStartDate"),


                FocusDomain = data.ReadString("FocusDomain"),
                FocusRetired = data.ReadString("FocusRetired"),
                FocusDiscFrom = data.ReadString("FocusDiscFrom"),
                FocusDisplayedToLearner = data.ReadString("FocusDisplayedToLearner"),


              
            
              
             
             
             
               
                // Objectives = data.ReadString("Objectives"),
         
          
             
               
               
              /*  Status = data.ReadString("Status"),
                Status = data.ReadString("Status"),
                Status = data.ReadString("Status"),
                Status = data.ReadString("Status"),
                Status = data.ReadString("Status"),
                Status = data.ReadString("Status"),
                Status = data.ReadString("Status"),
                Status = data.ReadString("Status"),
                Status = data.ReadString("Status"),
                Status = data.ReadString("Status"),
                Status = data.ReadString("Status"),*/


            };
        }
    }
}




/*

CourseMaster.CourseMasterID,
	CourseMaster.CourseName,
	CourseMaster.DeploymentFiscalYear,
	CompetencyMaster.Competency,
	SkillMaster.Skill,

	IndustryMaster.Industry,
	ProgramKnowledgeLevelMaster.ProgramKnowledgeLevel,
	CourseMaster.CourseOverviewObjective,
	CourseMaster.TargetAudience,
	AudienceLevelMaster.AudienceLevel,
	CourseMaster.EstimatedCPE,

	SpecialNoticeMaster.SpecialNotice,
	FunctionMaster.FunctionName,
	CourseMaster.CourseSponsor,
	CourseMaster.WhichSGSLSNSponsorLearning,
	CourseMaster.SubjectMatterProfessional,
	CourseMaster.Vendor,

	CourseMaster.ServiceNowID,
	CourseMaster.Descriptions,
	IsRegulatoryorLegalRequirement.IsRegulatoryorLegalRequirement,
	ProgramTypeMaster.ProgramType,
	DeliveryTypeMaster.DeliveryType,

	CourseMaster.Duration,
	CourseMaster.FirstDeliveryDate,
	CourseMaster.MaximumAttendeeCount,
	CourseMaster.MinimumAttendeeCount,
	CourseMaster.MaximumAttendeeWaitlist,

	MaterialMaster.Material,
	CourseMaster.Collateral,
	CourseMaster.RoomSetUpComments,
	CourseMaster.DeploymentFacilitatorConsideration,
	LDIntakeOwnerMaster.LDIIntakeOwner,

	ProjectManagerContactMaster.ProjectManagerContactMaster,
	InstructionalDesignerMaster.InstructionalDesignerMaster,
	LevelOfEffortMaster.LevelOfEffort,
	CourseMaster.FoucsCourseOwner1,
	CourseMaster.FocusCourseOwner2,
	CourseMaster.CourseNotes,

	ProjectStatusMaster_TBD.ProjectStatus,
	CourseMaster.FocusDomain,
	CourseMaster.FocusRetired,
	CourseMaster.FocusDiscFrom,
	CourseMaster.FocusDisplayedToLearner,

	CourseMaster.CourseRecordURL,

	
	CourseMaster.ClarizenStartDate,

	CourseMaster.Price,
	CourseMaster.Currency,
	CourseMaster.DisplayCallCenter,
	FieldOfStudyMaster.FieldOfStudy,


	StatusMaster.Status,
	CourseMaster.OFFERING_TEMPLATE_NO,
	CourseMaster.DevelopmentYear,
	CourseMaster.IsRecordLocked,
	

	CourseMaster.CourseSingularityID,
	CourseMaster.IsvalueSelected
    --CourseMaster.PrerequisiteCourseID,
	--CourseMaster.EquivalentCourseID,
*/