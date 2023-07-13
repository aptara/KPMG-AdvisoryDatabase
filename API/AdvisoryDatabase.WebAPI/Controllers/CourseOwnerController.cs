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
    public class CourseOwnerController : ApiController
    {
        [System.Web.Http.HttpGet]
        public HttpResponseMessage ShowData()
      
        {
            try
            {
        AdvisoryDatabase.Framework.Logger.AdvisoryLogger.WriteInfo("GetCourseOwner Method Start");
        AdvisoryDatabase.Business.Controllers.CourseOwnerController GetCourseOwner = new Business.Controllers.CourseOwnerController();
                CourseOwnerDetails ObjInputParameters = new CourseOwnerDetails();
                ObjInputParameters.LastUpdatedBy = 1;
                ObjInputParameters.IsActive = true;
        GetCourseOwner.GetCourseOwnerDetails(ObjInputParameters);



                List<CourseOwnerDetails> outputData = GetCourseOwner.GetCourseOwnerDetails(ObjInputParameters);

                string jsonData = JsonConvert.SerializeObject(outputData);
                HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
                response.Content = new StringContent(jsonData, Encoding.UTF8, "application/json");
               AdvisoryDatabase.Framework.Logger.AdvisoryLogger.WriteInfo("GetCourseOwner Method record count :" + outputData.Count);
                return response;


            }
            catch (Exception ex)
            {
        AdvisoryDatabase.Framework.Logger.AdvisoryLogger.WriteError("GetCourseOwner Exception", ex.Message);
    /*    return Erroresponse<Course>(error);*/
        HttpResponseMessage errorResponse = new HttpResponseMessage(HttpStatusCode.InternalServerError);
                errorResponse.Content = new StringContent("An error occurred: " + ex.Message, Encoding.UTF8, "text/plain");
                return errorResponse;

            };
        }

    }
}




