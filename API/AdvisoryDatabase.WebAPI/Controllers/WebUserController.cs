using AdvisoryDatabase.Framework.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Mvc;
using AdvisoryDatabase.Business;
using System.Web.Http;
using AdvisoryDatabase.Framework.Logger;

namespace AdvisoryDatabase.WebAPI.Controllers
{
  public class WebUserController : ApiController
  {
    
    [System.Web.Http.HttpGet]
    public HttpResponseMessage GetUserData()

    {
      try
      {
        AdvisoryDatabase.Framework.Logger.AdvisoryLogger.WriteInfo("GetUserData Method Start");
        AdvisoryDatabase.Business.Controllers.WebUserController UserObject = new Business.Controllers.WebUserController();
        UserDetail ObjInputParameters = new UserDetail();
        ObjInputParameters.LastUpdatedBy = 1;
        ObjInputParameters.IsActive = true;

        List<UserDetail> UserData = UserObject.GetUserDetails(ObjInputParameters);
     
        string jsonData = JsonConvert.SerializeObject(UserData);
        HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
        response.Content = new StringContent(jsonData, Encoding.UTF8, "application/json");
        AdvisoryDatabase.Framework.Logger.AdvisoryLogger.WriteInfo("GetUserData Method Record Count :" + UserData.Count);
        return response;

      }
      catch (Exception ex)
      {
        AdvisoryDatabase.Framework.Logger.AdvisoryLogger.WriteError("GetUserData exception", ex.Message);
        HttpResponseMessage errorResponse = new HttpResponseMessage(HttpStatusCode.InternalServerError);
        errorResponse.Content = new StringContent("An error occurred: " + ex.Message, Encoding.UTF8, "text/plain");
        return errorResponse;

      };
    }

    
    //Action method for Add Data
    [System.Web.Mvc.HttpPost]
    public HttpResponseMessage PostUserData(UserDetail user)

    {
      try
      {
        AdvisoryDatabase.Framework.Logger.AdvisoryLogger.WriteInfo("PostData Method start" );
        AdvisoryDatabase.Business.Controllers.WebUserController UserObject = new Business.Controllers.WebUserController();
        UserDetail ObjInputParameters = new UserDetail();
        ObjInputParameters.LastUpdatedBy = 1;
        ObjInputParameters.IsActive = true;
        ObjInputParameters.FirstName = user.FirstName;
        ObjInputParameters.LastName = user.LastName;
        ObjInputParameters.Email = user.Email;
        ObjInputParameters.LocationID = user.LocationID;
        ObjInputParameters.NetworkID = user.NetworkID;
        ObjInputParameters.TaskMasterID = user.TaskMasterID;

        List<UserDetail> UserOutput = UserObject.PostUserDetail(ObjInputParameters);

        string jsonData = JsonConvert.SerializeObject(UserOutput);
        HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
        response.Content = new StringContent(jsonData, Encoding.UTF8, "application/json");
        AdvisoryDatabase.Framework.Logger.AdvisoryLogger.WriteInfo("PostData Method  Record Count :" + UserOutput.Count);
        return response;

      }
      catch (Exception ex)
      {
        AdvisoryDatabase.Framework.Logger.AdvisoryLogger.WriteError("PostData exception", ex.Message);
        HttpResponseMessage errorResponse = new HttpResponseMessage(HttpStatusCode.InternalServerError);
        errorResponse.Content = new StringContent("An error occurred: " + ex.Message, Encoding.UTF8, "text/plain");
        return errorResponse;

      };
    }


    //Get Data by usermasterid to pass data from grid to update form
    [System.Web.Http.HttpGet]
    public HttpResponseMessage GetDataByUserId(int id)
   
    {
      try
      {
        AdvisoryDatabase.Framework.Logger.AdvisoryLogger.WriteInfo("GetDataByUserId Method start");
        AdvisoryDatabase.Business.Controllers.WebUserController ObjBayDetai = new Business.Controllers.WebUserController();
        UserDetail ObjInputParameters = new UserDetail();
        ObjInputParameters.LastUpdatedBy = 1;
        ObjInputParameters.IsActive = true;
        ObjInputParameters.UserMasterID = id;


        List<UserDetail> outputData = ObjBayDetai.GetUserDetails(ObjInputParameters);
        UserDetail UserDataById = new UserDetail();
        UserDataById = outputData.Where(a => a.UserMasterID == id).FirstOrDefault();



        string jsonData = JsonConvert.SerializeObject(UserDataById);
        HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
        response.Content = new StringContent(jsonData, Encoding.UTF8, "application/json");
        AdvisoryDatabase.Framework.Logger.AdvisoryLogger.WriteInfo("GetDataByUserId Method Record Count :" + outputData.Count);
        return response;

      }
      catch (Exception ex)
      {
        AdvisoryDatabase.Framework.Logger.AdvisoryLogger.WriteError("GetDataByUserId exception",ex.Message);
        HttpResponseMessage errorResponse = new HttpResponseMessage(HttpStatusCode.InternalServerError);
        errorResponse.Content = new StringContent("An error occurred: " + ex.Message, Encoding.UTF8, "text/plain");
        return errorResponse;

      };
    }

   
    
  

    //Action method for Update data
    [System.Web.Mvc.HttpPost]
    public HttpResponseMessage UpdateUser(UserDetail user)

