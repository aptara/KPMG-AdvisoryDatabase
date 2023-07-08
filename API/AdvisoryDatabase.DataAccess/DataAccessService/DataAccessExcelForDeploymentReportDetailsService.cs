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
                        // CourseNotes = row.ReadString("CourseNotes"),
                        // ProjectStatus = row.ReadString("ProjectStatus"),
                         Price = row.ReadString("Price"),
                         Currency = row.ReadString("Currency"),
                         DisplayCallCenter = row.ReadString("DisplayCallCenter"),

                      /*   FieldOfStudy1 = row.ReadString("FieldOfStudy1"),
                         FieldOfStudy2 = row.ReadString("FieldOfStudy2"),
                         FieldOfStudy3 = row.ReadString("FieldOfStudy3"),
                         FieldOfStudy4 = row.ReadString("FieldOfStudy4"),

                         FOSCredit1 = row.ReadString("FOSCredit1"),
                         FOSCredit2 = row.ReadString("FOSCredit2"),
                         FOSCredit3 = row.ReadString("FOSCredit3"),
                         FOSCredit4 = row.ReadString("FOSCredit4"),
*/
                         Status = row.ReadString("Status"),
                         OFFERING_TEMPLATE_NO = row.ReadString("OFFERING_TEMPLATE_NO"),
                         DevelopmentYear = row.ReadString("DevelopmentYear"),

                         IsRecordLocked = row.ReadString("IsRecordLocked"),
                     


                     /*    PrerequisiteCourseID1 = row.ReadString("PrerequisiteCourseID1"),
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
                         ServiceNetwork4 = row.ReadString("ServiceNetwork4"),*/


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
                //CourseNotes = data.ReadString("CourseNotes"),
               // ProjectStatus = data.ReadString("ProjectStatus"),
                Price = data.ReadString("Price"),
                Currency = data.ReadString("Currency"),
                DisplayCallCenter = data.ReadString("DisplayCallCenter"),

           /*     FieldOfStudy1 = data.ReadString("FieldOfStudy1"),
                FieldOfStudy2 = data.ReadString("FieldOfStudy2"),
                FieldOfStudy3 = data.ReadString("FieldOfStudy3"),
                FieldOfStudy4 = data.ReadString("FieldOfStudy4"),


                FOSCredit1 = data.ReadString("FOSCredit1"),
                FOSCredit2 = data.ReadString("FOSCredit2"),
                FOSCredit3 = data.ReadString("FOSCredit3"),
                FOSCredit4 = data.ReadString("FOSCredit4"),

                    */


                Status = data.ReadString("Status"),
                OFFERING_TEMPLATE_NO = data.ReadString("OFFERING_TEMPLATE_NO"),
                DevelopmentYear = data.ReadString("DevelopmentYear"),
                IsRecordLocked = data.ReadString("IsRecordLocked"),

/*
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
*/
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







/*

public string FOSvalues { get; set; } // addd new 

public string SGSLSNValues { get; set; }//ad new
public string PrerequisiteCourseID { get; set; }// add new 
public string EquivalentCourseID { get; set; }// add new
public string AudienceType { get; set; }// add new



public string CourseMasterID { get; set; }//0
public string CourseID { get; set; }//1 

public string CourseName { get; set; }//2
public string DeploymentFiscalYear { get; set; }//3

public string Competency { get; set; }// add in sp --done
public string Skilltext { get; set; }//4  --------//Skilltext --done
public string IndustryText { get; set; }//5 ------IndustryText --done
public string ProgramKnowledgeLevel { get; set; }//6        
public string CourseOverviewObjective { get; set; }//7
public string TargetAudience { get; set; }//8
public string AudienceLevelText { get; set; }//9  ----------AudienceLevelText
public string EstimatedCPE { get; set; }//10
public string SpecialNotice { get; set; }//11
public string FunctionNameText { get; set; }//12 -------FunctionNameText
public string CourseSponsor { get; set; }//13
public string WhichSGSLSNSponsorLearning { get; set; }//14
public string SubjectMatterProfessional { get; set; }//15
public string Vendor { get; set; }//16
public string ServiceNowID { get; set; }//17
public string Descriptions { get; set; }//18
public string IsRegulatoryorLegalRequirement { get; set; }//19
public string ProgramType { get; set; }//20
public string DeliveryType { get; set; }//21
public string Duration { get; set; }//22
public string FirstDeliveryDate { get; set; }//23
public string MaximumAttendeeCount { get; set; }//24
public string MinimumAttendeeCount { get; set; }//25
public string MaximumAttendeeWaitlist { get; set; }//26
public string Material { get; set; }//27
public string Collateral { get; set; }//28
public string RoomSetUpComments { get; set; }//29
public string DeploymentFacilitatorConsideration { get; set; }//30
public string LDIIntakeOwner { get; set; }//31
public string ProjectManagerContactMaster { get; set; }//32
public string InstructionalDesignerMaster { get; set; }//33
public string LevelOfEffort { get; set; }//34
public string FoucsCourseOwner1 { get; set; }//35
public string FocusCourseOwner2 { get; set; }//36
public string CourseNotes { get; set; }//37
                                       // public string ProjectStatus { get; set; }//38  ----------which select
public string Price { get; set; }//39
public string Currency { get; set; }//40
public string DisplayCallCenter { get; set; }//41DisplayCallCenter
*//*    public string FieldOfStudy1 { get; set; }//42
    public string FieldOfStudy2 { get; set; }//43
    public string FieldOfStudy3 { get; set; }//44
    public string FieldOfStudy4 { get; set; }//45
    public string FOSCredit1 { get; set; }//46
    public string FOSCredit2 { get; set; }//47
    public string FOSCredit3 { get; set; }//48
    public string FOSCredit4 { get; set; }//49


    public string PrerequisiteCourseID1 { get; set; }//50
    public string PrerequisiteCourseID2 { get; set; }//51
    public string EquivalentCourseID1 { get; set; }//52
    public string EquivalentCourseID2 { get; set; }//53
    public string AudienceType1 { get; set; }//54
    public string AudienceType2 { get; set; }//55

    public string ServiceGroup1 { get; set; }//56
    public string ServiceGroup2 { get; set; }//57
    public string ServiceGroup3 { get; set; }//58
    public string ServiceGroup4 { get; set; }//59 
    public string ServiceLine1 { get; set; }//60
    public string ServiceLine2 { get; set; }//61
    public string ServiceLine3 { get; set; }//62
    public string ServiceLine4 { get; set; }//63
    public string ServiceNetwork1 { get; set; }//64
    public string ServiceNetwork2 { get; set; }//65
    public string ServiceNetwork3 { get; set; }//66
    public string ServiceNetwork4 { get; set; }//67*//*
public string Status { get; set; }//68 -----------which select --final 
public string OFFERING_TEMPLATE_NO { get; set; }//69
public string DevelopmentYear { get; set; }//70
public string IsRecordLocked { get; set; }//71
public string ClarizenStartDate { get; set; }//72
public string CourseRecordURL { get; set; }//73
public string FocusDomain { get; set; }//74  --------hard code
public string FocusRetired { get; set; }//75  ----hard code 2
public string FocusDiscFrom { get; set; }//76 ---- hard code 3
public string FocusDisplayedToLearner { get; set; }//77 --hard code4

public string FOSvalues { get; set; } // addd new 

public string SGSLSNValues { get; set; }//ad new
public string PrerequisiteCourseID { get; set; }// add new 
public string EquivalentCourseID { get; set; }// add new
public string AudienceType { get; set; }// add new
*/