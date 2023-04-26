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
                    spName = "USP_GetBayData";
                    break;
                default:
                    spName = string.Empty;
                    break;
            }
            return spName;
        }

        protected override void FillParameters(OperationType operation, BayDetails instance, List<System.Data.Common.DbParameter> parameters)
        {
           switch(operation)
            {
                case OperationType.Get:
                    parameters.Add(DbHelper.CreateParameter("BayID", instance.BayID));
                    break;
            }
            
        }

        protected override List<BayDetails> ParseGetAllData(System.Data.DataSet data)
        {
            var GetAllData = data.Tables[0].AsEnumerable().Select(row =>
                     new BayDetails
                     {
                         Id = row.Read<Int32>("BayMasterID"),
                         BayID = row.ReadString("BayID"),
                         SubStationID = row.Read<Int32>("SubStationID"),
                         Name = row.ReadString("Name"),
                         Description = row.ReadString("Description")
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
