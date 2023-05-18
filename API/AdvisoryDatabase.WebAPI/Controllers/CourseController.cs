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
    public class CourseController : ApiController
    {
        // GET: webcourse
        [System.Web.Http.HttpGet]
        public HttpResponseMessage ShowData()
       /* public ActionResult Index()*/
        {

            try
            {
                AdvisoryDatabase.Business.Controllers.CourseDetailController ObjBayDetai = new Business.Controllers.CourseDetailController();
                Course ObjInputParameters = new Course();
                ObjInputParameters.LastUpdatedBy = 1;
                ObjInputParameters.IsActive = true;
                ObjBayDetai.GetCourseDetails(ObjInputParameters);


                List<Course> outputData = ObjBayDetai.GetCourseDetails(ObjInputParameters);
            
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

