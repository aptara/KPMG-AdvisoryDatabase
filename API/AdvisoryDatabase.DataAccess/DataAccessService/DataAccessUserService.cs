using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdvisoryDatabase.DataAccess.Common;
using AdvisoryDatabase.DataAccess.Repository;
using AdvisoryDatabase.Framework.Entities;
using System.Data;
using System.Data.Common;

namespace AdvisoryDatabase.DataAccess.DataAccessService
{
  public class DataAccessUserService : DataAccessRepository<UserDetail, Int32>
  {
    protected override string GetProcedureName(OperationType operation)
    {
      string spName = string.Empty;
      switch (operation)
      {
        case OperationType.GetAll:
          spName = "UserDetail";
          break;

        case OperationType.Add:
          spName = "AddUser";
          break;

        case OperationType.Update:

          spName = "UpdateUser";
          break;


        default:
          spName = string.Empty;
          break;
      }
      return spName;
    }


    protected override List<UserDetail> ParseGetAllData(System.Data.DataSet data)
    {
      var GetAllData = data.Tables[0].AsEnumerable().Select(row =>
               new UserDetail
               {
                 UserMasterID = Int32.Parse(row.ReadString("UserMasterID")),

                 Email = row.ReadString("Email"),
                 FirstName = row.ReadString("FirstName"),
                 LastName = row.ReadString("LastName"),
                 LocationID = Int32.Parse(row.ReadString("LocationID")),
                 Location = row.ReadString("Location"),
                 IsActive = Boolean.Parse(row.ReadString("IsActive")),
                 TaskMasterID = row.ReadString("TaskMasterID"),
                 LastUpdatedBy = Int32.Parse(row.ReadString("LastUpdatedBy")),
                 LastUpdatedOn = DateTime.Parse(row.ReadString("LastUpdatedOn")),
                 NetworkID = row.ReadString("NetworkID")


               }).ToList();

      return GetAllData;
    }

    protected override UserDetail Parse(System.Data.DataRow data)
    {
      return new UserDetail
      {

        UserMasterID = Int32.Parse(data.ReadString("UserMasterID")),
        Email = data.ReadString("Email"),
        FirstName = data.ReadString("FirstName"),
        LastName = data.ReadString("LastName"),
        LocationID = Int32.Parse(data.ReadString("LocationID")),
        Location = data.ReadString("Location"),
        TaskMasterID = data.ReadString("TaskMasterID"),
        /* LastUpdatedBy = Int32.Parse(data.ReadString("LastUpdatedBy")),
         LastUpdatedOn = DateTime.Parse(data.ReadString("LastUpdatedOn"))*/


      };
    }





    protected override void FillParameters(OperationType operation, UserDetail instance, List<DbParameter> parameters)
    {


      switch (operation)
      {
        case OperationType.Add:
          parameters.Add(DbHelper.CreateParameter("FirstName", instance.FirstName));
          parameters.Add(DbHelper.CreateParameter("LastName", instance.LastName));
          parameters.Add(DbHelper.CreateParameter("Email", instance.Email));
          parameters.Add(DbHelper.CreateParameter("LocationID", instance.LocationID));
          parameters.Add(DbHelper.CreateParameter("TaskMasterID", instance.TaskMasterID));
          parameters.Add(DbHelper.CreateParameter("NetworkID", instance.NetworkID));

          break;


        case OperationType.Update:
          parameters.Add(DbHelper.CreateParameter("UserMasterID", instance.UserMasterID));
          parameters.Add(DbHelper.CreateParameter("FirstName", instance.FirstName));
          parameters.Add(DbHelper.CreateParameter("LastName", instance.LastName));
          parameters.Add(DbHelper.CreateParameter("Email", instance.Email));
          parameters.Add(DbHelper.CreateParameter("LocationID", instance.LocationID));
          parameters.Add(DbHelper.CreateParameter("TaskMasterID", instance.TaskMasterID));
          parameters.Add(DbHelper.CreateParameter("IsActive", instance.IsActive));
          parameters.Add(DbHelper.CreateParameter("NetworkID", instance.NetworkID));
          break;

        case OperationType.Delete:
          parameters.Add(DbHelper.CreateParameter("UserMasterID", instance.UserMasterID));
          break;

        default:
          break;
      }

    }





  }
}




