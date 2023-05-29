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
    public class ProjectStatusMasterController : BaseController
    {
        public List<ProjectStatusMaster> GetProjectStatus()
        {
            List<ProjectStatusMaster> ProjectStatusData = new List<ProjectStatusMaster>();
            try
            {
                ProjectStatusMasterService service = new ProjectStatusMasterService();
                ProjectStatusData = service.GetAll();
                
            }
            catch (Exception ex)
            {

                Log4NetLogger.Error(ex.Message); 
            }

            return ProjectStatusData;            
        }
    }
}
