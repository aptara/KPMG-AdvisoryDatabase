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

    [System.Web.Http.HttpGet]
    public HttpResponseMessage GetTask()
    
    {
      try
      {
        AdvisoryDatabase.Framework.Logger.AdvisoryLogger.WriteInfo("TaskAction Method Start");
        AdvisoryDatabase.Business.Controllers.TaskLocationMasterController TaskObject = new Business.Controllers.TaskLocationMasterController();
        Task ObjInputParameters = new Task();
        ObjInputParameters.LastUpdatedBy = 1;
        ObjInputParameters.IsActive = true;
        
        List<Task> outputData = TaskObject.GetTasks(ObjInputParameters);
      

        string jsonData = JsonConvert.SerializeObject(outputData);
        HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
        var jsonResponse = JsonConvert.DeserializeObject<dynamic>(jsonData);
        response.Content = new StringContent(jsonData, System.Text.Encoding.UTF8, "application/json");
        AdvisoryDatabase.Framework.Logger.AdvisoryLogger.WriteInfo("TaskAction Method count"+ outputData.Count);
        return response;

      }
      catch (Exception ex)
      {
        AdvisoryDatabase.Framework.Logger.AdvisoryLogger.WriteError("TaskAction exception",ex.Message );
        HttpResponseMessage errorResponse = new HttpResponseMessage(HttpStatusCode.InternalServerError);
        errorResponse.Content = new StringContent("An error occurred: " + ex.Message, System.Text.Encoding.UTF8, "text/plain");
        return errorResponse;

      };
    }


   

    [System.Web.Http.HttpGet]
    public HttpResponseMessage LocationAction()
 
    {
      try
      {
        AdvisoryDatabase.Business.Controllers.TaskLocationMasterController ObjBayDetai = new Business.Controllers.TaskLocationMasterController();
        LocationDetail ObjInputParameters = new LocationDetail();
        ObjInputParameters.LastUpdatedBy = 1;
        ObjInputParameters.IsActive = true;
 
        List<LocationDetail> outputData = ObjBayDetai.GetLocation(ObjInputParameters);

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
