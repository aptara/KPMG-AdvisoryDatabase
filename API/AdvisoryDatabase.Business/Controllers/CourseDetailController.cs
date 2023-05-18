using AdvisoryDatabase.Business.Service;
using AdvisoryDatabase.Framework.Entities;
using AdvisoryDatabase.Framework.Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvisoryDatabase.Business.Controllers
{
   public class CourseDetailController: BaseController
    {
        public List<Course> GetCourseDetails(Course ObjInputParameters)
        {
            List<Course> CourseData = new List<Course>();
            try
            {
                CourseDataService service = new CourseDataService();
                CourseData = service.GetAll();

            }
            catch (Exception ex)
            {

                Log4NetLogger.Error(ex.Message);
            }

            return CourseData;
        }

    }
}

