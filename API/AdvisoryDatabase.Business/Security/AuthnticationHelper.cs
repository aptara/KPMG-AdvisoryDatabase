using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdvisoryDatabase.Framework.Entities;
using AdvisoryDatabase.Business.Service;
using AdvisoryDatabase.Business.Security;
using System.Data.SqlClient;
using AdvisoryDatabase.Framework.Logger;

namespace AdvisoryDatabase.Business.Security
{
    public class  AuthnticationHelper
    {
        public LoginResponse AutheticateUser(string ModelEmail, string ModelPassword, string sessionId)
        {
            try
            {
                LoginResponse ObjLoginResponse = new LoginResponse();
                UserService ObjUserService = new UserService();
                var decryptPass =   Utillity.Encrypt(ModelPassword);
                var DBUsers = ObjUserService.GetUserByUserEmail(ModelEmail);


                if (DBUsers == null)
                {
                    ObjLoginResponse.ErrorMessage = "This user is not registered. Please contact to administrator.";
                    return ObjLoginResponse;
                }
                else if (DBUsers.IsActive == false)
                {
                    ObjLoginResponse.ErrorMessage = "This user is In-Active.";
                    return ObjLoginResponse;
                }           
                else if (!DBUsers.LocationID.Equals(decryptPass))
                {
                    ObjLoginResponse.ErrorMessage = "Incorrect email id/password.";
                    return ObjLoginResponse;
                }
                else
                {                    
                    ObjLoginResponse.IsAuthenticated = true;
                    ObjLoginResponse.ErrorMessage = "success";
                    ObjLoginResponse.User = DBUsers;
                    return ObjLoginResponse;
                }
            }
            catch (SqlException ex)
            {
                MSBLogger.WriteError("AutheticateUser", ex);
                return new LoginResponse { ErrorMessage = "DbConnectionError" };//, IsConnectionIssue = true };
            }
            catch (Exception ex)
            {
                MSBLogger.WriteError("AutheticateUser", ex);
                return new LoginResponse { ErrorMessage = "ServerError" };
            }
        }
    }
}
