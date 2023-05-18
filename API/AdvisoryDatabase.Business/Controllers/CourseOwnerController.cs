using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AdvisoryDatabase.Framework.Entities;
using AdvisoryDatabase.Framework.Logger;
using AdvisoryDatabase.Business.Service;


namespace AdvisoryDatabase.Business.Controllers
{
     public class CourseOwnerController : BaseController
    {

        public List<CourseOwnerDetails> GetCourseOwnerDetails(CourseOwnerDetails ObjInputParameters)
        {
            List<CourseOwnerDetails> CourseOwnerData = new List<CourseOwnerDetails>();
            try
            {
                CourseOwnerDataService service = new CourseOwnerDataService();
                CourseOwnerData = service.GetAll();

            }
            catch (Exception ex)
            {

                Log4NetLogger.Error(ex.Message);
            }

            return CourseOwnerData;
        }
    }
}



