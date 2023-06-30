﻿using System;
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
                         LDIIntakeOwner = row.ReadString("LDIIntakeOwner"),
                         ProjectManagerContactMaster = row.ReadString("ProjectManagerContactMaster"),
                         CourseSponsor = row.ReadString("CourseSponsor"),
                         InstructionalDesignerMaster = row.ReadString("InstructionalDesignerMaster"),
                         EstimatedCPE = row.ReadString("EstimatedCPE"),
                         Material = row.ReadString("Material"),
                         RoomSetUpComments = row.ReadString("RoomSetUpComments"),
                         CourseID = row.ReadString("CourseID"),
                         CourseOverviewObjective = row.ReadString("CourseOverviewObjective"),
                         // Objectives = row.ReadString("Objectives"),
                         MaximumAttendeeCount = row.ReadString("MaximumAttendeeCount"),
                         MinimumAttendeeCount = row.ReadString("MinimumAttendeeCount"),
                         MaximumAttendeeWaitlist = row.ReadString("MaximumAttendeeWaitlist"),
                         PrerequisiteCourseID1 = row.ReadString("PrerequisiteCourseID1"),
                         PrerequisiteCourseID2 = row.ReadString("PrerequisiteCourseID2"),
                         EquivalentCourseID1 = row.ReadString("EquivalentCourseID1"),
                         EquivalentCourseID2 = row.ReadString("EquivalentCourseID2"),
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
                LDIIntakeOwner = data.ReadString("LDIIntakeOwner"),
                ProjectManagerContactMaster = data.ReadString("ProjectManagerContactMaster"),
                CourseSponsor = data.ReadString("CourseSponsor"),
                InstructionalDesignerMaster = data.ReadString("InstructionalDesignerMaster"),
                EstimatedCPE = data.ReadString("EstimatedCPE"),
                Material = data.ReadString("Material"),
                RoomSetUpComments = data.ReadString("RoomSetUpComments"),
                CourseID = data.ReadString("CourseID"),
                CourseOverviewObjective = data.ReadString("CourseOverviewObjective"),
                // Objectives = data.ReadString("Objectives"),
                MaximumAttendeeCount = data.ReadString("MaximumAttendeeCount"),
                MinimumAttendeeCount = data.ReadString("MinimumAttendeeCount"),
                MaximumAttendeeWaitlist = data.ReadString("MaximumAttendeeWaitlist"),
                PrerequisiteCourseID1 = data.ReadString("PrerequisiteCourseID1"),
                PrerequisiteCourseID2 = data.ReadString("PrerequisiteCourseID2"),
                EquivalentCourseID1 = data.ReadString("EquivalentCourseID1"),
                EquivalentCourseID2 = data.ReadString("EquivalentCourseID2"),
                FirstDeliveryDate = data.ReadString("FirstDeliveryDate"),
                Duration = data.ReadString("Duration"),
                Collateral = data.ReadString("Collateral"),
                Status = data.ReadString("Status")


            };
        }
    }
}






