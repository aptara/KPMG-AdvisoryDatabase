using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdvisoryDatabase.DataAccess.Common;
using AdvisoryDatabase.DataAccess.Repository;
using AdvisoryDatabase.Framework.API;

namespace AdvisoryDatabase.DataAccess.DataAccessAPIService
{
   public class DataAccessMeterReadingService : DataAccessRepository<GetMeterReadingRecords, Int32>
    {
        private const string spName = "USP_UpdateMeterReading";
        protected override string GetProcedureName(OperationType operation)
        {
            return spName;
        }

        protected override void FillParameters(OperationType operation, GetMeterReadingRecords instance, List<System.Data.Common.DbParameter> parameters)
        {
            if (operation == OperationType.Update)
            {
                parameters.Add(DbHelper.CreateParameter("MeterID", instance.MeterID));
                parameters.Add(DbHelper.CreateParameter("MeterReading", instance.MeterReading));
                parameters.Add(DbHelper.CreateParameter("ReadingOn", instance.ReadingOn));

            }
            
        }

        protected override GetMeterReadingRecords Parse(System.Data.DataRow row)
        {
            return new GetMeterReadingRecords
            {
                MeterID = row.ReadString("MeterID"),
                MeterReading = row.ReadString("MeterReading"),
                ReadingOn = row.ReadString("ReadingOn"),
            };
        }
        protected override void ReadCommonAttributes(System.Data.DataRow row, Framework.Common.BaseEntity<int> instance)
        {



        }
    }
}
