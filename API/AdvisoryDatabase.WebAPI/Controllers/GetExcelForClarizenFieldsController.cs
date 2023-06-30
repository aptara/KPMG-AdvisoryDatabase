using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
using System.Web.Http;


namespace AdvisoryDatabase.WebAPI.Controllers
{
    public class GetExcelForClarizenFieldsController : ApiController
    {
        [System.Web.Http.HttpGet]
        public HttpResponseMessage ShowDataofclarizen()
        // GET: GETExcelForClarizenFields
       /* public ActionResult Index()*/
        {
            try
            {
        AdvisoryDatabase.Framework.Logger.AdvisoryLogger.WriteInfo("ShowDataofclarizen Method Start");
        AdvisoryDatabase.Business.Controllers.GETExcelForClarizenFieldsController ObjBayDetai = new Business.Controllers.GETExcelForClarizenFieldsController();
                ExcelForClarizen ObjInputParameters = new ExcelForClarizen();
               /* ObjInputParameters.LastUpdatedBy = 1;
                ObjInputParameters.IsActive = true;*/
                ObjBayDetai.ExcelforclarizenfeildsDetails(ObjInputParameters);


                List<ExcelForClarizen> outputData = ObjBayDetai.ExcelforclarizenfeildsDetails(ObjInputParameters);

                string jsonData = JsonConvert.SerializeObject(outputData);
                HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
                response.Content = new StringContent(jsonData, Encoding.UTF8, "application/json");
        AdvisoryDatabase.Framework.Logger.AdvisoryLogger.WriteInfo("ShowDataofclarizen Method End:",jsonData);
        return response;

            }
            catch (Exception ex)
            {
        AdvisoryDatabase.Framework.Logger.AdvisoryLogger.WriteError("ShowDataofclarizen exception:", ex.Message);
        HttpResponseMessage errorResponse = new HttpResponseMessage(HttpStatusCode.InternalServerError);
                errorResponse.Content = new StringContent("An error occurred: " + ex.Message, Encoding.UTF8, "text/plain");
                return errorResponse;

            };


        }

        [System.Web.Http.HttpGet]
        public HttpResponseMessage ShowDataofclarizen2(string courseId)
        /*public ActionResult Index()*/
        {

            try
            {
        AdvisoryDatabase.Framework.Logger.AdvisoryLogger.WriteInfo("ShowDataofclarizen2 start:");
        AdvisoryDatabase.Business.Controllers.GETExcelForClarizenFieldsController ObjBayDetai = new Business.Controllers.GETExcelForClarizenFieldsController();
                ExcelForClarizen ObjInputParameters = new ExcelForClarizen();
                ObjInputParameters.LastUpdatedBy = 1;
                ObjInputParameters.IsActive = true;
                ObjInputParameters.CourseMasterIDs = courseId;


                ObjBayDetai.ExcelforclarizenfeildsDetails(ObjInputParameters);




                List<ExcelForClarizen> outputData = ObjBayDetai.ExcelforclarizenfeildsDetails(ObjInputParameters);

                string jsonData = JsonConvert.SerializeObject(outputData);
                HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
                response.Content = new StringContent(jsonData, Encoding.UTF8, "application/json");
        AdvisoryDatabase.Framework.Logger.AdvisoryLogger.WriteInfo("ShowDataofclarizen2 end:",jsonData);
        return response;

            }
            catch (Exception ex)
            {
        AdvisoryDatabase.Framework.Logger.AdvisoryLogger.WriteError("ShowDataofclarizen2 exception:", ex.Message);
        HttpResponseMessage errorResponse = new HttpResponseMessage(HttpStatusCode.InternalServerError);
                errorResponse.Content = new StringContent("An error occurred: " + ex.Message, Encoding.UTF8, "text/plain");
                return errorResponse;

            };
        }







    }
}



