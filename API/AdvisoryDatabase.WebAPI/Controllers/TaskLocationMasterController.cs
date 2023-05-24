using AdvisoryDatabase.Framework.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using System.Web.Http;
using System.Web.Mvc;
using System.Net.Http;
using System.Net;

namespace AdvisoryDatabase.WebAPI.Controllers
{
  public class TaskLocationMasterController : ApiController
  {

   



    //http://localhost:62220//api/TaskLocationMaster/TaskAction
    [System.Web.Http.HttpGet]
    public HttpResponseMessage TaskAction()
    /* public ActionResult Index()*/
    {
      try
      {
        AdvisoryDatabase.Business.Controllers.TaskLocationMasterController ObjBayDetai = new Business.Controllers.TaskLocationMasterController();
        Task ObjInputParameters = new Task();
        ObjInputParameters.LastUpdatedBy = 1;
        ObjInputParameters.IsActive = true;
        // ObjBayDetai.GetUserDetailsByUserID(ObjInputParameters);


        List<Task> outputData = ObjBayDetai.GetTasks(ObjInputParameters);
        //*string B= JsonConvert.SerializeObject(outputData);




        string jsonData = JsonConvert.SerializeObject(outputData);
        HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
        var jsonResponse = JsonConvert.DeserializeObject<dynamic>(jsonData);
        response.Content = new StringContent(jsonData, System.Text.Encoding.UTF8, "application/json");
        return response;

      }
      catch (Exception ex)
      {
        HttpResponseMessage errorResponse = new HttpResponseMessage(HttpStatusCode.InternalServerError);
        errorResponse.Content = new StringContent("An error occurred: " + ex.Message, System.Text.Encoding.UTF8, "text/plain");
        return errorResponse;

      };
    }


    //http://localhost:62220//api/TaskLocationMaster/LocationAction
    //LocationMaster
    [System.Web.Http.HttpGet]
    public HttpResponseMessage LocationAction()
    /* public ActionResult Index()*/
    {
      try
      {
        AdvisoryDatabase.Business.Controllers.TaskLocationMasterController ObjBayDetai = new Business.Controllers.TaskLocationMasterController();
        LocationDetail ObjInputParameters = new LocationDetail();
        ObjInputParameters.LastUpdatedBy = 1;
        ObjInputParameters.IsActive = true;
        // ObjBayDetai.GetUserDetailsByUserID(ObjInputParameters);


        List<LocationDetail> outputData = ObjBayDetai.GetLocation(ObjInputParameters);
        //*string B= JsonConvert.SerializeObject(outputData);




        string jsonData = JsonConvert.SerializeObject(outputData);
        HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
        response.Content = new StringContent(jsonData, System.Text.Encoding.UTF8, "application/json");
        return response;

      }
      catch (Exception ex)
      {
        HttpResponseMessage errorResponse = new HttpResponseMessage(HttpStatusCode.InternalServerError);
        errorResponse.Content = new StringContent("An error occurred: " + ex.Message, System.Text.Encoding.UTF8, "text/plain");
        return errorResponse;

      };
    }



  }
}
