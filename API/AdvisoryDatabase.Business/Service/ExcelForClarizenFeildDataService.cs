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
   public class ExcelForClarizenFeildDataService : Repository<ExcelForClarizen, Int32>
    {
        protected override DataAccess.Repository.DataAccessRepository<ExcelForClarizen, int> CreateDalManager()
        {
            return new DataAccessExcelForClarizenFieldDetailsService();
        }
    }
}

/*using System;
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
    public class CourseOwnerDataService : Repository<CourseOwnerDetails, Int32>
    {
        protected override DataAccess.Repository.DataAccessRepository<CourseOwnerDetails, int> CreateDalManager()
        {
            return new DataCourseOwnerDetails();
        }
    }
}
*/