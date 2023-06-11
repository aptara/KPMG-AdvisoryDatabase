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
    public class DataAccessAudienceTypeMappingService : DataAccessRepository<AudienceTypeMapping, Int32>
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

        protected override void FillParameters(OperationType operation, AudienceTypeMapping instance, List<System.Data.Common.DbParameter> parameters)
        {
           
            
        }

        protected override List<AudienceTypeMapping> ParseGetAllData(System.Data.DataSet data)
        {
            var GetAllData = data.Tables[0].AsEnumerable().Select(row =>
                     new AudienceTypeMapping
                     {

                         CourseMasterID = row.Read<int>("CourseMasterID"),
                         AudienceType = row.ReadString("AudienceType"),
                     }).ToList();

            return GetAllData;
        }

        protected override AudienceTypeMapping Parse(System.Data.DataRow data)
        {
            return new AudienceTypeMapping();
        }
    }
}
