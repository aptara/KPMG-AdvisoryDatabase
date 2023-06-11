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
    public class DataAccessCourseSGSLSNMappingService : DataAccessRepository<CourseSGSLSNMapping, Int32>
    {
        protected override string GetProcedureName(OperationType operation)
        {
            string spName = string.Empty;
            switch (operation)
            {
                case OperationType.GetAll:
                    spName = "USP_GetCourseSGSLSNMapping";
                    break;
                default:
                    spName = string.Empty;
                    break;
            }
            return spName;
        }

        protected override void FillParameters(OperationType operation, CourseSGSLSNMapping instance, List<System.Data.Common.DbParameter> parameters)
        {
           
            
        }

        protected override List<CourseSGSLSNMapping> ParseGetAllData(System.Data.DataSet data)
        {
            var GetAllData = data.Tables[0].AsEnumerable().Select(row =>
                     new CourseSGSLSNMapping
                     {
                         CourseMasterID = row.Read<int>("CourseMasterID"),
                         ServiceGroupID = row.Read<int>("ServiceGroupID"),
                         ServiceLineID = row.Read<int>("ServiceLineID"),
                         ServiceNetworkID = row.Read<int>("ServiceNetworkID")
                     }).ToList();

            return GetAllData;
        }

        protected override CourseSGSLSNMapping Parse(System.Data.DataRow data)
        {
            return new CourseSGSLSNMapping();
        }
    }
}
