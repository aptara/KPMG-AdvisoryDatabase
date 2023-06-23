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
                         CourseName = row.ReadString("CourseName"),
                         //CourseOwner = row.ReadString("CourseOwner"),
                         // FieldOfStudy = row.ReadString("FieldOfStudy"),

                         FieldOfStudy1 = row.ReadString("FieldOfStudy1"),

                         FieldOfStudy2 = row.ReadString("FieldOfStudy2"),

                         FieldOfStudy3 = row.ReadString("FieldOfStudy3"),

                         FieldOfStudy4 = row.ReadString("FieldOfStudy4"),





                         DeliveryType = row.ReadString("DeliveryType"),
                         EstimatedCPE = row.ReadString("EstimatedCPE"),
                         CourseID = row.ReadString("CourseID"),
                         CourseOverviewObjective = row.ReadString("CourseOverviewObjective"),
                         //   Objectives = row.ReadString("Objectives")
                         MaximumAttendeeCount = row.ReadString("MaximumAttendeeCount"),
                         MaximumAttendeeWaitlist = row.ReadString("MaximumAttendeeWaitlist"),
                         MinimumAttendeeCount = row.ReadString("MinimumAttendeeCount"),
                         PrerequisiteCourseID1 = row.ReadString("PrerequisiteCourseID1"),
                         PrerequisiteCourseID2 = row.ReadString("PrerequisiteCourseID2"),
                         EquivalentCourseID1 = row.ReadString("EquivalentCourseID1"),
                         EquivalentCourseID2 = row.ReadString("EquivalentCourseID2"),
                         FirstDeliveryDate = row.ReadString("FirstDeliveryDate"),

                         Duration = row.ReadString("Duration"),
                         FocusCourseOwner2 = row.ReadString("FocusCourseOwner2"),
                         FoucsCourseOwner1 = row.ReadString("FoucsCourseOwner1"),
                         FocusDomain = row.ReadString("FocusDomain"),
                         FocusDiscFrom = row.ReadString("FocusDiscFrom"),
                         FocusDisplayedToLearner = row.ReadString("FocusDisplayedToLearner"),
                         DeploymentFiscalYear = row.ReadString("DeploymentFiscalYear"),
                         Price = row.ReadString("Price"),
                         Currency = row.ReadString("Currency"),
                         DisplayCallCenter = row.ReadString("DisplayCallCenter"),
                         TargetAudience = row.ReadString("TargetAudience"),
                         AudienceType1 = row.ReadString("AudienceType1"),
                         AudienceType2 = row.ReadString("AudienceType2"),
                         FunctionName = row.ReadString("FunctionName"),

                         ProgramKnowledgeLevel = row.ReadString("ProgramKnowledgeLevel"),
                         SpecialNotice = row.ReadString("SpecialNotice"),
                         FocusTemplateName = row.ReadString("FocusTemplateName"),
                         ErrorMessage = row.ReadString("ErrorMessage"),
                       
                         IsAllowedToFocusRDI = row.ReadString("IsAllowedToFocusRDI")
                         /* CourseMasterIDs = row.ReadString("CourseMasterIDs")*/

                         // SubjectMatterProfessional = row.ReadString("SubjectMatterProfessional")
                      /*   IsAllowedToFocusRDI NCHAR(10),
                         ErrorMessage NVARCHAR(MAX),
                         FocusTemplateName NVARCHAR(MAX),
                         */



                     }).ToList();

            return GetAllData;
        }

        protected override GetExcelForFocusInfo Parse(System.Data.DataRow data)
        {
            return new GetExcelForFocusInfo
            {

                CourseMasterID = Int32.Parse(data.ReadString("CourseMasterID")),


                CourseName = data.ReadString("CourseOwnerID"),
                //CourseOwner = data.ReadString("CourseOwner"),
                // FieldOfStudy = data.ReadString("FieldOfStudy"),

                FieldOfStudy1 = data.ReadString("FieldOfStudy1"),
                FieldOfStudy2 = data.ReadString("FieldOfStudy2"),
                FieldOfStudy3 = data.ReadString("FieldOfStudy3"),
                FieldOfStudy4 = data.ReadString("FieldOfStudy4"),


                DeliveryType = data.ReadString("DeliveryType"),
                EstimatedCPE = data.ReadString("EstimatedCPE"),
                CourseID = data.ReadString("CourseID"),
                CourseOverviewObjective = data.ReadString("CourseOverviewObjective"),
                //Objectives = data.ReadString("Objectives")
                MaximumAttendeeCount = data.ReadString("MaximumAttendeeCount"),
                MaximumAttendeeWaitlist = data.ReadString("MaximumAttendeeWaitlist"),
                MinimumAttendeeCount = data.ReadString("MinimumAttendeeCount"),
                PrerequisiteCourseID1 = data.ReadString("PrerequisiteCourseID1"),
                PrerequisiteCourseID2 = data.ReadString("PrerequisiteCourseID2"),
                EquivalentCourseID1 = data.ReadString("EquivalentCourseID1"),
                EquivalentCourseID2 = data.ReadString("EquivalentCourseID2"),

                FirstDeliveryDate = data.ReadString("FirstDeliveryDate"),


                FocusCourseOwner2 = data.ReadString("FocusCourseOwner2"),
                FoucsCourseOwner1 = data.ReadString("FoucsCourseOwner1"),
                Duration = data.ReadString("Duration"),
                FocusDomain = data.ReadString("FocusDomain"),
                FocusDiscFrom = data.ReadString("FocusDiscFrom"),
                FocusDisplayedToLearner = data.ReadString("FocusDisplayedToLearner"),
                DeploymentFiscalYear = data.ReadString("DeploymentFiscalYear"),
                Price = data.ReadString("Price"),
                Currency = data.ReadString("Currency"),
                DisplayCallCenter = data.ReadString("DisplayCallCenter"),
                TargetAudience = data.ReadString("TargetAudience"),
                AudienceType1 = data.ReadString("AudienceType1"),
                AudienceType2 = data.ReadString("AudienceType2"),
                FunctionName = data.ReadString("FunctionName"),

                ProgramKnowledgeLevel = data.ReadString("ProgramKnowledgeLevel"),
                SpecialNotice = data.ReadString("SpecialNotice"),
                FocusTemplateName = data.ReadString("FocusTemplateName"),
                ErrorMessage = data.ReadString("ErrorMessage"),
                IsAllowedToFocusRDI = data.ReadString("IsAllowedToFocusRDI"),
                /* CourseMasterIDs = data.ReadString("CourseMasterIDs")*/
                //SubjectMatterProfessional = data.ReadString("SubjectMatterProfessional")


            };
        }


    }
}


