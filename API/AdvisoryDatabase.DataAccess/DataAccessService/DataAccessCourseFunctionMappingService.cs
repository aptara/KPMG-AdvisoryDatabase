using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdvisoryDatabase.DataAccess.Common;
using AdvisoryDatabase.DataAccess.Repository;
using AdvisoryDatabase.Framework.Entities;
using System.Data;
using System.Data.Common;

namespace AdvisoryDatabase.DataAccess.DataAccessService
{
    public class DataAccessCourseFunctionMappingService : DataAccessRepository<CourseFunctionMapping, long>
    {
        protected override string GetProcedureName(OperationType operation)
        {
            string spName = string.Empty;
            switch (operation)
            {
                case OperationType.GetAll:
                    spName = "USP_GetCourseFunctionMasterMapping";
                    break;
                case OperationType.Add:
                    spName = "USP_CourseFunctionMasterMapping";
                    break;
                case OperationType.Delete:
                    spName = "USP_CourseFunctionMasterMapping";
                    break;
                default:
                    spName = string.Empty;
                    break;
            }
            return spName;
        }

        protected override void FillParameters(OperationType operation, CourseFunctionMapping instance, List<System.Data.Common.DbParameter> parameters)
        {
            parameters.Add(DbHelper.CreateParameter("CourseMasterID", instance.CourseMasterID));
            parameters.Add(DbHelper.CreateParameter("FunctionMasterID", instance.FunctionMasterID));
        }

        protected override List<CourseFunctionMapping> ParseGetAllData(System.Data.DataSet data)
        {
            var GetAllData = data.Tables[0].AsEnumerable().Select(row =>
                     new CourseFunctionMapping
                     {
                         CourseMasterID = row.Read<int>("CourseMasterID"),
                         FunctionMasterID = row.Read<int>("FunctionMasterID"),
                     }).ToList();

            return GetAllData;
        }

        protected override CourseFunctionMapping Parse(System.Data.DataRow data)
        {
            return new CourseFunctionMapping();
        }
    }
}
