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
    public class DataAccessProjectStatusMasterService : DataAccessRepository<ProjectStatusMaster, Int32>
    {
        protected override string GetProcedureName(OperationType operation)
        {
            string spName = string.Empty;
            switch (operation)
            {
                case OperationType.GetAll:
                    spName = "USP_GetProjectStatusMasterData";
                    break;
                
                default:
                    spName = string.Empty;
                    break;
            }
            return spName;
        }

        protected override void FillParameters(OperationType operation, ProjectStatusMaster instance, List<System.Data.Common.DbParameter> parameters)
        {
         
        }

        protected override List<ProjectStatusMaster> ParseGetAllData(System.Data.DataSet data)
        {
            var GetAllData = data.Tables[0].AsEnumerable().Select(row =>
                     new ProjectStatusMaster
                     {
                         Id = row.Read<Int32>("Id"),
                         ProjectStatus = row.ReadString("ProjectStatus"),
                     }).ToList();

            return GetAllData;
        }

        protected override ProjectStatusMaster Parse(System.Data.DataRow data)
        {
            return new ProjectStatusMaster
            {
                Id = data.Read<Int32>("Id"),
                ProjectStatus = data.ReadString("ProjectStatus"),
            };
        }
    }
}
