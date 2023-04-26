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
    public class MeterDetailController : BaseController
    {
        public List<MeterDetails> GetMeterDetails(int bayID)
        {
            List<MeterDetails> meterDetails = new List<MeterDetails>();          
            try
            {
                MeterDetails objmeterDetails = new MeterDetails();
                objmeterDetails.BayMasterId = bayID;
                MeterDataService service = new MeterDataService();
                meterDetails = service.GetAll(objmeterDetails);

            }
            catch (Exception ex)
            {

                Log4NetLogger.Error(ex.Message);
            }

            return meterDetails;
        }
    }
}
