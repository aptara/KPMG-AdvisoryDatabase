using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using AdvisoryDatabase.Framework.Entities;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.IO;
//using System.Web.Http;
using AdvisoryDatabase.Business;
using AdvisoryDatabase.Framework.Logger;
using System.Web.Http.Results;
using System.Web.Script.Serialization;




namespace AdvisoryDatabase.WebAPI.Controllers
{
    public class GetExcelForFocusController : ApiController
    {
        // GET: GetExcelForFocus
        [System.Web.Http.HttpGet]
        public HttpResponseMessage ShowDataoffocus(string courseId)
        /*public ActionResult Index()*/
        {

            try
            {
                AdvisoryDatabase.Business.Controllers.GETExcelForFocusController ObjBayDetai = new Business.Controllers.GETExcelForFocusController();
                GetExcelForFocusInfo ObjInputParameters = new GetExcelForFocusInfo();
                ObjInputParameters.LastUpdatedBy = 1;
                ObjInputParameters.IsActive = true;
                ObjInputParameters.CourseID = courseId;


                ObjBayDetai.GetExcelForFocusInfoDetails(ObjInputParameters);
               



                List<GetExcelForFocusInfo> outputData = ObjBayDetai.GetExcelForFocusInfoDetails(ObjInputParameters);

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

    [System.Web.Http.HttpGet]
    public HttpResponseMessage ShowDataoffocus2(string courseId)
    /*public ActionResult Index()*/
    {

      try
      {
        AdvisoryDatabase.Framework.Logger.AdvisoryLogger.WriteInfo("ShowDataoffocus2 Method Start");
        AdvisoryDatabase.Business.Controllers.GETExcelForFocusController ObjBayDetai = new Business.Controllers.GETExcelForFocusController();
        GetExcelForFocusInfo ObjInputParameters = new GetExcelForFocusInfo();
        ObjInputParameters.LastUpdatedBy = 1;
        ObjInputParameters.IsActive = true;
        ObjInputParameters.CourseMasterIDs = courseId;


        ObjBayDetai.GetExcelForFocusInfoDetails(ObjInputParameters);




        List<GetExcelForFocusInfo> outputData = ObjBayDetai.GetExcelForFocusInfoDetails(ObjInputParameters);

        string jsonData = JsonConvert.SerializeObject(outputData);
        HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
        response.Content = new StringContent(jsonData, Encoding.UTF8, "application/json");
        AdvisoryDatabase.Framework.Logger.AdvisoryLogger.WriteInfo("ShowDataoffocus2 Method end", jsonData);
        return response;

      }
      catch (Exception ex)
      {
        AdvisoryDatabase.Framework.Logger.AdvisoryLogger.WriteError("ShowDataoffocus2 exception",ex.Message);
        HttpResponseMessage errorResponse = new HttpResponseMessage(HttpStatusCode.InternalServerError);
        errorResponse.Content = new StringContent("An error occurred: " + ex.Message, Encoding.UTF8, "text/plain");
        return errorResponse;

      };
    }



  }
}
























