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
    public class DataAccessAudienceLevelMappingService : DataAccessRepository<AudienceLevelMapping, Int32>
    {
        protected override string GetProcedureName(OperationType operation)
        {
            string spName = string.Empty;
            switch (operation)
            {
                case OperationType.GetAll:
                    spName = "UserDetail";
                    break;
                default:
                    spName = string.Empty;
                    break;
            }
            return spName;
        }

        protected override void FillParameters(OperationType operation, AudienceLevelMapping instance, List<System.Data.Common.DbParameter> parameters)
        {
           
            
        }

        protected override List<AudienceLevelMapping> ParseGetAllData(System.Data.DataSet data)
        {
            var GetAllData = data.Tables[0].AsEnumerable().Select(row =>
                     new AudienceLevelMapping
                     {

                         CourseMasterID = row.Read<int>("CourseMasterID"),
                         AudienceLevelId = row.Read<int>("AudienceLevelId"),
                     }).ToList();

            return GetAllData;
        }

        protected override AudienceLevelMapping Parse(System.Data.DataRow data)
        {
            return new AudienceLevelMapping();
        }
    }
}
