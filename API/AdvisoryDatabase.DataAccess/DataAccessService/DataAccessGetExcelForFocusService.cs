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
    public class DataAccessGetExcelForFocusDetails : DataAccessRepository<GetExcelForFocusInfo, Int32>
    {
        

        protected override string GetProcedureName(OperationType operation)
        {
            string spName = string.Empty;
            switch (operation)
            {
                case OperationType.GetAll:
                    spName = "USP_ExcelForFocus";
                    break;
                /*  case OperationType.GetAll:
                      spName = "CourseOwnerDetail";
                      break;*/
                default:
                    spName = string.Empty;
                    break;
            }
            return spName;
        }

        protected override void FillParameters(OperationType operation, GetExcelForFocusInfo instance, List<System.Data.Common.DbParameter> parameters)
        {
      switch (operation)
        {
        case OperationType.GetAll:

          parameters.Add(DbHelper.CreateParameter("CourseMasterID", instance.CourseMasterIDs));
          break;

        

        case OperationType.Get:
          parameters.Add(DbHelper.CreateParameter("CourseMasterID", instance.CourseMasterIDs));
          break;

        default:
          break;
         }
      
        }

        protected override List<GetExcelForFocusInfo> ParseGetAllData(System.Data.DataSet data)
        {
            var GetAllData = data.Tables[0].AsEnumerable().Select(row =>
                     new GetExcelForFocusInfo
                     {


                         CourseMasterID = Int32.Parse(row.ReadString("CourseMasterID")),
                         FORDLSONLY = row.ReadString("FORDLSONLY"),
                         CourseID = row.ReadString("CourseID"),
                         Version = row.ReadString("Version"),

                         CourseName = row.ReadString("CourseName"),

                         FocusDomain = row.ReadString("FocusDomain"),

                         FirstDeliveryDate = row.ReadString("FirstDeliveryDate"),

                         FocusDiscFrom = row.ReadString("FocusDiscFrom"),


                         Currency = row.ReadString("Currency"),
                         Price = row.ReadString("Price"),
                      
                         CourseOverviewObjective = row.ReadString("CourseOverviewObjective"),
                        
                         FocusDisplayedToLearner = row.ReadString("FocusDisplayedToLearner"),
                         DisplayCallCenter = row.ReadString("DisplayCallCenter"),
                         AudienceType1 = row.ReadString("AudienceType1"),
                         AudienceType2 = row.ReadString("AudienceType2"),
                         Vendor = row.ReadString("Vendor"),
                         FunctionName = row.ReadString("FunctionName"),
                         DeploymentFiscalYear = row.ReadString("DeploymentFiscalYear"),
                         ProgramKnowledgeLevel = row.ReadString("ProgramKnowledgeLevel"),
                         EstimatedCPE = row.ReadString("EstimatedCPE"),
                         TargetAudience = row.ReadString("TargetAudience"),

                         SpecialNotice = row.ReadString("SpecialNotice"),
                         FoucsCourseOwner1 = row.ReadString("FoucsCourseOwner1"),
                         FocusCourseOwner2 = row.ReadString("FocusCourseOwner2"),
                         PrerequisiteCourseID1 = row.ReadString("PrerequisiteCourseID1"),
                         EquivalentCourseID1 = row.ReadString("EquivalentCourseID1"),
                         DeliveryType = row.ReadString("DeliveryType"),
                         Duration = row.ReadString("Duration"),
                         FieldOfStudy1 = row.ReadString("FieldOfStudy1"),
                         FOSCredit1 = row.ReadString("FOSCredit1"),
                         FieldOfStudy2 = row.ReadString("FieldOfStudy2"),
                         FOSCredit2 = row.ReadString("FOSCredit2"),
                         MinimumAttendeeCount = row.ReadString("MinimumAttendeeCount"),
                         MaximumAttendeeCount = row.ReadString("MaximumAttendeeCount"),
                         MaximumAttendeeWaitlist = row.ReadString("MaximumAttendeeWaitlist"),
                         /*
                                                 
                                                 
                                                 
                                                  PrerequisiteCourseID2 = row.ReadString("PrerequisiteCourseID2"),
                                                 
                                                  EquivalentCourseID2 = row.ReadString("EquivalentCourseID2"),
       
                                                  FocusTemplateName = row.ReadString("FocusTemplateName"),
                                                  ErrorMessage = row.ReadString("ErrorMessage"),

                                                  IsAllowedToFocusRDI = row.ReadString("IsAllowedToFocusRDI")
                                              */

                     }).ToList();

            return GetAllData;
        }

        protected override GetExcelForFocusInfo Parse(System.Data.DataRow data)
        {
            return new GetExcelForFocusInfo
            {

                CourseMasterID = Int32.Parse(data.ReadString("CourseMasterID")),


                FORDLSONLY = data.ReadString("FORDLSONLY"),
                CourseID = data.ReadString("CourseID"),
                Version = data.ReadString("Version"),

                CourseName = data.ReadString("CourseName"),
                FocusDomain = data.ReadString("FocusDomain"),
                FirstDeliveryDate = data.ReadString("FirstDeliveryDate"),
                FocusDiscFrom = data.ReadString("FocusDiscFrom"),
                Currency = data.ReadString("Currency"),
                Price = data.ReadString("Price"),        
                CourseOverviewObjective = data.ReadString("CourseOverviewObjective"),
                FocusDisplayedToLearner = data.ReadString("FocusDisplayedToLearner"),
                DisplayCallCenter = data.ReadString("DisplayCallCenter"),
                AudienceType1 = data.ReadString("AudienceType1"),
                AudienceType2 = data.ReadString("AudienceType2"),
                Vendor = data.ReadString("Vendor"),
                FunctionName = data.ReadString("FunctionName"),
                DeploymentFiscalYear = data.ReadString("DeploymentFiscalYear"),
                ProgramKnowledgeLevel = data.ReadString("ProgramKnowledgeLevel"),
                EstimatedCPE = data.ReadString("EstimatedCPE"),
                TargetAudience = data.ReadString("TargetAudience"),
                SpecialNotice = data.ReadString("SpecialNotice"),
                FoucsCourseOwner1 = data.ReadString("FoucsCourseOwner1"),
                FocusCourseOwner2 = data.ReadString("FocusCourseOwner2"),
                PrerequisiteCourseID1 = data.ReadString("PrerequisiteCourseID1"),
                EquivalentCourseID1 = data.ReadString("EquivalentCourseID1"),
                DeliveryType = data.ReadString("DeliveryType"),
                Duration = data.ReadString("Duration"),
                FieldOfStudy1 = data.ReadString("FieldOfStudy1"),
                FOSCredit1 = data.ReadString("FOSCredit1"),
                FieldOfStudy2 = data.ReadString("FieldOfStudy2"),
                FOSCredit2 = data.ReadString("FOSCredit2"),
                MinimumAttendeeCount = data.ReadString("MinimumAttendeeCount"),
                MaximumAttendeeCount = data.ReadString("MaximumAttendeeCount"),
                MaximumAttendeeWaitlist = data.ReadString("MaximumAttendeeWaitlist"),

                /*
                               
                              
                             
                                PrerequisiteCourseID2 = data.ReadString("PrerequisiteCourseID2"),
                              
                                EquivalentCourseID2 = data.ReadString("EquivalentCourseID2"),


                    
                                FocusTemplateName = data.ReadString("FocusTemplateName"),
                                ErrorMessage = data.ReadString("ErrorMessage"),
                                IsAllowedToFocusRDI = data.ReadString("IsAllowedToFocusRDI"),
                                *//* CourseMasterIDs = data.ReadString("CourseMasterIDs")*//*
                                //SubjectMatterProfessional = data.ReadString("SubjectMatterProfessional")
                */

            };
        }


    }
}


