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
    public class DataAccessCourseDropdownMasterDataService : DataAccessRepository<DropdownData, long>
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
            dropdownData.CompetencyMasterData = data.Tables[0].AsEnumerable().Select(row =>
                     new CourseMasterData
                     {
                         Id = row.Read<long>("Id"),
                         DisplayName = row.ReadString("DisplayName"),
                         
                     }).ToList();
            
            dropdownData.SkillMasterData = data.Tables[1].AsEnumerable().Select(row =>
                     new CourseMasterData
                     {
                         Id = row.Read<long>("Id"),
                         DisplayName = row.ReadString("DisplayName"),

                     }).ToList();
            
            dropdownData.IndustryMasterData = data.Tables[2].AsEnumerable().Select(row =>
                     new CourseMasterData
                     {
                         Id = row.Read<long>("Id"),
                         DisplayName = row.ReadString("DisplayName"),

                     }).ToList();
            dropdownData.ProgramKnowledgeLevelMasterData = data.Tables[3].AsEnumerable().Select(row =>
                     new CourseMasterData
                     {
                         Id = row.Read<long>("Id"),
                         DisplayName = row.ReadString("DisplayName"),

                     }).ToList();
            dropdownData.AudienceLevelMasterData = data.Tables[4].AsEnumerable().Select(row =>
                     new CourseMasterData
                     {
                         Id = row.Read<long>("Id"),
                         DisplayName = row.ReadString("DisplayName"),

                     }).ToList();
            dropdownData.ServiceGroupMasterData = data.Tables[5].AsEnumerable().Select(row =>
                     new CourseMasterData
                     {
                         Id = row.Read<long>("Id"),
                         DisplayName = row.ReadString("DisplayName"),

                     }).ToList();
            dropdownData.ServiceLineMasterData = data.Tables[6].AsEnumerable().Select(row =>
                     new CourseMasterData
                     {
                         Id = row.Read<long>("Id"),
                         DisplayName = row.ReadString("DisplayName"),

                     }).ToList();
            dropdownData.ServiceNetworkMasterData = data.Tables[7].AsEnumerable().Select(row =>
                     new CourseMasterData
                     {
                         Id = row.Read<long>("Id"),
                         DisplayName = row.ReadString("DisplayName"),

                     }).ToList();
            dropdownData.FieldOfStudyMasterData = data.Tables[8].AsEnumerable().Select(row =>
                     new CourseMasterData
                     {
                         Id = row.Read<long>("Id"),
                         DisplayName = row.ReadString("DisplayName"),

                     }).ToList();
            dropdownData.FunctionMasterData = data.Tables[9].AsEnumerable().Select(row =>
                     new CourseMasterData
                     {
                         Id = row.Read<long>("Id"),
                         DisplayName = row.ReadString("DisplayName"),

                     }).ToList();
            dropdownData.DeliveryTypeMasterData = data.Tables[10].AsEnumerable().Select(row =>
                     new CourseMasterData
                     {
                         Id = row.Read<long>("Id"),
                         DisplayName = row.ReadString("DisplayName"),

                     }).ToList();
            dropdownData.ProgramTypeMasterData = data.Tables[11].AsEnumerable().Select(row =>
                     new CourseMasterData
                     {
                         Id = row.Read<long>("Id"),
                         DisplayName = row.ReadString("DisplayName"),

                     }).ToList();
            dropdownData.CourseOwnerMasterData = data.Tables[12].AsEnumerable().Select(row =>
                     new CourseMasterData
                     {
                         Id = row.Read<long>("Id"),
                         DisplayName = row.ReadString("DisplayName"),

                     }).ToList();
            dropdownData.MaterialMasterData = data.Tables[13].AsEnumerable().Select(row =>
                     new CourseMasterData
                     {
                         Id = row.Read<long>("Id"),
                         DisplayName = row.ReadString("DisplayName"),

                     }).ToList();
            dropdownData.LevelOfEffortMasterData = data.Tables[14].AsEnumerable().Select(row =>
                     new CourseMasterData
                     {
                         Id = row.Read<long>("Id"),
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
