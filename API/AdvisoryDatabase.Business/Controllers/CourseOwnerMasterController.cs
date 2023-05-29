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
     public class CourseOwnerMasterController : BaseController
    {

        public List<CourseOwnerMaster> GetAllCourseOwner()
        {
            List<CourseOwnerMaster> CourseOwnerData = new List<CourseOwnerMaster>();
            try
            {
                CourseOwnerMasterService service = new CourseOwnerMasterService();
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



