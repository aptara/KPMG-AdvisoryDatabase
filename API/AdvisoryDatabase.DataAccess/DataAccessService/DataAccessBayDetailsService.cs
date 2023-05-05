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
    public class DataAccessBayDetailsService : DataAccessRepository<BayDetails, Int32>
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

        protected override void FillParameters(OperationType operation, BayDetails instance, List<System.Data.Common.DbParameter> parameters)
        {
           
        }

        protected override List<BayDetails> ParseGetAllData(System.Data.DataSet data)
        {
            var GetAllData = data.Tables[0].AsEnumerable().Select(row =>
                     new BayDetails
                     {
                         Id = row.Read<Int32>("UserMasterID"),
                         BayID = row.ReadString("FirstName"),
                         Description = row.ReadString("LastName"),
                         SubStationID = row.Read<Int32>("LocationID"),
                         Name = row.ReadString("Email"),
                     
                     }).ToList();

            return GetAllData;
        }

        protected override BayDetails Parse(System.Data.DataRow data)
        {
            return new BayDetails
            {
                Id = data.Read<Int32>("BayMasterID"),
                BayID = data.ReadString("BayID"),
                SubStationID = data.Read<Int32>("SubStationID"),
                Name = data.ReadString("Name"),
                Description = data.ReadString("Description")

            };
        }
    }
}
