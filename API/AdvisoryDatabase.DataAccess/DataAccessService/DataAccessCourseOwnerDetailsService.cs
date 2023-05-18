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
    public class   DataCourseOwnerDetails : DataAccessRepository<CourseOwnerDetails, Int32>
    {
        protected override string GetProcedureName(OperationType operation)
        {
            string spName = string.Empty;
            switch (operation)
            {
                case OperationType.GetAll:
                    spName = "CourseOwnerDetail";
                    break;
                default:
                    spName = string.Empty;
                    break;
            }
            return spName;
        }
        protected override void FillParameters(OperationType operation, CourseOwnerDetails instance, List<System.Data.Common.DbParameter> parameters)
        {

        }
        protected override List<CourseOwnerDetails> ParseGetAllData(System.Data.DataSet data)
        {
            var GetAllData = data.Tables[0].AsEnumerable().Select(row =>
                     new CourseOwnerDetails
                     {
                        
                         CourseOwnerID = row.ReadString("CourseOwnerID"),
                         CourseOwner = row.ReadString("CourseOwner"),
                      
                     }).ToList();

            return GetAllData;
        }
        protected override CourseOwnerDetails Parse(System.Data.DataRow data)
        {
            return new CourseOwnerDetails
            {
                
                CourseOwnerID = data.ReadString("CourseOwnerID"),
                CourseOwner = data.ReadString("CourseOwner"),
              

            };
        }

    }
}