    {
      try
      {
        AdvisoryDatabase.Framework.Logger.AdvisoryLogger.WriteInfo("UpdateData Method start");
        AdvisoryDatabase.Business.Controllers.WebUserController UserObject = new Business.Controllers.WebUserController();
        UserDetail ObjInputParameters = new UserDetail();
        ObjInputParameters = user;
        ObjInputParameters.LastUpdatedBy = 1;
        ObjInputParameters.IsActive = true;
        ObjInputParameters.UserMasterID = user.UserMasterID;
        ObjInputParameters.FirstName = user.FirstName;
        ObjInputParameters.LastName = user.LastName;
        ObjInputParameters.Email = user.Email;
        ObjInputParameters.LocationID = user.LocationID;
        ObjInputParameters.TaskMasterID = user.TaskMasterID;
        ObjInputParameters.NetworkID = user.NetworkID;

        UserDetail UserDataByUID = new UserDetail();
        var UserId = user.UserMasterID;
        List<UserDetail> UserOutput = UserObject.updateDetails(ObjInputParameters);



        string jsonData = JsonConvert.SerializeObject(UserOutput);
        HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
        response.Content = new StringContent(jsonData, Encoding.UTF8, "application/json");
        AdvisoryDatabase.Framework.Logger.AdvisoryLogger.WriteInfo("UpdateData Method Record Count :" + UserOutput.Count);
        return response;

      }
      catch (Exception ex)
      {
        AdvisoryDatabase.Framework.Logger.AdvisoryLogger.WriteError("UpdateData exception", ex.Message);
        HttpResponseMessage errorResponse = new HttpResponseMessage(HttpStatusCode.InternalServerError);
        errorResponse.Content = new StringContent("An error occurred: " + ex.Message, Encoding.UTF8, "text/plain");
        return errorResponse;

      };
    }



  

    [System.Web.Mvc.HttpPost]
    public HttpResponseMessage DelData(UserDetail user)

    {
      try
      {
        AdvisoryDatabase.Framework.Logger.AdvisoryLogger.WriteInfo("DelData method start" );
        AdvisoryDatabase.Business.Controllers.WebUserController ObjBayDetai = new Business.Controllers.WebUserController();
        UserDetail ObjInputParameters = new UserDetail();
        ObjInputParameters = user;
      
        ObjInputParameters.UserMasterID = user.UserMasterID;
        ObjInputParameters.FirstName = user.FirstName;
        ObjInputParameters.LastName = user.LastName;
        ObjInputParameters.Email = user.Email;
        ObjInputParameters.LocationID = user.LocationID;
        ObjInputParameters.NetworkID = user.NetworkID;

        if (ObjInputParameters.IsActive)
        {
          ObjInputParameters.IsActive = false;

        }

        
        List<UserDetail> outputData = ObjBayDetai.deleteuser(ObjInputParameters);



        string jsonData = JsonConvert.SerializeObject(outputData);
        HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
        response.Content = new StringContent(jsonData, Encoding.UTF8, "application/json");
        AdvisoryDatabase.Framework.Logger.AdvisoryLogger.WriteInfo("DelData method Record Count :" + outputData.Count);
        return response;

      }
      catch (Exception ex)
      {
        AdvisoryDatabase.Framework.Logger.AdvisoryLogger.WriteError("DelData exception", ex.Message);
        HttpResponseMessage errorResponse = new HttpResponseMessage(HttpStatusCode.InternalServerError);
        errorResponse.Content = new StringContent("An error occurred: " + ex.Message, Encoding.UTF8, "text/plain");
        return errorResponse;

      };
    }

    [System.Web.Http.HttpGet]
    public HttpResponseMessage GetAutherizedUser()
    {
      try
      {
        AdvisoryDatabase.Framework.Logger.AdvisoryLogger.WriteInfo("GetAutherizedUser method start");
        AdvisoryDatabase.Business.Controllers.WebUserController ObjBayDetai = new Business.Controllers.WebUserController();
        UserDetail ObjInputParameters = new UserDetail();
        ObjInputParameters.LastUpdatedBy = 1;
        ObjInputParameters.IsActive = true;
        var headerUserName = HttpContext.Current.Request.ServerVariables["AUTH_USER"];
   /*     headerUserName = "NS3148280\\Trupia.Vincent";*/
        AdvisoryLogger.WriteInfo("Server Variables:" + HttpContext.Current.Request.ServerVariables.ToString());
                AdvisoryLogger.WriteInfo("Header User Name:" + headerUserName);
                AdvisoryLogger.WriteInfo("User Identity Name:" + User.Identity.Name);

                ObjInputParameters.NetworkID = headerUserName;
        

        List<UserDetail> outputData = ObjBayDetai.GetUserDetails(ObjInputParameters);
        UserDetail UserData = new UserDetail();
        UserData = outputData.Where(a => a.NetworkID == headerUserName).FirstOrDefault();
        //UserData = outputData.Where(a => a.UserMasterID == id).FirstOrDefault();
       


        string jsonData = JsonConvert.SerializeObject(UserData);
        HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
        response.Content = new StringContent(jsonData, Encoding.UTF8, "application/json");
        AdvisoryDatabase.Framework.Logger.AdvisoryLogger.WriteInfo("GetAutherizedUser method end"+jsonData);
        return response;

      }
      catch (Exception ex)
      {

         AdvisoryDatabase.Framework.Logger.AdvisoryLogger.WriteError("GetAutherizedUser exception", ex.Message);
        HttpResponseMessage errorResponse = new HttpResponseMessage(HttpStatusCode.InternalServerError);
        errorResponse.Content = new StringContent("An error occurred: " + ex.Message, Encoding.UTF8, "text/plain");
        return errorResponse;

      };
    }
  }
}
