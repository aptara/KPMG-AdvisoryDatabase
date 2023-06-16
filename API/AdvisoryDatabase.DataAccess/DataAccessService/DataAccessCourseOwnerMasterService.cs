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
    public class DataAccessCourseOwnerMasterService : DataAccessRepository<CourseOwnerMaster, Int32>
    {
        protected override string GetProcedureName(OperationType operation)
        {
            string spName = string.Empty;
            switch (operation)
            {
                case OperationType.GetAll:
                    spName = "USP_GetCourseOwnerMasterData";
                    break;
                case OperationType.Add:
                    spName = "USP_GetCourseOwnerMasterData";
                    break;
                case OperationType.Delete:
                    spName = "USP_GetCourseOwnerMasterData";
                    break;
                default:
                    spName = string.Empty;
                    break;
            }
            return spName;
        }

        protected override void FillParameters(OperationType operation, CourseOwnerMaster instance, List<System.Data.Common.DbParameter> parameters)
        {
            parameters.Add(DbHelper.CreateParameter("CourseMasterID", instance.CourseMasterID));
            parameters.Add(DbHelper.CreateParameter("CourseOwnerId", instance.CourseOwnerId));
        }

        protected override List<CourseOwnerMaster> ParseGetAllData(System.Data.DataSet data)
        {
            var GetAllData = data.Tables[0].AsEnumerable().Select(row =>
                     new CourseOwnerMaster
                     {
                         CourseMasterID = row.Read<int>("CourseMasterID"),
                         CourseOwnerId = row.Read<long>("CourseOwnerId"),
                     }).ToList();
            return GetAllData;
        }

        protected override CourseOwnerMaster Parse(System.Data.DataRow data)
        {
            return new CourseOwnerMaster();
        }
    }
}
