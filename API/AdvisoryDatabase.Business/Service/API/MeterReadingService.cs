using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdvisoryDatabase.Business.Repository;
using AdvisoryDatabase.DataAccess.DataAccessAPIService;
using AdvisoryDatabase.Framework.API;

namespace AdvisoryDatabase.Business.Service.API
{
    public class MeterReadingService : Repository<GetMeterReadingRecords, Int32>
    {
        protected override DataAccess.Repository.DataAccessRepository<GetMeterReadingRecords, int> CreateDalManager()
        {
            return new DataAccessMeterReadingService();
        }
    }
    
    
}
