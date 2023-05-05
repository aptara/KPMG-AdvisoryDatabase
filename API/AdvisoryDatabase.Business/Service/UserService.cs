using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdvisoryDatabase.Business.Repository;
using AdvisoryDatabase.DataAccess.DataAccessService;
using AdvisoryDatabase.Framework.Entities;
using System.Data.SqlClient;
using AdvisoryDatabase.Framework.Logger;

namespace AdvisoryDatabase.Business.Service
{
    public class UserService : Repository<User, Int32>
    {
        protected override DataAccess.Repository.DataAccessRepository<User, int> CreateDalManager()
        {
            return new DataAccessUserService();
        }

        public User GetUserByUserEmail(string emailID)
        {
            User ObjUser = new User();
            try
            {
                ObjUser.Email = emailID;
                var DBUsers = Get(ObjUser);
                if (DBUsers != null)
                {
                    DBUsers.IsActive = true;
                }
                ObjUser = DBUsers;

            }
            catch (SqlException sqlEx)
            {
                MSBLogger.WriteError("Failed to Authenticate", sqlEx);
                throw;
            }
            catch (Exception ex)
            {
                MSBLogger.WriteError("Failed to Authenticate", ex);
                throw;
            }
            return ObjUser;
        }
    }
}
