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
                    spName = "Excelfordepolyment";
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

                   

                         CourseName = row.ReadString("CourseName"),
                         LDIntakeOwner = row.ReadString("LDIntakeOwner"),
                         ProjectManagerContact = row.ReadString("ProjectManagerContact"),
                         BusinessSponsor = row.ReadString("BusinessSponsor"),
                         InstructionalDesigner = row.ReadString("InstructionalDesigner"),
                         TotalCPECredit = row.ReadString("TotalCPECredit"),
                       Materials = row.ReadString("Materials"),
                         RoomSetUpComments = row.ReadString("RoomSetUpComments"),
                         CourseID = row.ReadString("CourseID"),
                         Overview = row.ReadString("Overview"),
                         Objectives = row.ReadString("Objectives"),
                         MaximumAttendeeCount = row.ReadString("MaximumAttendeeCount"),
                         MinimumAttendeeCount = row.ReadString("MinimumAttendeeCount"),
                         MaximumAttendeeWaitlist = row.ReadString("MaximumAttendeeWaitlist"),
                         PrerequisiteCourseID = row.ReadString("PrerequisiteCourseID"),
                         EquivalentCourseID = row.ReadString("EquivalentCourseID"),
                         FirstDeliveryDate = row.ReadString("FirstDeliveryDate"),
                         Duration = row.ReadString("Duration"),
                         Collateral = row.ReadString("Collateral")


                     }).ToList();

            return GetAllData;
        }
        protected override ExcelforDeployment Parse(System.Data.DataRow data)
        {
            return new ExcelforDeployment
            {

             
                CourseName = data.ReadString("CourseName"),
                LDIntakeOwner = data.ReadString("LDIntakeOwner"),
                ProjectManagerContact = data.ReadString("ProjectManagerContact"),
                BusinessSponsor = data.ReadString("BusinessSponsor"),
                InstructionalDesigner = data.ReadString("InstructionalDesigner"),
                TotalCPECredit = data.ReadString("TotalCPECredit"),
                Materials = data.ReadString("Materials"),
                RoomSetUpComments = data.ReadString("RoomSetUpComments"),
                CourseID = data.ReadString("CourseID"),
                Overview = data.ReadString("Overview"),
                Objectives = data.ReadString("Objectives"),
                MaximumAttendeeCount = data.ReadString("MaximumAttendeeCount"),
                MinimumAttendeeCount = data.ReadString("MinimumAttendeeCount"),
                MaximumAttendeeWaitlist = data.ReadString("MaximumAttendeeWaitlist"),
                PrerequisiteCourseID = data.ReadString("PrerequisiteCourseID"),
                EquivalentCourseID = data.ReadString("EquivalentCourseID"),
                FirstDeliveryDate = data.ReadString("FirstDeliveryDate"),
                Duration = data.ReadString("Duration"),
                Collateral = data.ReadString("Collateral")


            };
        }
    }
}






