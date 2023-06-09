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
                         ID = row.ReadString("ID"),
                         CourseID = row.ReadString("CourseID"),
                         Version = row.ReadString("Version"),

                         CourseName = row.ReadString("CourseName"),

                         CourseDomain = row.ReadString("CourseDomain"),

                         AvailableFrom = row.ReadString("AvailableFrom"),

                         DiscontinuedFrom = row.ReadString("DiscontinuedFrom"),


                         Currency = row.ReadString("Currency"),
                         Price = row.ReadString("Price"),
                      
                         CourseOverviewObjective = row.ReadString("CourseOverviewObjective"),

                         DisplaytoLearner = row.ReadString("DisplaytoLearner"),
                         DisplaytoCallCenter = row.ReadString("DisplaytoCallCenter"),
                         AudienceType1 = row.ReadString("AudienceType1"),
                         AudienceType2 = row.ReadString("AudienceType2"),
                         Vendor = row.ReadString("Vendor"),
                         FunctionName = row.ReadString("FunctionName"),
                         DevelopmentYear = row.ReadString("DevelopmentYear"),
                         ProgramKnowledgeLevel = row.ReadString("ProgramKnowledgeLevel"),
                         EstimatedCPE = row.ReadString("EstimatedCPE"),
                         TargetAudience = row.ReadString("TargetAudience"),

                         SpecialNotice = row.ReadString("SpecialNotice"),
                         FoucsCourseOwner1 = row.ReadString("FoucsCourseOwner1"),
                         FocusCourseOwner2 = row.ReadString("FocusCourseOwner2"),
                         PrerequisiteCourseID1 = row.ReadString("PrerequisiteCourseID1"),
                         PREREQUISITE_VERSION1 = row.ReadString("PREREQUISITE_VERSION1"),//
                      
                         
                         PrerequisiteCourseID2 = row.ReadString("PrerequisiteCourseID2"),
                         PREREQUISITE_VERSION2 = row.ReadString("PREREQUISITE_VERSION2"),//
                         EquivalentCourseID1 = row.ReadString("EquivalentCourseID1"),

                         EQUIVALENT_VERSION1 = row.ReadString("EQUIVALENT_VERSION1"),//
                         EquivalentCourseID2 = row.ReadString("EquivalentCourseID2"),

                         EQUIVALENT_VERSION2 = row.ReadString("EQUIVALENT_VERSION2"),//
                         DeliveryType = row.ReadString("DeliveryType"),
                         Duration = row.ReadString("Duration"),
                         FieldOfStudy1 = row.ReadString("FieldOfStudy1"),
                         FOSCredit1 = row.ReadString("FOSCredit1"),
                         FieldOfStudy2 = row.ReadString("FieldOfStudy2"),
                         FOSCredit2 = row.ReadString("FOSCredit2"),
                         FieldOfStudy3 = row.ReadString("FieldOfStudy3"),
                         MinimumAttendeeCount = row.ReadString("MinimumAttendeeCount"),
                         MaximumAttendeeCount = row.ReadString("MaximumAttendeeCount"),
                         MaximumAttendeeWaitlist = row.ReadString("MaximumAttendeeWaitlist"),
                         FocusTemplateName = row.ReadString("FocusTemplateName"),
                         ErrorMessage = row.ReadString("ErrorMessage"),
                         OFFERING_TEMPLATE_NO = row.ReadString("CourseID"),
                         IsAllowedToFocusRDI = row.ReadString("IsAllowedToFocusRDI")


                     }).ToList();

            return GetAllData;
        }

        protected override GetExcelForFocusInfo Parse(System.Data.DataRow data)
        {
            return new GetExcelForFocusInfo
            {

                CourseMasterID = Int32.Parse(data.ReadString("CourseMasterID")),

                ID = data.ReadString("ID"),
                CourseID = data.ReadString("CourseID"),
                Version = data.ReadString("Version"),
                CourseName = data.ReadString("CourseName"),
                CourseDomain = data.ReadString("CourseDomain"),
                AvailableFrom = data.ReadString("AvailableFrom"),
                DiscontinuedFrom = data.ReadString("DiscontinuedFrom"),
                Currency = data.ReadString("Currency"),
                Price = data.ReadString("Price"),        
                CourseOverviewObjective = data.ReadString("CourseOverviewObjective"),
                DisplaytoLearner = data.ReadString("DisplaytoLearner"),
                DisplaytoCallCenter = data.ReadString("DisplaytoCallCenter"),
                AudienceType1 = data.ReadString("AudienceType1"),
                AudienceType2 = data.ReadString("AudienceType2"),
                Vendor = data.ReadString("Vendor"),
                FunctionName = data.ReadString("FunctionName"),
                DevelopmentYear = data.ReadString("DevelopmentYear"),
                ProgramKnowledgeLevel = data.ReadString("ProgramKnowledgeLevel"),
                EstimatedCPE = data.ReadString("EstimatedCPE"),
                TargetAudience = data.ReadString("TargetAudience"),
                SpecialNotice = data.ReadString("SpecialNotice"),
                FoucsCourseOwner1 = data.ReadString("FoucsCourseOwner1"),
                FocusCourseOwner2 = data.ReadString("FocusCourseOwner2"),
                PrerequisiteCourseID1 = data.ReadString("PrerequisiteCourseID1"),

                PREREQUISITE_VERSION1 = data.ReadString("PREREQUISITE_VERSION1"),//

                PrerequisiteCourseID2 = data.ReadString("PrerequisiteCourseID2"),

                PREREQUISITE_VERSION2 = data.ReadString("PREREQUISITE_VERSION2"),//

                EquivalentCourseID1 = data.ReadString("EquivalentCourseID1"),

                EQUIVALENT_VERSION1 = data.ReadString("EQUIVALENT_VERSION1"),//

                EquivalentCourseID2 = data.ReadString("EquivalentCourseID2"),

                EQUIVALENT_VERSION2 = data.ReadString("EQUIVALENT_VERSION2"),//
             
           
                DeliveryType = data.ReadString("DeliveryType"),
                Duration = data.ReadString("Duration"),
                FieldOfStudy1 = data.ReadString("FieldOfStudy1"),
                FOSCredit1 = data.ReadString("FOSCredit1"),
                FieldOfStudy2 = data.ReadString("FieldOfStudy2"),
                FOSCredit2 = data.ReadString("FOSCredit2"),
                FieldOfStudy3 = data.ReadString("FieldOfStudy3"),
                FOSCredit3 = data.ReadString("FOSCredit3"),
                FieldOfStudy4 = data.ReadString("FieldOfStudy4"),
                FOSCredit4 = data.ReadString("FOSCredit4"),
                MinimumAttendeeCount = data.ReadString("MinimumAttendeeCount"),
                MaximumAttendeeCount = data.ReadString("MaximumAttendeeCount"),
                MaximumAttendeeWaitlist = data.ReadString("MaximumAttendeeWaitlist"),
               
               
                FocusTemplateName = data.ReadString("FocusTemplateName"),
                ErrorMessage = data.ReadString("ErrorMessage"),
                OFFERING_TEMPLATE_NO = data.ReadString("CourseID"),
                IsAllowedToFocusRDI = data.ReadString("IsAllowedToFocusRDI")
                               
            };
        }


    }
}

