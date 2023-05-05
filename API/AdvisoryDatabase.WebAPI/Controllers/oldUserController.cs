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
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.IO;
//using System.Web.Http;
using AdvisoryDatabase.Business;
using AdvisoryDatabase.Framework.Logger;
using System.Web.Http.Results;
using System.Web.Script.Serialization;
using System.Web.Http;





/*
http://localhost:62220//api/User/ShowData*/
namespace AdvisoryDatabase.WebAPI.Controllers
{
    
    public class oldUserController : ApiController
    {
        
        // GET: User
        [System.Web.Http.HttpGet]
        public HttpResponseMessage ShowData()
       /* public ActionResult Index()*/
        {
            try
            {
                AdvisoryDatabase.Business.Controllers.UserController ObjBayDetai = new Business.Controllers.UserController();
                User ObjInputParameters = new User();
                ObjInputParameters.LastUpdatedBy = 1;
                ObjInputParameters.IsActive = true;
                ObjBayDetai.GetUserDetailsByUserID(ObjInputParameters);

               
                List<User> outputData = ObjBayDetai.GetUserDetailsByUserID( ObjInputParameters);
                //*string B= JsonConvert.SerializeObject(outputData);
        



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

