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
                
                default:
                    spName = string.Empty;
                    break;
            }
            return spName;
        }

        protected override void FillParameters(OperationType operation, CourseOwnerMaster instance, List<System.Data.Common.DbParameter> parameters)
        {
        }

        protected override List<CourseOwnerMaster> ParseGetAllData(System.Data.DataSet data)
        {
            var GetAllData = data.Tables[0].AsEnumerable().Select(row =>
                     new CourseOwnerMaster
                     {
                         Id = row.Read<Int32>("Id"),
                         CourseOwner = row.ReadString("CourseOwner"),
                         
                     }).ToList();

            return GetAllData;
        }

        protected override CourseOwnerMaster Parse(System.Data.DataRow data)
        {
            return new CourseOwnerMaster
            {
                Id = data.Read<Int32>("Id"),
                CourseOwner = data.ReadString("CourseOwner"),
            };
        }
    }
}
