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
    public class DataAccessUserService : DataAccessRepository<User, Int32>
    {
        protected override string GetProcedureName(OperationType operation)
        {
            string spName = string.Empty;
            switch (operation)
            {
               /* case OperationType.Get:
                    spName = "USP_GetUser";
                    break;*/
                case OperationType.GetAll:
                    spName = "UserDetail";
                    break;
                /*case OperationType.Add:
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

        protected override string GetParameterName(ParameterType parameter)
        {
            return parameter == ParameterType.Id ? "UserMasterID" : base.GetParameterName(parameter);
        }

        protected override void FillParameters(OperationType operation, User instance, List<System.Data.Common.DbParameter> parameters)
        {
           /* if (operation == OperationType.Get)
            {
                parameters.Add(DbHelper.CreateParameter("UserId", instance.Id));
                parameters.Add(DbHelper.CreateParameter("Email", instance.Email));
            }
            else
            {
                //parameters.Add(DbHelper.CreateParameter("UserId",instance.Id));

                parameters.Add(DbHelper.CreateParameter("FirstName", instance.FirstName));
                parameters.Add(DbHelper.CreateParameter("LastName", instance.LastName));
                parameters.Add(DbHelper.CreateParameter("EmailID", instance.Email));
                parameters.Add(DbHelper.CreateParameter("HashPassword", instance.LocationID == null ? "" : instance.LocationID));
                //parameters.Add(DbHelper.CreateParameter("IsActive", instance.IsActive));
            }*/
        }

        protected override List<User> ParseGetAllData(System.Data.DataSet data)
        {
            var GetAllData = data.Tables[0].AsEnumerable().Select(row =>
                     new User
                     {
                         UserMasterID = row.ReadString("UserMasterID"),
                         Email = row.ReadString("Email"),
                         FirstName = row.ReadString("FirstName"),
                         LastName = row.ReadString("LastName"),                        
                        LocationID = row.ReadString("LocationID")



                     }).ToList();

            return GetAllData;
        }

        protected override User Parse(System.Data.DataRow data)
        {
            return new User
            {
               
                UserMasterID = data.ReadString("UserMasterID"),
                Email = data.ReadString("Email"),
                FirstName = data.ReadString("FirstName"),
                LastName = data.ReadString("LastName"),               
               LocationID = data.ReadString("LocationID")
            };
        }
    }
}
