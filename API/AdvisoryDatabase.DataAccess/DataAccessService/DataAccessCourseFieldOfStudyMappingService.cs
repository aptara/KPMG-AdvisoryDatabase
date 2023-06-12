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
    public class DataAccessCourseFieldOfStudyMappingService : DataAccessRepository<CourseFieldOfStudyMapping, Int32>
    {
        protected override string GetProcedureName(OperationType operation)
        {
            string spName = string.Empty;
            switch (operation)
            {
                case OperationType.GetAll:
                    spName = "UserDetail";
                    break;
                case OperationType.Add:
                    spName = "USP_CourseFieldOfStudyMapping";
                    break;
                case OperationType.Delete:
                    spName = "USP_CourseFieldOfStudyMapping";
                    break;
                default:
                    spName = string.Empty;
                    break;
            }
            return spName;
        }

        protected override void FillParameters(OperationType operation, CourseFieldOfStudyMapping instance, List<System.Data.Common.DbParameter> parameters)
        {
            parameters.Add(DbHelper.CreateParameter("CourseMasterID", instance.CourseMasterID));
            parameters.Add(DbHelper.CreateParameter("FieldOfStudyMasterID", instance.FieldOfStudyMasterID));
            parameters.Add(DbHelper.CreateParameter("FOSCredit", instance.FOSCredit));
        }

        protected override List<CourseFieldOfStudyMapping> ParseGetAllData(System.Data.DataSet data)
        {
            var GetAllData = data.Tables[0].AsEnumerable().Select(row =>
                     new CourseFieldOfStudyMapping
                     {
                         CourseMasterID = row.Read<int>("CourseMasterID"),
                         FieldOfStudyMasterID = row.Read<int>("FieldOfStudyMasterID"),
                         FOSCredit = row.ReadString("FOSCredit")
                     }).ToList();

            return GetAllData;
        }

        protected override CourseFieldOfStudyMapping Parse(DataRow data)
        {
            return new CourseFieldOfStudyMapping();
        }
    }
}
