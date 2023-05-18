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
    public class DataAccessGetExcelForFocusDetails: DataAccessRepository<GetExcelForFocusInfo, Int32>
    {
        protected override string GetProcedureName(OperationType operation)
        {
            string spName = string.Empty;
            switch (operation)
            {
                case OperationType.GetAll:
                    spName = "getexcelforfocus";
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

        }
      
        protected override List<GetExcelForFocusInfo> ParseGetAllData(System.Data.DataSet data)
        {
            var GetAllData = data.Tables[0].AsEnumerable().Select(row =>
                     new GetExcelForFocusInfo
                     {

                    


                         CourseName = row.ReadString("CourseName"),
                         CourseOwner = row.ReadString("CourseOwner"),
                         DeliveryType = row.ReadString("DeliveryType"),
                         TotalCPECredit = row.ReadString("TotalCPECredit"),
                         CourseID = row.ReadString("CourseID"),
                         Overview = row.ReadString("Overview"),
                         Objectives = row.ReadString("Objectives"),
                         MaximumAttendeeCount = row.ReadString("MaximumAttendeeCount"),
                         MaximumAttendeeWaitlist = row.ReadString("MaximumAttendeeWaitlist"),
                         MinimumAttendeeCount = row.ReadString("MinimumAttendeeCount"),
                         PrerequisiteCourseID = row.ReadString("PrerequisiteCourseID"),
                         EquivalentCourseID = row.ReadString("EquivalentCourseID"),
                         FirstDeliveryDate = row.ReadString("FirstDeliveryDate"),
                       
                         Duration = row.ReadString("Duration"),

                     }).ToList();

            return GetAllData;
        }
       
        protected override GetExcelForFocusInfo Parse(System.Data.DataRow data)
        {
            return new GetExcelForFocusInfo
            {



                CourseName = data.ReadString("CourseOwnerID"),
                CourseOwner = data.ReadString("CourseOwner"),
                DeliveryType = data.ReadString("DeliveryType"),
                TotalCPECredit = data.ReadString("TotalCPECredit"),
                CourseID = data.ReadString("CourseID"),
                Overview = data.ReadString("Overview"),
                Objectives = data.ReadString("Objectives"),
                MaximumAttendeeCount = data.ReadString("MaximumAttendeeCount"),
                MaximumAttendeeWaitlist = data.ReadString("MaximumAttendeeWaitlist"),
                MinimumAttendeeCount = data.ReadString("MinimumAttendeeCount"),
                PrerequisiteCourseID = data.ReadString("PrerequisiteCourseID"),
                EquivalentCourseID = data.ReadString("EquivalentCourseID"),
                FirstDeliveryDate = data.ReadString("FirstDeliveryDate"),
             

                Duration = data.ReadString("Duration"),


            };
        }
       

    }
}


