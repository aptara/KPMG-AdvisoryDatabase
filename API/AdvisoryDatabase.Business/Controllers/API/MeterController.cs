using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdvisoryDatabase.Framework.API;
using AdvisoryDatabase.Business.Service;

namespace AdvisoryDatabase.Business.Controllers.API
{
    public class MeterController : BaseController
    {
        public string UpdateMeterReading(GetMeterReadingRecords getMeterReadingRecords)
        {
           Business.Service.API. MeterReadingService meterReadingService = new Service.API.MeterReadingService();
            meterReadingService.Update(getMeterReadingRecords);
            return "";
        }
    }
}
