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
    public class DataAccessDeliveryTypeMasterService : DataAccessRepository<DeliveryTypeMaster, Int32>
    {
        protected override string GetProcedureName(OperationType operation)
        {
            string spName = string.Empty;
            switch (operation)
            {
                case OperationType.GetAll:
                    spName = "USP_GetDeliveryTypeMasterData";
                    break;
                
                default:
                    spName = string.Empty;
                    break;
            }
            return spName;
        }

        protected override void FillParameters(OperationType operation, DeliveryTypeMaster instance, List<System.Data.Common.DbParameter> parameters)
        {
            
        }

        protected override List<DeliveryTypeMaster> ParseGetAllData(System.Data.DataSet data)
        {
            var GetAllData = data.Tables[0].AsEnumerable().Select(row =>
                     new DeliveryTypeMaster
                     {
                         Id = row.Read<Int32>("Id"),
                         DeliveryType = row.ReadString("DeliveryType")
                         
                     }).ToList();

            return GetAllData;
        }

        protected override DeliveryTypeMaster Parse(System.Data.DataRow data)
        {
            return new DeliveryTypeMaster
            {
                Id = data.Read<Int32>("Id"),
                DeliveryType = data.ReadString("DeliveryType"),
            };
        }
    }
}
