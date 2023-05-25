using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
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
using AdvisoryDatabase.Framework.Response;
using AdvisoryDatabase.Business.Controllers;
using HttpGetAttribute = System.Web.Http.HttpGetAttribute;

namespace AdvisoryDatabase.WebAPI.Controllers
{
    public class CourseController : ApiController
    {
        [HttpGet]
        public APIResponse<Course> GetCourse(int Id)
        {
            Course course = new Course();
            course.CourseMasterID = Id;
            AdvisoryDatabase.Business.Controllers.CourseController courseController = new Business.Controllers.CourseController();
            return courseController.GetCourse(course);
        }

        [HttpGet]
        public APIResponse<List<Course>> GetAllCourse()
        {
            AdvisoryDatabase.Business.Controllers.CourseController courseController = new Business.Controllers.CourseController();
            return courseController.GetAllCourse();
        }

        [HttpPost]
        public APIResponse<Course> AddEditCourse(Course course)
        {
            AdvisoryDatabase.Business.Controllers.CourseController courseController = new Business.Controllers.CourseController();
            if (course.CourseMasterID == 0)
            {
                return courseController.InsertCourse(course);
            }
            else
            {
                return courseController.UpdateCourse(course);
            }
        }

        [HttpDelete]
        public APIResponse<string> DeleteCourse(int Id)
        {
            AdvisoryDatabase.Business.Controllers.CourseController courseController = new Business.Controllers.CourseController();
            return courseController.DeleteCourse(Id);
        }
    }
}

