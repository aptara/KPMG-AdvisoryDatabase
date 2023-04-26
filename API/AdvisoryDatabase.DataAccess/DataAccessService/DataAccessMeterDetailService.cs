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
    public class DataAccessMeterDetailService : DataAccessRepository<MeterDetails, Int32>
    {
        protected override string GetProcedureName(OperationType operation)
        {
            string spName = string.Empty;
            switch (operation)
            {
                case OperationType.GetAll:
                    spName = "USP_GetMeterData";
                    break;
                default:
                    spName = string.Empty;
                    break;
            }
            return spName;
        }

        protected override void FillParameters(OperationType operation, MeterDetails instance, List<System.Data.Common.DbParameter> parameters)
        {
            parameters.Add(DbHelper.CreateParameter("BayID", instance.BayMasterId));           
        }

        protected override List<MeterDetails> ParseGetAllData(System.Data.DataSet data)
        {
            var GetAllData = data.Tables[0].AsEnumerable().Select(row =>
                     new MeterDetails
                     {
                         Id = row.Read<Int32>("MeterMasterID"),
                         MeterID = row.ReadString("MeterID"),
                         BayMasterId = row.Read<Int32>("BayMasterId"),
                         MeterName = row.ReadString("MeterName"),
                         MeterDescription = row.ReadString("MeterDescription")
                     }).ToList();

            return GetAllData;
        }

        protected override MeterDetails Parse(System.Data.DataRow data)
        {
            return new MeterDetails
            {
                Id = data.Read<Int32>("MeterMasterID"),
                MeterID = data.ReadString("MeterID"),
                BayMasterId = data.Read<Int32>("BayMasterId"),
                MeterName = data.ReadString("MeterName"),
                MeterDescription = data.ReadString("MeterDescription")

            };
        }

    }
}
