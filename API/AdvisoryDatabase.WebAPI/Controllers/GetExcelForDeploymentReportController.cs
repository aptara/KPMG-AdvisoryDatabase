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
    public class GetExcelForDeploymentReportController : ApiController
    {
        [System.Web.Http.HttpGet]
        public HttpResponseMessage ShowData()
        // GET: GetExcelForDeploymentReport
        /*public ActionResult Index()*/
        {
            try
            {
                AdvisoryDatabase.Business.Controllers.GETExcelForDeploymentReportController ObjBayDetai = new Business.Controllers.GETExcelForDeploymentReportController();
                ExcelforDeployment ObjInputParameters = new ExcelforDeployment();
                ObjInputParameters.LastUpdatedBy = 1;
                ObjInputParameters.IsActive = true;
                ObjBayDetai.GetExcelForDeploymentReportDetails(ObjInputParameters);


                List<ExcelforDeployment> outputData = ObjBayDetai.GetExcelForDeploymentReportDetails(ObjInputParameters);

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




/*namespace AdvisoryDatabase.WebAPI.Controllers
{
    public class CourseOwnerController : ApiController
    {
        [System.Web.Http.HttpGet]
        public HttpResponseMessage ShowData()
        // GET: CourseOwner
        *//* public ActionResult Index()*//*
        {
            try
            {
                AdvisoryDatabase.Business.Controllers.CourseOwnerController ObjBayDetai = new Business.Controllers.CourseOwnerController();
                CourseOwnerDetails ObjInputParameters = new CourseOwnerDetails();
                ObjInputParameters.LastUpdatedBy = 1;
                ObjInputParameters.IsActive = true;
                ObjBayDetai.GetCourseOwnerDetails(ObjInputParameters);


                List<CourseOwnerDetails> outputData = ObjBayDetai.GetCourseOwnerDetails(ObjInputParameters);

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



*/
