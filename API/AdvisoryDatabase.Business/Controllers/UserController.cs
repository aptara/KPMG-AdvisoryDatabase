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
    public class UserController : BaseController
    {
        

        public List<User> GetUserDetailsByUserID(User ObjInputParameters)
        {
            List<User> Userdata = new List<User>();
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




