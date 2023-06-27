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
   public class UnlockCourseDataService : Repository<UnlockCourseMap, Int32>
    {

        protected override DataAccess.Repository.DataAccessRepository<UnlockCourseMap, int> CreateDalManager()
        {
            return new DataAccessUnlockCourseDetailsService();
        }
        public int GetUpdatedCourseMasterID(UnlockCourseMap CourseDetail)
        {


            int updatedUserMasterID = CourseDetail.CourseMasterID;
            return updatedUserMasterID;
        }
    }
}
