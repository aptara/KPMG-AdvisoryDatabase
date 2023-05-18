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
   public class GETExcelForFocusController : BaseController
    {
        public List<GetExcelForFocusInfo> GetExcelForFocusInfoDetails(GetExcelForFocusInfo ObjInputParameters)
        {
            List<GetExcelForFocusInfo> excelinfoData = new List<GetExcelForFocusInfo>();
            try
            {
                ExcelForFocusDataService service = new ExcelForFocusDataService();
                excelinfoData = service.GetAll();

            }
            catch (Exception ex)
            {

                Log4NetLogger.Error(ex.Message);
            }

            return excelinfoData;
        }
    }
}








