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
    public class DataAccessStatusMasterService : DataAccessRepository<StatusMaster, Int32>
    {
        protected override string GetProcedureName(OperationType operation)
        {
            string spName = string.Empty;
            switch (operation)
            {
                case OperationType.GetAll:
                    spName = "USP_GetStatusMasterData";
                    break;
                
                default:
                    spName = string.Empty;
                    break;
            }
            return spName;
        }

        protected override void FillParameters(OperationType operation, StatusMaster instance, List<System.Data.Common.DbParameter> parameters)
        {
        }

        protected override List<StatusMaster> ParseGetAllData(System.Data.DataSet data)
        {
            var GetAllData = data.Tables[0].AsEnumerable().Select(row =>
                     new StatusMaster
                     {
                         Id = row.Read<Int32>("StatusId"),
                         Status = row.ReadString("Status"),
                     }).ToList();

            return GetAllData;
        }

        protected override StatusMaster Parse(System.Data.DataRow data)
        {
            return new StatusMaster
            {
                Id = data.Read<Int32>("StatusId"),
                Status = data.ReadString("Status"),
            };
        }
    }
}
