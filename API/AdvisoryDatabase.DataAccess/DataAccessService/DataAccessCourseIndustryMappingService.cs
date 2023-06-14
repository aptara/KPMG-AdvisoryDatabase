using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdvisoryDatabase.DataAccess.Common;
using AdvisoryDatabase.DataAccess.Repository;
using AdvisoryDatabase.Framework.Entities;
using System.Data;

namespace AdvisoryDatabase.DataAccess.DataAccessService
{
    public class DataAccessCourseIndustryMappingService : DataAccessRepository<CourseIndustryMapping, Int32>
    {
        protected override string GetProcedureName(OperationType operation)
        {
            string spName = string.Empty;
            switch (operation)
            {
                case OperationType.GetAll:
                    spName = "USP_GetCourseIndustryMapping";
                    break;
                case OperationType.Add:
                    spName = "USP_CourseIndustryMapping";
                    break;
                case OperationType.Delete:
                    spName = "USP_CourseIndustryMapping";
                    break;
                default:
                    spName = string.Empty;
                    break;
            }
            return spName;
        }

        protected override void FillParameters(OperationType operation, CourseIndustryMapping instance, List<System.Data.Common.DbParameter> parameters)
        {
            parameters.Add(DbHelper.CreateParameter("CourseMasterID", instance.CourseMasterID));
            parameters.Add(DbHelper.CreateParameter("IndustryID", instance.IndustryID));
        }

        protected override List<CourseIndustryMapping> ParseGetAllData(System.Data.DataSet data)
        {
            var GetAllData = data.Tables[0].AsEnumerable().Select(row =>
                     new CourseIndustryMapping
                     {

                         CourseMasterID = row.Read<int>("CourseMasterID"),
                         IndustryID = row.Read<int>("IndustryID"),
                     }).ToList();

            return GetAllData;
        }

        protected override CourseIndustryMapping Parse(System.Data.DataRow data)
        {
            return new CourseIndustryMapping();
        }
    }
}
