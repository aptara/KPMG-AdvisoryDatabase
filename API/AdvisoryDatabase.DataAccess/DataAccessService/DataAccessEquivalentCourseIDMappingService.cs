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
    public class DataAccessEquivalentCourseIDMappingService : DataAccessRepository<EquivalentCourseIDMapping, Int32>
    {
        protected override string GetProcedureName(OperationType operation)
        {
            string spName = string.Empty;
            switch (operation)
            {
                case OperationType.GetAll:
                    spName = "USP_GetEquivalentCourseIDMapping";
                    break;
                case OperationType.Add:
                    spName = "USP_EquivalentCourseIDMapping";
                    break;
                case OperationType.Delete:
                    spName = "USP_EquivalentCourseIDMapping";
                    break;
                default:
                    spName = string.Empty;
                    break;
            }
            return spName;
        }

        protected override void FillParameters(OperationType operation, EquivalentCourseIDMapping instance, List<System.Data.Common.DbParameter> parameters)
        {
            parameters.Add(DbHelper.CreateParameter("CourseMasterID", instance.CourseMasterID));
            parameters.Add(DbHelper.CreateParameter("EquivalentCourseID", instance.EquivalentCourseID));
        }

        protected override List<EquivalentCourseIDMapping> ParseGetAllData(System.Data.DataSet data)
        {
            var GetAllData = data.Tables[0].AsEnumerable().Select(row =>
                     new EquivalentCourseIDMapping
                     {
                         CourseMasterID = row.Read<int>("CourseMasterID"),
                         EquivalentCourseID = row.ReadString("EquivalentCourseID"),
                     }).ToList();

            return GetAllData;
        }

        protected override EquivalentCourseIDMapping Parse(System.Data.DataRow data)
        {
            return new EquivalentCourseIDMapping();
        }
    }
}
