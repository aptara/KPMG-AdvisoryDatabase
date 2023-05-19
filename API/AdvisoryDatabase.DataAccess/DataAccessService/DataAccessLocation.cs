using AdvisoryDatabase.DataAccess.Common;
using AdvisoryDatabase.DataAccess.Repository;
using AdvisoryDatabase.Framework.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvisoryDatabase.DataAccess.DataAccessService
{
  /*class DataAccessLocation
  {
  }*/
  public class DataAccessLocation : DataAccessRepository<Framework.Entities.LocationDetail, Int32>
  {
    protected override void FillParameters(OperationType operation, Framework.Entities.LocationDetail instance, List<DbParameter> parameters)
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


    protected override List<LocationDetail> ParseGetAllData(System.Data.DataSet data)
    {
      var GetAllData = data.Tables[1].AsEnumerable().Select(row =>
               new LocationDetail
               {
                 LocationID = row.ReadString("LocationID"),
                 Location = row.ReadString("Location"),
               }).ToList();

      return GetAllData;
    }


    protected override LocationDetail Parse(DataRow data)
    {
      return new LocationDetail
      {
        LocationID = data.ReadString("LocationID"),
        Location = data.ReadString("Location")

      };
    }
  }


}
