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
                         LDIntakeOwner = row.ReadString("LDIntakeOwner"),
                         ProjectManagerContact = row.ReadString("ProjectManagerContact"),
                         CourseSponsor = row.ReadString("CourseSponsor"),
                         InstructionalDesigner = row.ReadString("InstructionalDesigner"),
                         EstimatedCPE = row.ReadString("EstimatedCPE"),
                         Material = row.ReadString("Material"),
                         RoomSetUpComments = row.ReadString("RoomSetUpComments"),
                         CourseID = row.ReadString("CourseID"),
                         CourseOverviewObjective = row.ReadString("CourseOverviewObjective"),
                         // Objectives = row.ReadString("Objectives"),
                         MaximumAttendeeCount = row.ReadString("MaximumAttendeeCount"),
                         MinimumAttendeeCount = row.ReadString("MinimumAttendeeCount"),
                         MaximumAttendeeWaitlist = row.ReadString("MaximumAttendeeWaitlist"),
                         PrerequisiteCourseID = row.ReadString("PrerequisiteCourseID"),
                         EquivalentCourseID = row.ReadString("EquivalentCourseID"),
                         FirstDeliveryDate = row.ReadString("FirstDeliveryDate"),
                         Duration = row.ReadString("Duration"),
                         Collateral = row.ReadString("Collateral"),
                         Status = row.ReadString("Status")


                     }).ToList();

            return GetAllData;
        }
        protected override ExcelforDeployment Parse(System.Data.DataRow data)
        {
            return new ExcelforDeployment
            {


                CourseMasterID = data.ReadString("CourseMasterID"),
                CourseName = data.ReadString("CourseName"),
                LDIntakeOwner = data.ReadString("LDIntakeOwner"),
                ProjectManagerContact = data.ReadString("ProjectManagerContact"),
                CourseSponsor = data.ReadString("CourseSponsor"),
                InstructionalDesigner = data.ReadString("InstructionalDesigner"),
                EstimatedCPE = data.ReadString("EstimatedCPE"),
                Material = data.ReadString("Material"),
                RoomSetUpComments = data.ReadString("RoomSetUpComments"),
                CourseID = data.ReadString("CourseID"),
                CourseOverviewObjective = data.ReadString("CourseOverviewObjective"),
                // Objectives = data.ReadString("Objectives"),
                MaximumAttendeeCount = data.ReadString("MaximumAttendeeCount"),
                MinimumAttendeeCount = data.ReadString("MinimumAttendeeCount"),
                MaximumAttendeeWaitlist = data.ReadString("MaximumAttendeeWaitlist"),
                PrerequisiteCourseID = data.ReadString("PrerequisiteCourseID"),
                EquivalentCourseID = data.ReadString("EquivalentCourseID"),
                FirstDeliveryDate = data.ReadString("FirstDeliveryDate"),
                Duration = data.ReadString("Duration"),
                Collateral = data.ReadString("Collateral"),
                Status = data.ReadString("Status")


            };
        }
    }
}