/*

public string FORDLSONLY { get; set; } //add new
public string CourseID { get; set; }

public string LeaveBlank { get; set; }
public string CourseName { get; set; }


public string FocusDomain { get; set; }

public string FirstDeliveryDate { get; set; }
public string FocusDiscFrom { get; set; }
public string Currency { get; set; }
public string Price { get; set; }
public string CourseOverviewObjective { get; set; }

public string FocusDisplayedToLearner { get; set; }
public string DisplayCallCenter { get; set; }
public string AudienceType1 { get; set; }
public string AudienceType2 { get; set; }
public string Vendor { get; set; } //addnew
public string FunctionName { get; set; }
public string DeploymentFiscalYear { get; set; }

public string ProgramKnowledgeLevel { get; set; }
public string EstimatedCPE { get; set; }

public string TargetAudience { get; set; }
public string SpecialNotice { get; set; }
public string FoucsCourseOwner1 { get; set; }
public string FocusCourseOwner2 { get; set; }
public string PrerequisiteCourseID1 { get; set; }
public string EquivalentCourseID1 { get; set; }
public string DeliveryType { get; set; }
public string Duration { get; set; }
public string FieldOfStudy1 { get; set; }
public string CPECrdit { get; set; } //FOS credit..?
public string FieldOfStudy2 { get; set; }

public string CPECrdit2 { get; set; }
public string MinimumAttendeeCount { get; set; }

public string MaximumAttendeeCount { get; set; }

public string MaximumAttendeeWaitlist { get; set; }
*/