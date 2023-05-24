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
                   
                    spName = "ExcelForClarizen";
                    break;
                default:
                    spName = string.Empty;
                    break;
            }
            return spName;
        }
        protected override void FillParameters(OperationType operation, ExcelForClarizen instance, List<System.Data.Common.DbParameter> parameters)
        {

        }
        protected override List<ExcelForClarizen> ParseGetAllData(System.Data.DataSet data)
        {
            var GetAllData = data.Tables[0].AsEnumerable().Select(row =>
                     new ExcelForClarizen
                     {

                         CourseName = row.ReadString("CourseName"),
                         LDIntakeOwner = row.ReadString("LDIntakeOwner"),
                         ProjectManagerContact = row.ReadString("ProjectManagerContact"),

                         BusinessSponsor = row.ReadString("BusinessSponsor"),

                         InstructionalDesigner = row.ReadString("InstructionalDesigner"),



                       ProgramType = row.ReadString("ProgramType"),

                         DeliveryType = row.ReadString("DeliveryType"),
                         TotalCPECredit = row.ReadString("TotalCPECredit"),
                         CourseID = row.ReadString("CourseID"),
                         FirstDeliveryDate = row.ReadString("FirstDeliveryDate"),
                         LevelofEffort = row.ReadString("LevelofEffort"),
                         Duration = row.ReadString("Duration")


                        
                     }).ToList();

            return GetAllData;
        }
        protected override ExcelForClarizen Parse(System.Data.DataRow data)
        {
            return new ExcelForClarizen
            {



                CourseName = data.ReadString("CourseName"),
                LDIntakeOwner = data.ReadString("LDIntakeOwner"),

                ProjectManagerContact = data.ReadString("ProjectManagerContact"),
                BusinessSponsor = data.ReadString("BusinessSponsor"),
                InstructionalDesigner = data.ReadString("InstructionalDesigner"),

                ProgramType = data.ReadString("ProgramType"),
                DeliveryType = data.ReadString("DeliveryType"),

                TotalCPECredit = data.ReadString("TotalCPECredit"),
                CourseID = data.ReadString("CourseID"),
                FirstDeliveryDate = data.ReadString("FirstDeliveryDate"),
                LevelofEffort = data.ReadString("LevelofEffort"),
                Duration = data.ReadString("Duration")

              

            };
        }
    }
}

