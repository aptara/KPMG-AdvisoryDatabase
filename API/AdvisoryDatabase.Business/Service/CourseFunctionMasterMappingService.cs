using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdvisoryDatabase.Business.Repository;
using AdvisoryDatabase.DataAccess.DataAccessService;
using AdvisoryDatabase.Framework.Entities;
using System.Data.SqlClient;
using AdvisoryDatabase.Framework.Logger;

namespace AdvisoryDatabase.Business.Service
{
    public class CourseFunctionMasterMappingService : Repository<CourseFunctionMapping, long>
    {
        protected override DataAccess.Repository.DataAccessRepository<CourseFunctionMapping, long> CreateDalManager()
        {
            return new DataAccessCourseFunctionMappingService();
        }
    }
}
