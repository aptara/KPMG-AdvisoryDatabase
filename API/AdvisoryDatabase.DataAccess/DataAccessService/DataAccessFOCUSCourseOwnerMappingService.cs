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
    public class DataAccessFOCUSCourseOwnerMappingService : DataAccessRepository<FOCUSCourseOwnerMapping, Int32>
    {
        protected override string GetProcedureName(OperationType operation)
        {
            string spName = string.Empty;
            switch (operation)
            {
                case OperationType.GetAll:
                    spName = "USP_GetFOCUSCourseOwnerMapping";
                    break;
                case OperationType.Add:
                    spName = "USP_FOCUSCourseOwnerMapping";
                    break;
                case OperationType.Delete:
                    spName = "USP_FOCUSCourseOwnerMapping";
                    break;
                default:
                    spName = string.Empty;
                    break;
            }
            return spName;
        }

        protected override void FillParameters(OperationType operation, FOCUSCourseOwnerMapping instance, List<System.Data.Common.DbParameter> parameters)
        {
            parameters.Add(DbHelper.CreateParameter("CourseMasterID", instance.CourseMasterID));
            parameters.Add(DbHelper.CreateParameter("FOCUSCourseOwnerId", instance.FOCUSCourseOwnerId));
        }

        protected override List<FOCUSCourseOwnerMapping> ParseGetAllData(System.Data.DataSet data)
        {
            var GetAllData = data.Tables[0].AsEnumerable().Select(row =>
                     new FOCUSCourseOwnerMapping
                     {

                         CourseMasterID = row.Read<int>("CourseMasterID"),
                         FOCUSCourseOwnerId = row.Read<int>("FOCUSCourseOwnerId"),
                     }).ToList();

            return GetAllData;
        }

        protected override FOCUSCourseOwnerMapping Parse(System.Data.DataRow data)
        {
            return new FOCUSCourseOwnerMapping();
        }
    }
}
