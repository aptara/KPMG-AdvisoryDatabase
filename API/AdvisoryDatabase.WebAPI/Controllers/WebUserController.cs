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

namespace AdvisoryDatabase.WebAPI.Controllers
{
  public class WebUserController : ApiController
  {
    //http://localhost:62220//api/WebUser/ShowData

    //Display All Data
    [System.Web.Http.HttpGet]
    public HttpResponseMessage ShowData()

    {
      try
      {
        AdvisoryDatabase.Business.Controllers.WebUserController ObjBayDetai = new Business.Controllers.WebUserController();
        UserDetail ObjInputParameters = new UserDetail();
        ObjInputParameters.LastUpdatedBy = 1;
        ObjInputParameters.IsActive = true;

        List<UserDetail> outputData = ObjBayDetai.GetUserDetails(ObjInputParameters);
     
        string jsonData = JsonConvert.SerializeObject(outputData);
        HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
        response.Content = new StringContent(jsonData, Encoding.UTF8, "application/json");
        return response;

      }
      catch (Exception ex)
      {
        HttpResponseMessage errorResponse = new HttpResponseMessage(HttpStatusCode.InternalServerError);
        errorResponse.Content = new StringContent("An error occurred: " + ex.Message, Encoding.UTF8, "text/plain");
        return errorResponse;

      };
    }



    //Action method for Add Data
    [System.Web.Mvc.HttpPost]
    public HttpResponseMessage PostData(UserDetail user)

    {
      try
      {
        AdvisoryDatabase.Business.Controllers.WebUserController ObjBayDetai = new Business.Controllers.WebUserController();
        UserDetail ObjInputParameters = new UserDetail();
        ObjInputParameters.LastUpdatedBy = 1;
        ObjInputParameters.IsActive = true;
        ObjInputParameters.FirstName = user.FirstName;
        ObjInputParameters.LastName = user.LastName;
        ObjInputParameters.Email = user.Email;
        ObjInputParameters.LocationID = user.LocationID;
        List<UserDetail> outputData = ObjBayDetai.PostUserDetail(ObjInputParameters);

        string jsonData = JsonConvert.SerializeObject(outputData);
        HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
        response.Content = new StringContent(jsonData, Encoding.UTF8, "application/json");
        return response;

      }
      catch (Exception ex)
      {
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
        return response;

      }
      catch (Exception ex)
      {
        HttpResponseMessage errorResponse = new HttpResponseMessage(HttpStatusCode.InternalServerError);
        errorResponse.Content = new StringContent("An error occurred: " + ex.Message, Encoding.UTF8, "text/plain");
        return errorResponse;

      };
    }

    //Action method for Update data
    [System.Web.Mvc.HttpPost]
    public HttpResponseMessage UpdateData(UserDetail user)

    {
      try
      {
        AdvisoryDatabase.Business.Controllers.WebUserController ObjBayDetai = new Business.Controllers.WebUserController();
        UserDetail ObjInputParameters = new UserDetail();
        ObjInputParameters = user;
        ObjInputParameters.LastUpdatedBy = 1;
        ObjInputParameters.IsActive = true;
        ObjInputParameters.UserMasterID = user.UserMasterID;
        ObjInputParameters.FirstName = user.FirstName;
        ObjInputParameters.LastName = user.LastName;
        ObjInputParameters.Email = user.Email;
        ObjInputParameters.LocationID = user.LocationID;

        UserDetail UserDataByUID = new UserDetail();
        var UserId = user.UserMasterID;
        List<UserDetail> outputData = ObjBayDetai.updateDetails(ObjInputParameters);



        string jsonData = JsonConvert.SerializeObject(outputData);
        HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
        response.Content = new StringContent(jsonData, Encoding.UTF8, "application/json");
        return response;

      }
      catch (Exception ex)
      {
        HttpResponseMessage errorResponse = new HttpResponseMessage(HttpStatusCode.InternalServerError);
        errorResponse.Content = new StringContent("An error occurred: " + ex.Message, Encoding.UTF8, "text/plain");
        return errorResponse;

      };
    }



    [System.Web.Mvc.HttpPost]
    public HttpResponseMessage DeleteUser(UserDetail user)

    {
      try
      {
        AdvisoryDatabase.Business.Controllers.WebUserController ObjBayDetai = new Business.Controllers.WebUserController();
        UserDetail ObjInputParameters = new UserDetail();
        ObjInputParameters = user;
        ObjInputParameters.LastUpdatedBy = 1;
        ObjInputParameters.IsActive = true;
        ObjInputParameters.UserMasterID = user.UserMasterID;
        ObjInputParameters.FirstName = user.FirstName;
        ObjInputParameters.LastName = user.LastName;
        ObjInputParameters.Email = user.Email;
        ObjInputParameters.LocationID = user.LocationID;
        // Check if IsActive is false, then update it to true
        if (!ObjInputParameters.IsActive)
        {
          ObjInputParameters.IsActive = true;
          // You can also add code here to update the record in the database using your ORM or data access layer
        }
        UserDetail UserDataByUID = new UserDetail();
        var UserId = user.UserMasterID;
        List<UserDetail> outputData = ObjBayDetai.deleteuser(ObjInputParameters);



        string jsonData = JsonConvert.SerializeObject(outputData);
        HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
        response.Content = new StringContent(jsonData, Encoding.UTF8, "application/json");
        return response;

      }
      catch (Exception ex)
      {
        HttpResponseMessage errorResponse = new HttpResponseMessage(HttpStatusCode.InternalServerError);
        errorResponse.Content = new StringContent("An error occurred: " + ex.Message, Encoding.UTF8, "text/plain");
        return errorResponse;

      };
    }

  }
}
