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
    public class DataAccessExcelForClarizenFieldDetailsService : DataAccessRepository<ExcelForClarizen, Int32>
    {
        protected override string GetProcedureName(OperationType operation)
        {
            string spName = string.Empty;
            switch (operation)
            {
                case OperationType.GetAll:

                    spName = "USP_ExcelForClarizen";
                    break;
                default:
                    spName = string.Empty;
                    break;
            }
            return spName;
        }
   /*     protected override void FillParameters(OperationType operation, ExcelForClarizen instance, List<System.Data.Common.DbParameter> parameters)
        {

        }*/
        protected override void FillParameters(OperationType operation, ExcelForClarizen instance, List<System.Data.Common.DbParameter> parameters)
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
        protected override List<ExcelForClarizen> ParseGetAllData(System.Data.DataSet data)
        {
            var GetAllData = data.Tables[0].AsEnumerable().Select(row =>
                     new ExcelForClarizen
                     {
                         CourseMasterID = Int32.Parse(row.ReadString("CourseMasterID")),
                         CourseName = row.ReadString("CourseName"),
                         LDIntakeOwner = row.ReadString("LDIntakeOwner"),
                         ProjectManagerContact = row.ReadString("ProjectManagerContact"),
                         CourseSponsor = row.ReadString("CourseSponsor"),
                         Descriptions = row.ReadString("Descriptions"),

                         InstructionalDesigner = row.ReadString("InstructionalDesigner"),
                         SubjectMatterProfessional = row.ReadString("SubjectMatterProfessional"),
                         ProgramType = row.ReadString("ProgramType"),

                         DeliveryType = row.ReadString("DeliveryType"),
                         EstimatedCPE = row.ReadString("EstimatedCPE"),
                         CourseID = row.ReadString("CourseID"),
                         FirstDeliveryDate = row.ReadString("FirstDeliveryDate"),
                         DeploymentFiscalYear = row.ReadString("DeploymentFiscalYear"),
                         LevelofEffort = row.ReadString("LevelofEffort"),
                         Duration = row.ReadString("Duration"),
                         ClarizenStartDate = row.ReadString("ClarizenStartDate"),
                         ErrorMessage = row.ReadString("ErrorMessage"),
                         Status = row.ReadString("Status"),
                         //ProjectStatusID = row.ReadString("ProjectStatusID"),
                         ServiceNowID = row.ReadString("ServiceNowID"),
                         CourseRecordURL = row.ReadString("CourseRecordURL")
                     }).ToList();

            return GetAllData;
        }
        protected override ExcelForClarizen Parse(System.Data.DataRow data)
        {
            return new ExcelForClarizen
            {


                CourseMasterID = Int32.Parse(data.ReadString("CourseMasterID")),
                CourseName = data.ReadString("CourseName"),
                LDIntakeOwner = data.ReadString("LDIntakeOwner"),

                ProjectManagerContact = data.ReadString("ProjectManagerContact"),
                CourseSponsor = data.ReadString("CourseSponsor"),
                Descriptions = data.ReadString("Descriptions"),
                InstructionalDesigner = data.ReadString("InstructionalDesigner"),

                SubjectMatterProfessional = data.ReadString("SubjectMatterProfessional"),
                ProgramType = data.ReadString("ProgramType"),
                DeliveryType = data.ReadString("DeliveryType"),

                EstimatedCPE = data.ReadString("EstimatedCPE"),
                CourseID = data.ReadString("CourseID"),
                FirstDeliveryDate = data.ReadString("FirstDeliveryDate"),
                DeploymentFiscalYear = data.ReadString("DeploymentFiscalYear"),
                LevelofEffort = data.ReadString("LevelofEffort"),
                Duration = data.ReadString("Duration"),
                ClarizenStartDate = data.ReadString("ClarizenStartDate"),
                ErrorMessage = data.ReadString("ErrorMessage"),
                Status = data.ReadString("Status"),
                //ProjectStatusID = data.ReadString("ProjectStatusID"),
                ServiceNowID = data.ReadString("ServiceNowID"),
                CourseRecordURL = data.ReadString("CourseRecordURL")




            }; 

    }
}
}
