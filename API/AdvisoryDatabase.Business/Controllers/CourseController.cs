using AdvisoryDatabase.Business.Service;
using AdvisoryDatabase.Framework.Entities;
using AdvisoryDatabase.Framework.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvisoryDatabase.Business.Controllers
{
    public class CourseController : BaseController
    {
        public APIResponse<Course> GetCourse(Course course)
        {
            try
            {
                CourseDataService service = new CourseDataService();
                return SuccessReponse(service.Get(course));
            }
            catch (Exception ex)
            {
                var error = LogError(ex);
                return Erroresponse<Course>(error);
            }
            
        }
        public APIResponse<List<Course>> GetAllCourse()
        {
            try
            {
                CourseDataService service = new CourseDataService();
                return SuccessReponse(service.GetAll());
            }
            catch (Exception ex)
            {
                var error = LogError(ex);
                return Erroresponse<List<Course>>(error);
            }
        }
        public APIResponse<Course> InsertCourse(Course course)
        {
            try
            {
                CourseDataService service = new CourseDataService();
                course.CourseMasterID = service.Add(course);
                return SuccessReponse(course);
            }
            catch (Exception ex)
            {
                var error = LogError(ex);
                return Erroresponse<Course>(error);
            }
        }
        public APIResponse<Course> UpdateCourse(Course course)
        {
            try
            {
                CourseDataService service = new CourseDataService();
                service.Update(course);
                return SuccessReponse(course);
            }
            catch (Exception ex)
            {
                var error = LogError(ex);
                return Erroresponse<Course>(error);
            }
        }
        public APIResponse<string> DeleteCourse(int CourseMasterID)
        {
            try
            {
                CourseDataService service = new CourseDataService();
                service.Remove(CourseMasterID);
                return SuccessReponse("Success");
            }
            catch (Exception ex)
            {
                var error = LogError(ex);
                return Erroresponse<string>(error);
            }
        }
    }
}
