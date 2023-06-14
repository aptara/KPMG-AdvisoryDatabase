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
    public class DataAccessCourseSkillMappingService : DataAccessRepository<CourseSkillMapping, Int32>
    {
        protected override string GetProcedureName(OperationType operation)
        {
            string spName = string.Empty;
            switch (operation)
            {
                case OperationType.GetAll:
                    spName = "USP_GetCourseSkillMapping";
                    break;
                case OperationType.Add:
                    spName = "USP_CourseSkillMapping";
                    break;
                case OperationType.Delete:
                    spName = "USP_CourseSkillMapping";
                    break;
                default:
                    spName = string.Empty;
                    break;
            }
            return spName;
        }

        protected override void FillParameters(OperationType operation, CourseSkillMapping instance, List<System.Data.Common.DbParameter> parameters)
        {
            parameters.Add(DbHelper.CreateParameter("CourseMasterID", instance.CourseMasterID));
            parameters.Add(DbHelper.CreateParameter("SkillMasterID", instance.SkillMasterID));
        }

        protected override List<CourseSkillMapping> ParseGetAllData(System.Data.DataSet data)
        {
            var GetAllData = data.Tables[0].AsEnumerable().Select(row =>
                     new CourseSkillMapping
                     {
                         CourseMasterID = row.Read<int>("CourseMasterID"),
                         SkillMasterID = row.Read<int>("SkillMasterID"),
                     }).ToList();

            return GetAllData;
        }

        protected override CourseSkillMapping Parse(System.Data.DataRow data)
        {
            return new CourseSkillMapping();
        }
    }
}
