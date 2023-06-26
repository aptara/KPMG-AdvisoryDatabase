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
    public class UnlockCourseController : BaseController
    {
        public List<UnlockCourseMap> UnlockCourseDataService(UnlockCourseMap ObjInputParameters)

        {
            List<UnlockCourseMap> CourseData = new List<UnlockCourseMap>();
            try
            {
                UnlockCourseDataService service = new UnlockCourseDataService();

                service.Update(ObjInputParameters);

                int updatedCourseMasterID = service.GetUpdatedCourseMasterID(ObjInputParameters);

                ObjInputParameters.CourseMasterID = updatedCourseMasterID;

            }
            catch (Exception ex)
            {

                Log4NetLogger.Error(ex.Message);
            }

            return CourseData;
        }

    }
}

