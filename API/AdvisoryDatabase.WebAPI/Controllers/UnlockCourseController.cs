using AdvisoryDatabase.Framework.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Http;

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
    public class UnlockCourseController : ApiController
    {
          [System.Web.Http.HttpGet]
        public HttpResponseMessage UnlockCourse(string courseId)
      
        {
           try
            {
                AdvisoryDatabase.Business.Controllers.UnlockCourseController ObjBayDetai = new Business.Controllers.UnlockCourseController();
                UnlockCourseMap ObjInputParameters = new UnlockCourseMap();
                ObjInputParameters.LastUpdatedBy = 1;
                ObjInputParameters.IsActive = true;
                ObjInputParameters.CourseMasterIDs = courseId;

                ObjBayDetai.UnlockCourseDataService(ObjInputParameters);

                List<UnlockCourseMap> outputData = ObjBayDetai.UnlockCourseDataService(ObjInputParameters);

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
