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
    public class CourseDropdownMasterDataController : BaseController
    {

        public DropdownData GetCourseDropdownMasterData()
        {
            DropdownData dropdownData = new DropdownData();
            try
            {
                CourseDropdownMasterDataService service = new CourseDropdownMasterDataService();
                dropdownData = service.GetAll().SingleOrDefault();

            }
            catch (Exception ex)
            {

                Log4NetLogger.Error(ex.Message);
            }

            return dropdownData;
        }
    }
}



