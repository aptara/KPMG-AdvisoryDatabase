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
    public class DataAccessCourseListDetailService : DataAccessRepository<GetCourseList, Int32>
    {
        protected override string GetProcedureName(OperationType operation)
        {
            string spName = string.Empty;
            switch (operation)
            {
                case OperationType.GetAll:

                    spName = "USP_GetCourseList";
                    break;
                default:
                    spName = string.Empty;
                    break;
            }
            return spName;
        }

        protected override void FillParameters(OperationType operation, GetCourseList instance, List<System.Data.Common.DbParameter> parameters)
        {

        }

        protected override List<GetCourseList> ParseGetAllData(System.Data.DataSet data)
        {
            var GetAllData = data.Tables[0].AsEnumerable().Select(row =>
                     new GetCourseList
                     {
                          CourseMasterID = row.ReadString("CourseMasterID"),
                          CourseID = row.ReadString("CourseID"),
                          CourseName = row.ReadString("CourseName"),
                          TargetAudience = row.ReadString("TargetAudience"),
                          FirstDeliveryDate = row.ReadString("FirstDeliveryDate"),
                         // FieldOfStudy1 = row.ReadString("FieldOfStudy1"),
                         // FieldOfStudy2 = row.ReadString("FieldOfStudy2"),
                         //FieldOfStudy3 = row.ReadString("FieldOfStudy3"),
                         //FieldOfStudy4 = row.ReadString("FieldOfStudy4"),
                          EstimatedCPE = row.ReadString("EstimatedCPE"),
                         //Skilltext = row.ReadString("Skilltext"),
                          ProgramTypeText = row.ReadString("ProgramTypeText"),
                          DeliveryTypeText = row.ReadString("DeliveryTypeText"),
                          LDIIntakeOwnerText = row.ReadString("LDIIntakeOwnerText"),
                          ProgramKnowledgeLeveltext = row.ReadString("ProgramKnowledgeLeveltext"),
                          InstructionalDesignertext = row.ReadString("InstructionalDesignertext"),
                          ProjectManagerContactMasterText = row.ReadString("ProjectManagerContactMasterText"),
                          CompetencyText = row.ReadString("CompetencyText"),
                      //   IndustryText = row.ReadString("IndustryText"),
                          CourseSponsor = row.ReadString("CourseSponsor"),
                          Vendor = row.ReadString("Vendor"),
                          ServiceNowID = row.ReadString("ServiceNowID"),
                         /*   ServiceNowID = row.ReadString("ServiceNowID"),
                            ServiceGroup1 = row.ReadString("ServiceGroup1"),
                            ServiceGroup2 = row.ReadString("ServiceGroup2"),
                            ServiceGroup3 = row.ReadString("ServiceGroup3"),
                            ServiceGroup4 = row.ReadString("ServiceGroup4"),
                            ServiceLine1 = row.ReadString("ServiceLine1"),
                            ServiceLine2 = row.ReadString("ServiceLine2"),
                            ServiceLine3 = row.ReadString("ServiceLine3"),
                            ServiceLine4 = row.ReadString("ServiceLine4"),
                            ServiceNetwork1 = row.ReadString("ServiceNetwork1"),
                            ServiceNetwork2 = row.ReadString("ServiceNetwork2"),
                            ServiceNetwork3 = row.ReadString("ServiceNetwork3"),
                            ServiceNetwork4 = row.ReadString("ServiceNetwork4"),*/
                              Duration = row.ReadString("Duration"),
                              FocusDomain = row.ReadString("FocusDomain"),
                              StatusText = row.ReadString("StatusText")
     

                     }).ToList();

            return GetAllData;
        }
        protected override GetCourseList Parse(System.Data.DataRow data)
        {
            return new GetCourseList
            {


                CourseMasterID=data.ReadString("CourseMasterID"),
                CourseID = data.ReadString("CourseID"),
                CourseName = data.ReadString("CourseName"),
                 TargetAudience = data.ReadString("TargetAudience"),
                FirstDeliveryDate = data.ReadString("FirstDeliveryDate"),
              //  FieldOfStudy1 = data.ReadString("FieldOfStudy1"),
              //  FieldOfStudy2 = data.ReadString("FieldOfStudy2"),
               // FieldOfStudy3 = data.ReadString("FieldOfStudy3"),
               // FieldOfStudy4 = data.ReadString("FieldOfStudy4"),
                EstimatedCPE = data.ReadString("EstimatedCPE"),
              //  Skilltext = data.ReadString("Skilltext"),
                ProgramTypeText = data.ReadString("ProgramTypeText"),
                DeliveryTypeText = data.ReadString("DeliveryTypeText"),
                LDIIntakeOwnerText = data.ReadString("LDIIntakeOwnerText"),
                ProgramKnowledgeLeveltext = data.ReadString("ProgramKnowledgeLeveltext"),
                InstructionalDesignertext = data.ReadString("InstructionalDesignertext"),
                ProjectManagerContactMasterText = data.ReadString("ProjectManagerContactMasterText"),
                CompetencyText = data.ReadString("CompetencyText"),
                //IndustryText = data.ReadString("IndustryText"),
                CourseSponsor = data.ReadString("CourseSponsor"),
                Vendor = data.ReadString("Vendor"),
                ServiceNowID = data.ReadString("ServiceNowID"),
/*
                ServiceGroup1 = data.ReadString("ServiceGroup1"),
                ServiceGroup2 = data.ReadString("ServiceGroup2"),
                ServiceGroup3 = data.ReadString("ServiceGroup3"),
                ServiceGroup4 = data.ReadString("ServiceGroup4"),
                ServiceLine1 = data.ReadString("ServiceLine1"),
                ServiceLine2 = data.ReadString("ServiceLine2"),
                ServiceLine3 = data.ReadString("ServiceLine3"),
                ServiceLine4 = data.ReadString("ServiceLine4"),
                ServiceNetwork1 = data.ReadString("ServiceNetwork1"),
                ServiceNetwork2 = data.ReadString("ServiceNetwork2"),
                ServiceNetwork3 = data.ReadString("ServiceNetwork3"),
                ServiceNetwork4 = data.ReadString("ServiceNetwork4"),*/
                Duration = data.ReadString("Duration"),
                FocusDomain = data.ReadString("FocusDomain"),
                StatusText = data.ReadString("StatusText")





            };

        }
    }

}






