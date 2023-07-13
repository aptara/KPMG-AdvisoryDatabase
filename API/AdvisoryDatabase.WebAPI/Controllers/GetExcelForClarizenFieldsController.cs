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
     
        {
            try
            {
        AdvisoryDatabase.Framework.Logger.AdvisoryLogger.WriteInfo("ShowDataofclarizen Method Start");
        AdvisoryDatabase.Business.Controllers.GETExcelForClarizenFieldsController DataForClarizan = new Business.Controllers.GETExcelForClarizenFieldsController();
                ExcelForClarizen ObjInputParameters = new ExcelForClarizen();
                DataForClarizan.ExcelforclarizenfeildsDetails(ObjInputParameters);
                List<ExcelForClarizen> outputData = DataForClarizan.ExcelforclarizenfeildsDetails(ObjInputParameters);
                string jsonData = JsonConvert.SerializeObject(outputData);
                HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
                response.Content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                AdvisoryDatabase.Framework.Logger.AdvisoryLogger.WriteInfo("ShowDataofclarizen record count :" +outputData.Count);
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
        public HttpResponseMessage GetShowDataForClarizan(string courseId)
        {
            try
            {
                AdvisoryDatabase.Framework.Logger.AdvisoryLogger.WriteInfo("GetShowDataForClarizan start:");
                AdvisoryDatabase.Business.Controllers.GETExcelForClarizenFieldsController DataForClarizan = new Business.Controllers.GETExcelForClarizenFieldsController();
                ExcelForClarizen ObjInputParameters = new ExcelForClarizen();
                ObjInputParameters.LastUpdatedBy = 1;
                ObjInputParameters.IsActive = true;
                ObjInputParameters.CourseMasterIDs = courseId;
                DataForClarizan.ExcelforclarizenfeildsDetails(ObjInputParameters);
                List<ExcelForClarizen> outputData = DataForClarizan.ExcelforclarizenfeildsDetails(ObjInputParameters);
                string jsonData = JsonConvert.SerializeObject(outputData);
                HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
                response.Content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                AdvisoryDatabase.Framework.Logger.AdvisoryLogger.WriteInfo("GetShowDataForClarizan method record count :" + outputData.Count);
                return response;
            }
            catch (Exception ex)
            {
                AdvisoryDatabase.Framework.Logger.AdvisoryLogger.WriteError("GetShowDataForClarizan exception:", ex.Message);
                HttpResponseMessage errorResponse = new HttpResponseMessage(HttpStatusCode.InternalServerError);
                errorResponse.Content = new StringContent("An error occurred: " + ex.Message, Encoding.UTF8, "text/plain");
                return errorResponse;

            };
        }







    }
}



