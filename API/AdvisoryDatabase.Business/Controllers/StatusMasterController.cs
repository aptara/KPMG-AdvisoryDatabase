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
    public class StatusMasterController : BaseController
    {
        public List<StatusMaster> GetStatusData()
        {
            List<StatusMaster> StatusData = new List<StatusMaster>();
            try
            {
                StatusMasterService service = new StatusMasterService();
                StatusData = service.GetAll();
                
            }
            catch (Exception ex)
            {

                Log4NetLogger.Error(ex.Message); 
            }

            return StatusData;            
        }
    }
}
