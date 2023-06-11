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
    public class DataAccessPrerequisiteCourseIDMappingService : DataAccessRepository<PrerequisiteCourseIDMapping, Int32>
    {
        protected override string GetProcedureName(OperationType operation)
        {
            string spName = string.Empty;
            switch (operation)
            {
                case OperationType.GetAll:
                    spName = "UserDetail";
                    break;
                default:
                    spName = string.Empty;
                    break;
            }
            return spName;
        }

        protected override void FillParameters(OperationType operation, PrerequisiteCourseIDMapping instance, List<System.Data.Common.DbParameter> parameters)
        {
           
            
        }

        protected override List<PrerequisiteCourseIDMapping> ParseGetAllData(System.Data.DataSet data)
        {
            var GetAllData = data.Tables[0].AsEnumerable().Select(row =>
                     new PrerequisiteCourseIDMapping
                     {
                         CourseMasterID = row.Read<int>("CourseMasterID"),
                         PrerequisiteCourseID = row.ReadString("PrerequisiteCourseID"),
                     }).ToList();

            return GetAllData;
        }

        protected override PrerequisiteCourseIDMapping Parse(System.Data.DataRow data)
        {
            return new PrerequisiteCourseIDMapping();
        }
    }
}
