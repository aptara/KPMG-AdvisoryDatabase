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
    public class GETExcelForDeploymentReportController : BaseController
    {
        public List<ExcelforDeployment> GetExcelForDeploymentReportDetails(ExcelforDeployment ObjInputParameters)
        {
            List<ExcelforDeployment> excelforDeploymentdata = new List<ExcelforDeployment>();
            try
            {
                ExcelForDeploymentReportDataService service = new ExcelForDeploymentReportDataService();
                excelforDeploymentdata = service.GetAll();

            }
            catch (Exception ex)
            {

                Log4NetLogger.Error(ex.Message);
            }

            return excelforDeploymentdata;
        }
    }
}


