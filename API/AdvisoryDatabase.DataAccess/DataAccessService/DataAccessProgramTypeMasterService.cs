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
    public class DataAccessProgramTypeMasterService : DataAccessRepository<ProgramTypeMaster, Int32>
    {
        protected override string GetProcedureName(OperationType operation)
        {
            string spName = string.Empty;
            switch (operation)
            {
                case OperationType.GetAll:
                    spName = "USP_GetProgramTypeMasterData";
                    break;
                
                default:
                    spName = string.Empty;
                    break;
            }
            return spName;
        }

        protected override void FillParameters(OperationType operation, ProgramTypeMaster instance, List<System.Data.Common.DbParameter> parameters)
        {
        }

        protected override List<ProgramTypeMaster> ParseGetAllData(System.Data.DataSet data)
        {
            var GetAllData = data.Tables[0].AsEnumerable().Select(row =>
                     new ProgramTypeMaster
                     {
                         Id = row.Read<Int32>("ProgramTypeId"),
                          ProgramType = row.ReadString("ProgramType"),
                         
                     }).ToList();

            return GetAllData;
        }

        protected override ProgramTypeMaster Parse(System.Data.DataRow data)
        {
            return new ProgramTypeMaster
            {
                Id = data.Read<Int32>("ProgramTypeId"),
                ProgramType = data.ReadString("ProgramType"),
            };
        }
    }
}
