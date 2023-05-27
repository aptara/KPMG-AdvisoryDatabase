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
     public class DeliveryTypeMasterController : BaseController
    {

        public List<DeliveryTypeMaster> GetAllDeliveryType()
        {
            List<DeliveryTypeMaster> DeliveryTypeData = new List<DeliveryTypeMaster>();
            try
            {
                DeliveryTypeMasterService service = new DeliveryTypeMasterService();
                DeliveryTypeData = service.GetAll();

            }
            catch (Exception ex)
            {

                Log4NetLogger.Error(ex.Message);
            }

            return DeliveryTypeData;
        }
    }
}



