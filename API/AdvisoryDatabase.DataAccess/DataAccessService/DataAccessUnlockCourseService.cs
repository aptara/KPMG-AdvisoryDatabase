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
    public class DataAccessUnlockCourseDetailsService : DataAccessRepository<UnlockCourseMap, Int32>
    {
        protected override string GetProcedureName(OperationType operation)
        {
            string spName = string.Empty;
            switch (operation)
            {
                case OperationType.Update:

                    spName = "USP_UnlockCourseRecord";
                    break;
                default:
                    spName = string.Empty;
                    break;
            }
            return spName;
        }

        protected override void FillParameters(OperationType operation, UnlockCourseMap instance, List<System.Data.Common.DbParameter> parameters)
        {
            switch (operation)
            {
                case OperationType.Update:

                    parameters.Add(DbHelper.CreateParameter("CourseMasterID", instance.CourseMasterIDs));
                    break;



                case OperationType.Get:
                    parameters.Add(DbHelper.CreateParameter("CourseMasterID", instance.CourseMasterIDs));
                    break;

                default:
                    break;
            }

        }
        protected override List<UnlockCourseMap> ParseGetAllData(System.Data.DataSet data)
        {
            var GetAllData = data.Tables[0].AsEnumerable().Select(row =>
                     new UnlockCourseMap
                     {
                         CourseMasterID = Int32.Parse(row.ReadString("CourseMasterID")),
                       
                     }).ToList();

            return GetAllData;
        }
        protected override UnlockCourseMap Parse(System.Data.DataRow data)
        {
            return new UnlockCourseMap
            {


                CourseMasterID = Int32.Parse(data.ReadString("CourseMasterID"))
                
            };

        }
    }
}
