using AdvisoryDatabase.DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdvisoryDatabase.Framework.Entities;
using AdvisoryDatabase.DataAccess.Common;
using System.Data.Common;
using System.Data;
using Task = AdvisoryDatabase.Framework.Entities.Task;

namespace AdvisoryDatabase.DataAccess.DataAccessService
{
   public class DataAccessTaskLocation : DataAccessRepository<Framework.Entities.Task, Int32>
  {
    protected override void FillParameters(OperationType operation, Framework.Entities.Task instance, List<DbParameter> parameters)
    {
      throw new NotImplementedException();
    }

    protected override string GetProcedureName(OperationType operation)
    {
      string spName = string.Empty;
      switch (operation)
      {
        case OperationType.GetAll:
          spName = "USP_TaskMaster";
          break;

        default:
          spName = string.Empty;
          break;
      }
      return spName;
    }


    protected override List<Task> ParseGetAllData(DataSet data)
    {
      var GetAllData = data.Tables[0].AsEnumerable().Select(row =>
               new Task
               {
                 TaskMasterID = row.ReadString("TaskMasterID"),
                 TaskMasterName = row.ReadString("TaskMasterName"),
               }).ToList();

      return GetAllData;
    }


    protected override Task Parse(DataRow data)
    {
      return new Task
      {
        TaskMasterID = data.ReadString("TaskMasterID"),
        TaskMasterName = data.ReadString("TaskMasterName")

      };
    }
  }



}
