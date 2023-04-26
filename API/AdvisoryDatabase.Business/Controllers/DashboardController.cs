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
    public class DashboardController : BaseController
    {
        public List<DashboardRecords> GetDashboards(DashboardRecords dashboardRecords)
        {
            List<DashboardRecords> dashBoardData = new List<DashboardRecords>();
            try
            {
                DashboardService service = new DashboardService();
                dashBoardData = service.GetAll(dashboardRecords);
                
            }
            catch (Exception ex)
            {

                Log4NetLogger.Error(ex.Message); 
            }

            return dashBoardData;            
        }
    }
}
