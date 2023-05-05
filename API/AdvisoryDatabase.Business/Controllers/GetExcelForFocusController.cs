using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdvisoryDatabase.Business.Service;
using AdvisoryDatabase.Framework.Entities;
using AdvisoryDatabase.Framework.Logger;

namespace AdvisoryDatabase.Business.Controllers
{
   public class GetExcelForFocusController : BaseController
    {
        public List<GetExcelForFocusInfo> GetExcelForFocusInfoDetails(GetExcelForFocusInfo ObjInputParameters)
        {
            List<GetExcelForFocusInfo> CourseData = new List<GetExcelForFocusInfo>();
            try
            {
                GetExcelForFocusDataService service = new GetExcelForFocusDataService();
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





