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
               /* case OperationType.GetAll:
                    spName = "USP_ManageUser";
                    break;
                case OperationType.Add:
                    spName = "USP_ManageUser";
                    break;
                case OperationType.Update:
                    spName = "USP_ManageUser";
                    break;
                case OperationType.Delete:
                    spName = "USP_ManageUser";
                    break;*/
                default:
                    spName = string.Empty;
                    break;
            }
            return spName;
        }

       /* protected override string GetParameterName(ParameterType parameter)
        {
            return parameter == ParameterType.Id ? "UserId" : base.GetParameterName(parameter);
        }

        protected override void FillParameters(OperationType operation, UserDetail instance, List<System.Data.Common.DbParameter> parameters)
        {
            if (operation == OperationType.Get)
            {
                parameters.Add(DbHelper.CreateParameter("UserId", instance.Id));
                parameters.Add(DbHelper.CreateParameter("Email", instance.EmailID));
            }
            else
            {
                //parameters.Add(DbHelper.CreateParameter("UserId",instance.Id));

                parameters.Add(DbHelper.CreateParameter("FirstName", instance.FirstName));
                parameters.Add(DbHelper.CreateParameter("LastName", instance.LastName));
                parameters.Add(DbHelper.CreateParameter("EmailID", instance.EmailID));
                parameters.Add(DbHelper.CreateParameter("HashPassword", instance.Password == null ? "" : instance.Password));
                //parameters.Add(DbHelper.CreateParameter("IsActive", instance.IsActive));
            }
        }*/

        protected override List<UserDetail> ParseGetAllData(System.Data.DataSet data)
        {
            var GetAllData = data.Tables[0].AsEnumerable().Select(row =>
                     new UserDetail
                     {
                         Id = row.Read<Int32>("Id"),
                         UserId = row.ReadString("Id"),
                         EmailID = row.ReadString("EmailID"),
                         FirstName = row.ReadString("FirstName"),
                         LastName = row.ReadString("LastName"),                        
                         Password = row.ReadString("Password"),



                     }).ToList();

            return GetAllData;
        }

        protected override UserDetail Parse(System.Data.DataRow data)
        {
            return new UserDetail
            {
                Id = data.Read<Int32>("Id"),
                UserId = data.ReadString("Id"),
                EmailID = data.ReadString("EmailID"),
                FirstName = data.ReadString("FirstName"),
                LastName = data.ReadString("LastName"),               
                Password = data.ReadString("Password"),
            };
        }

    protected override void FillParameters(OperationType operation, UserDetail instance, List<DbParameter> parameters)
    {
      throw new NotImplementedException();
    }
  }
}
