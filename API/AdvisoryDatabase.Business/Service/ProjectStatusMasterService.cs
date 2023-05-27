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
    public class ProjectStatusMasterService : Repository<ProjectStatusMaster, Int32>
    {
        protected override DataAccess.Repository.DataAccessRepository<ProjectStatusMaster, int> CreateDalManager()
        {
            return new DataAccessProjectStatusMasterService();
        }
    }
}
