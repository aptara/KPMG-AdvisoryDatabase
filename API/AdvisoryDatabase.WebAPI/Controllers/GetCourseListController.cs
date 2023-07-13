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
    public class GetCourseListController : ApiController
    {

        [System.Web.Http.HttpGet]
        public HttpResponseMessage CourseList()

        {
            try
            {
                AdvisoryDatabase.Framework.Logger.AdvisoryLogger.WriteInfo("GetCourselist Method Start");
                AdvisoryDatabase.Business.Controllers.CourseListDataController CourseList = new Business.Controllers.CourseListDataController();
                GetCourseList ObjInputParameters = new GetCourseList();
                ObjInputParameters.LastUpdatedBy = 1;
                ObjInputParameters.IsActive = true;


                 CourseList.GetCourseListDetails(ObjInputParameters);

                List<GetCourseList> outputData = CourseList.GetCourseListDetails(ObjInputParameters);

                string jsonData = JsonConvert.SerializeObject(outputData);
                HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
                response.Content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                AdvisoryDatabase.Framework.Logger.AdvisoryLogger.WriteInfo("GetCourselist Method Record count" + outputData.Count);
                return response;

            }
            catch (Exception ex)
            {
                AdvisoryDatabase.Framework.Logger.AdvisoryLogger.WriteError("GetCourselist exception", ex.Message);
                HttpResponseMessage errorResponse = new HttpResponseMessage(HttpStatusCode.InternalServerError);
                errorResponse.Content = new StringContent("An error occurred: " + ex.Message, Encoding.UTF8, "text/plain");
                return errorResponse;

            };
        }
    }
}





