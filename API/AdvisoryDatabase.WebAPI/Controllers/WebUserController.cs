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

namespace AdvisoryDatabase.WebAPI.Controllers
{
    public class WebUserController : Controller
    {/*
        // GET: WebUser
        public ActionResult Index()
        {
            return View();
        }*/
    [HttpGet]
    public HttpResponseMessage ShowData()
    /* public ActionResult Index()*/
    {
      try
      {
        AdvisoryDatabase.Business.Controllers.BussUserController ObjBayDetai = new Business.Controllers.BussUserController();
        UserDetail ObjInputParameters = new UserDetail();
        ObjInputParameters.LastUpdatedBy = 1;
        ObjInputParameters.IsActive = true;
        ObjBayDetai.GetUserDetailsByUserID(ObjInputParameters);


        List<UserDetail> outputData = ObjBayDetai.GetUserDetailsByUserID(ObjInputParameters);
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

