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
    public class DataAccessDashboardService : DataAccessRepository<DashboardRecords, Int32>
    {
        protected override string GetProcedureName(OperationType operation)
        {
            string spName = string.Empty;
            switch (operation)
            {
                case OperationType.GetAll:
                    spName = "USP_GetDashboardData";
                    break;
                
                default:
                    spName = string.Empty;
                    break;
            }
            return spName;
        }

        protected override void FillParameters(OperationType operation, DashboardRecords instance, List<System.Data.Common.DbParameter> parameters)
        {
            parameters.Add(DbHelper.CreateParameter("FromDate", instance.FromDate));
            parameters.Add(DbHelper.CreateParameter("ToDate", instance.ToDate));
            parameters.Add(DbHelper.CreateParameter("MeterID", instance.MeterID));
            parameters.Add(DbHelper.CreateParameter("BayID", instance.BayID));
        }

        protected override List<DashboardRecords> ParseGetAllData(System.Data.DataSet data)
        {
            var GetAllData = data.Tables[0].AsEnumerable().Select(row =>
                     new DashboardRecords
                     {
                         Id = row.Read<Int32>("Id"),
                         MeterID = row.ReadString("MeterID"),
                         MeterName = row.ReadString("MeterName"),
                         Reading = row.ReadString("Reading"),
                         ReadingDate = row.Read<DateTime>("ReadingDate"),
                          ReadingDatestring = row.ReadString("ReadingDatestring")
                         
                     }).ToList();

            return GetAllData;
        }

        protected override DashboardRecords Parse(System.Data.DataRow data)
        {
            return new DashboardRecords
            {
                Id = data.Read<Int32>("Id"),
                MeterID = data.ReadString("MeterID"),
                MeterName = data.ReadString("MeterName"),
                Reading = data.ReadString("Reading"),
                ReadingDate = data.Read<DateTime>("ReadingDate"),
                ReadingDatestring = data.ReadString("ReadingDatestring")

            };
        }
    }
}
