using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdvisoryDatabase.Business.Service;
using AdvisoryDatabase.Framework.Entities;
using AdvisoryDatabase.Framework.Logger;


namespace AdvisoryDatabase.Business.Controllers
{
    public class BussUserController : BaseController
    {


    public List<UserDetail> GetUserDetailsByUserID(UserDetail ObjInputParameters)
    /* public void GetUserDetailsByUserID(string emailID, string password)*/
    {
      List<UserDetail> Userdata = new List<UserDetail>();
      try
      {
        UserService service = new UserService();
        Userdata = service.GetAll();

      }
      catch (Exception ex)
      {

        Log4NetLogger.Error(ex.Message);
      }

      return Userdata;
    }
  }


}

