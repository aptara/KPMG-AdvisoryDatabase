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
    public class DataAccessCourseDropdownMasterDataService : DataAccessRepository<DropdownData, Int32>
    {
        protected override string GetProcedureName(OperationType operation)
        {
            string spName = string.Empty;
            switch (operation)
            {
                case OperationType.GetAll:
                    spName = "USP_GetCorseDropdownMasterData";
                    break;
                
                default:
                    spName = string.Empty;
                    break;
            }
            return spName;
        }

        protected override void FillParameters(OperationType operation, DropdownData instance, List<System.Data.Common.DbParameter> parameters)
        {
        }

        protected override List<DropdownData> ParseGetAllData(System.Data.DataSet data)
        {
            List<DropdownData> dropdownDatas = new List<DropdownData>();
            DropdownData dropdownData = new DropdownData();
            dropdownData.CourseOwnerMasters = data.Tables[0].AsEnumerable().Select(row =>
                     new CourseMasterData
                     {
                         Id = row.Read<Int32>("Id"),
                         DisplayName = row.ReadString("DisplayName"),
                         
                     }).ToList();

            dropdownData.ProjectStatusMasters = data.Tables[1].AsEnumerable().Select(row =>
                     new CourseMasterData
                     {
                         Id = row.Read<Int32>("Id"),
                         DisplayName = row.ReadString("DisplayName"),

                     }).ToList();

            dropdownData.StatusMasters = data.Tables[2].AsEnumerable().Select(row =>
                     new CourseMasterData
                     {
                         Id = row.Read<Int32>("Id"),
                         DisplayName = row.ReadString("DisplayName"),

                     }).ToList();
            
            dropdownData.DeliveryTypeMasters = data.Tables[3].AsEnumerable().Select(row =>
                     new CourseMasterData
                     {
                         Id = row.Read<Int32>("Id"),
                         DisplayName = row.ReadString("DisplayName"),

                     }).ToList();
            dropdownData.ProgramTypeMasters = data.Tables[4].AsEnumerable().Select(row =>
                     new CourseMasterData
                     {
                         Id = row.Read<Int32>("Id"),
                         DisplayName = row.ReadString("DisplayName"),

                     }).ToList();
            dropdownData.ServiceGroupMasters = data.Tables[5].AsEnumerable().Select(row =>
                     new CourseMasterData
                     {
                         Id = row.Read<Int32>("Id"),
                         DisplayName = row.ReadString("DisplayName"),

                     }).ToList();
            dropdownData.ServiceLineMasters = data.Tables[6].AsEnumerable().Select(row =>
                     new CourseMasterData
                     {
                         Id = row.Read<Int32>("Id"),
                         DisplayName = row.ReadString("DisplayName"),

                     }).ToList();
            dropdownData.ServiceNetworkMasters = data.Tables[7].AsEnumerable().Select(row =>
                     new CourseMasterData
                     {
                         Id = row.Read<Int32>("Id"),
                         DisplayName = row.ReadString("DisplayName"),

                     }).ToList();
            dropdownData.AudienceLevelMasters = data.Tables[8].AsEnumerable().Select(row =>
                     new CourseMasterData
                     {
                         Id = row.Read<Int32>("Id"),
                         DisplayName = row.ReadString("DisplayName"),

                     }).ToList();
            dropdownData.FieldOfFieldOfStudyMaster = data.Tables[9].AsEnumerable().Select(row =>
                     new CourseMasterData
                     {
                         Id = row.Read<Int32>("Id"),
                         DisplayName = row.ReadString("DisplayName"),

                     }).ToList();
            dropdownData.ProgramKnowledgeLevelMaster = data.Tables[10].AsEnumerable().Select(row =>
                     new CourseMasterData
                     {
                         Id = row.Read<Int32>("Id"),
                         DisplayName = row.ReadString("DisplayName"),

                     }).ToList();
            dropdownData.CourseFunctionMasters = data.Tables[11].AsEnumerable().Select(row =>
                     new CourseMasterData
                     {
                         Id = row.Read<Int32>("Id"),
                         DisplayName = row.ReadString("DisplayName"),

                     }).ToList();
            dropdownDatas.Add(dropdownData);
            return dropdownDatas;
        }

        protected override DropdownData Parse(System.Data.DataRow data)
        {
            return new DropdownData();
        }
    }
}
