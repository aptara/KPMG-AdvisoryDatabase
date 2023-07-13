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
                         FOSvalues = row.ReadString("FOSvalues"),
                       EstimatedCPE = row.ReadString("EstimatedCPE"),
                         Skilltext = row.ReadString("Skilltext"),
                         ProgramType = row.ReadString("ProgramType"),
                         DeliveryType = row.ReadString("DeliveryType"),
                         LDIIntakeOwner = row.ReadString("LDIIntakeOwner"),
                         ProgramKnowledgeLevel = row.ReadString("ProgramKnowledgeLevel"),
                         InstructionalDesignerMaster = row.ReadString("InstructionalDesignerMaster"),
                         ProjectManagerContactMaster = row.ReadString("ProjectManagerContactMaster"),
                         Competency = row.ReadString("Competency"),
                          IndustryText = row.ReadString("IndustryText"),
                          CourseSponsor = row.ReadString("CourseSponsor"),
                          Vendor = row.ReadString("Vendor"),
                          ServiceNowID = row.ReadString("ServiceNowID"),
                        
                         SGSLSNValues = row.ReadString("SGSLSNValues"),
                         Duration = row.ReadString("Duration"),
                         FocusDomain = row.ReadString("FocusDomain"),
                         Status = row.ReadString("Status")
     

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
                FOSvalues = data.ReadString("FOSvalues"),
               
                EstimatedCPE = data.ReadString("EstimatedCPE"),
                 Skilltext = data.ReadString("Skilltext"),
                ProgramType = data.ReadString("ProgramType"),
                DeliveryType = data.ReadString("DeliveryType"),
                LDIIntakeOwner = data.ReadString("LDIIntakeOwner"),
                ProgramKnowledgeLevel = data.ReadString("ProgramKnowledgeLevel"),
                InstructionalDesignerMaster = data.ReadString("InstructionalDesignerMaster"),
                ProjectManagerContactMaster = data.ReadString("ProjectManagerContactMaster"),
                Competency = data.ReadString("Competency"),
                IndustryText = data.ReadString("IndustryText"),
                CourseSponsor = data.ReadString("CourseSponsor"),
                Vendor = data.ReadString("Vendor"),
                ServiceNowID = data.ReadString("ServiceNowID"),
                SGSLSNValues = data.ReadString("SGSLSNValues"),
                Duration = data.ReadString("Duration"),
                FocusDomain = data.ReadString("FocusDomain"),
                Status = data.ReadString("Status")

            };

        }
    }

}






