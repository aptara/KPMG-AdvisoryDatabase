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
    public class UserService : Repository<UserDetail, Int32>
    {
        protected override DataAccess.Repository.DataAccessRepository<UserDetail, int> CreateDalManager()
        {
            return new DataAccessUserService();
        }

    //method for update data
    public int GetUpdatedUserMasterID(UserDetail userDetail)
    {
      
      int updatedUserMasterID = userDetail.UserMasterID;
      return updatedUserMasterID;
    }
    
    public UserDetail GetUserByUserEmail(string emailID)
    {
      UserDetail ObjUser = new UserDetail();
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
                AdvisoryLogger.WriteError("Failed to Authenticate", sqlEx);
        throw;
      }
      catch (Exception ex)
      {
                AdvisoryLogger.WriteError("Failed to Authenticate", ex);
        throw;
      }
      return ObjUser;
    }
  }
}
