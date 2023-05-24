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
    public class WebUserController : BaseController
    {
    
    //Display Data
    public List<UserDetail> GetUserDetails(UserDetail ObjInputParameters)
 
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

  
 
    //Add Data
      public List<UserDetail> PostUserDetail(UserDetail ObjInputParameters)

      {
        List<UserDetail> Userdata = new List<UserDetail>();
        try
        {
           UserService service = new UserService();

        ObjInputParameters.UserMasterID = service.Add(ObjInputParameters);

        Userdata = service.GetAll();

        }
        catch (Exception ex)
        {

          Log4NetLogger.Error(ex.Message);
        }

        return Userdata;
      }



    //Update Data
    public List<UserDetail> updateDetails(UserDetail ObjInputParameters)

    {
      List<UserDetail> Userdata = new List<UserDetail>();
      try
      {
        UserService service = new UserService();
        
        service.Update(ObjInputParameters);
     
        int updatedUserMasterID = service.GetUpdatedUserMasterID(ObjInputParameters);

        ObjInputParameters.UserMasterID = updatedUserMasterID;
     
      }
      catch (Exception ex)
      {

        Log4NetLogger.Error(ex.Message);
      }

      return Userdata;
    }

    public List<UserDetail> deleteuser(UserDetail ObjInputParameters)

    {
      List<UserDetail> Userdata = new List<UserDetail>();
      try
      {
        UserService service = new UserService();
    

        service.Update(ObjInputParameters);
        int updatedUserMasterID = service.GetUpdatedUserMasterID(ObjInputParameters);

        ObjInputParameters.UserMasterID = updatedUserMasterID;





      }
      catch (Exception ex)
      {

        Log4NetLogger.Error(ex.Message);
      }

      return Userdata;
    }








  }

}
  

