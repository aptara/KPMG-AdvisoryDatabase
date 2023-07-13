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
                         Skilltext = row.ReadString("Skilltext"),
                         IndustryText = row.ReadString("IndustryText"),
                         ProgramKnowledgeLevel = row.ReadString("ProgramKnowledgeLevel"),
                         CourseOverviewObjective = row.ReadString("CourseOverviewObjective"),
                         TargetAudience = row.ReadString("TargetAudience"),
                         AudienceLevelText = row.ReadString("AudienceLevelText"),
                         EstimatedCPE = row.ReadString("EstimatedCPE"),
                         SpecialNotice = row.ReadString("SpecialNotice"),
                         FunctionNameText = row.ReadString("FunctionNameText"),
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
                         FoucsCourseOwner1 = row.ReadString("FoucsCourseOwner1"),
                        FocusCourseOwner2 = row.ReadString("FocusCourseOwner2"),
                       
                         Price = row.ReadString("Price"),
                         Currency = row.ReadString("Currency"),
                         DisplayCallCenter = row.ReadString("DisplayCallCenter"),

                         Status = row.ReadString("Status"),
                         OFFERING_TEMPLATE_NO = row.ReadString("OFFERING_TEMPLATE_NO"),
                         DevelopmentYear = row.ReadString("DevelopmentYear"),

                         IsRecordLocked = row.ReadString("IsRecordLocked"),
                    
                         CourseRecordURL = row.ReadString("CourseRecordURL"),
                         ClarizenStartDate = row.ReadString("ClarizenStartDate"),

                         FocusDomain = row.ReadString("FocusDomain"),
                         FocusRetired = row.ReadString("FocusRetired"),
                         FocusDiscFrom = row.ReadString("FocusDiscFrom"),
                         FocusDisplayedToLearner = row.ReadString("FocusDisplayedToLearner"),

                         FOSvalues = row.ReadString("FOSvalues"),
                         SGSLSNValues = row.ReadString("SGSLSNValues"),
                         PrerequisiteCourseID = row.ReadString("PrerequisiteCourseID"),
                         EquivalentCourseID = row.ReadString("EquivalentCourseID"),
                         AudienceType = row.ReadString("AudienceType"),


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
                Skilltext = data.ReadString("Skilltext"),

                IndustryText = data.ReadString("IndustryText"),
                ProgramKnowledgeLevel = data.ReadString("ProgramKnowledgeLevel"),
                CourseOverviewObjective = data.ReadString("CourseOverviewObjective"),
                TargetAudience = data.ReadString("TargetAudience"),
                AudienceLevelText = data.ReadString("AudienceLevelText"),
                EstimatedCPE = data.ReadString("EstimatedCPE"),
                SpecialNotice = data.ReadString("SpecialNotice"),
                FunctionNameText = data.ReadString("FunctionNameText"),
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
                FoucsCourseOwner1 = data.ReadString("FoucsCourseOwner1"),
                FocusCourseOwner2 = data.ReadString("FocusCourseOwner2"),
         
                Price = data.ReadString("Price"),
                Currency = data.ReadString("Currency"),
                DisplayCallCenter = data.ReadString("DisplayCallCenter"),


                Status = data.ReadString("Status"),
                OFFERING_TEMPLATE_NO = data.ReadString("OFFERING_TEMPLATE_NO"),
                DevelopmentYear = data.ReadString("DevelopmentYear"),
                IsRecordLocked = data.ReadString("IsRecordLocked"),

                CourseRecordURL = data.ReadString("CourseRecordURL"),
                ClarizenStartDate = data.ReadString("ClarizenStartDate"),


                FocusDomain = data.ReadString("FocusDomain"),
                FocusRetired = data.ReadString("FocusRetired"),
                FocusDiscFrom = data.ReadString("FocusDiscFrom"),
                FocusDisplayedToLearner = data.ReadString("FocusDisplayedToLearner"),


                FOSvalues = data.ReadString("FOSvalues"),
                SGSLSNValues = data.ReadString("SGSLSNValues"),
                PrerequisiteCourseID = data.ReadString("PrerequisiteCourseID"),
                EquivalentCourseID = data.ReadString("EquivalentCourseID"),
                AudienceType = data.ReadString("AudienceType")

            };
        }
    }
}






