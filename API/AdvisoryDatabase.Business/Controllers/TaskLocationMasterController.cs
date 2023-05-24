using AdvisoryDatabase.Business.Service.API;
using AdvisoryDatabase.Framework.Entities;
using AdvisoryDatabase.Framework.Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace AdvisoryDatabase.Business.Controllers
{
   public class TaskLocationMasterController: BaseController { 
    //TaskMaster
    public List<Task> GetTasks(Task ObjInputParameters)
 
  {
    List<Task> Userdata = new List<Task>();
    try
    {
      TaskService service = new TaskService();
      Userdata = service.GetAll();

    }
    catch (Exception ex)
    {

      Log4NetLogger.Error(ex.Message);
    }

    return Userdata;
  }


    //LocationMaster
    public List<LocationDetail> GetLocation(LocationDetail ObjInputParameters)
    
    {
      List<LocationDetail> Userdata = new List<LocationDetail>();
      try
      {
        LocationService service = new LocationService();
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
