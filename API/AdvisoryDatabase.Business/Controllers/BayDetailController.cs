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
    public class BayDetailController : BaseController
    {
        public List<BayDetails> GetBayDetails(BayDetails ObjInputParameters)
         {
            List<BayDetails> bayData = new List<BayDetails>();
            try
            {
                BayDataService service = new BayDataService();
                bayData = service.GetAll();

            }
            catch (Exception ex)
            {

                Log4NetLogger.Error(ex.Message);
            }

            return bayData;
        }
    }
}
