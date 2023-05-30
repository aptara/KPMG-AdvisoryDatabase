using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdvisoryDatabase.DataAccess.Common;
using AdvisoryDatabase.DataAccess.Repository;
using AdvisoryDatabase.Framework.Entities;
using System.Data;
using System.Data.Common;

namespace AdvisoryDatabase.DataAccess.DataAccessService
{
    public class DataAccessCourseDetailService : DataAccessRepository<Course, Int32>
    {
        protected override string GetProcedureName(OperationType operation)
        {
            string spName = string.Empty;
            switch (operation)
            {
                case OperationType.Get:
                    spName = "USP_GetCourse";
                    break;
                case OperationType.GetAll:
                    spName = "USP_GetCourse";
                    break;
                case OperationType.Add:
                    spName = "USP_ManageCourse";
                    break;
                case OperationType.Update:
                    spName = "USP_ManageCourse";
                    break;
                case OperationType.Delete:
                    spName = "USP_ManageCourse";
                    break;
                default:
                    spName = string.Empty;
                    break;
            }
            return spName;
        }
        protected override void FillParameters(OperationType operation, Course instance, List<DbParameter> parameters)
        {
            if (operation == OperationType.Get)
            {
                parameters.Add(DbHelper.CreateParameter("CourseMasterID", instance.CourseMasterID));
                parameters.Add(DbHelper.CreateParameter("IsDeleted", instance.IsDeleted));
            }
            else if (operation == OperationType.Add || operation == OperationType.Update)
            {
                parameters.Add(DbHelper.CreateParameter("CourseMasterID", instance.CourseMasterID));
                parameters.Add(DbHelper.CreateParameter("CourseName", instance.CourseName));
                parameters.Add(DbHelper.CreateParameter("LDIntakeOwner", instance.LDIntakeOwner));
                parameters.Add(DbHelper.CreateParameter("ProjectManagerContact", instance.ProjectManagerContact));
                parameters.Add(DbHelper.CreateParameter("BusinessSponsor", instance.BusinessSponsor));
                parameters.Add(DbHelper.CreateParameter("Descriptions", instance.Descriptions));
                parameters.Add(DbHelper.CreateParameter("InstructionalDesigner", instance.InstructionalDesigner));
                parameters.Add(DbHelper.CreateParameter("CourseOwnerID", instance.CourseOwnerID));
                parameters.Add(DbHelper.CreateParameter("ProgramTypeID", instance.ProgramTypeID));
                parameters.Add(DbHelper.CreateParameter("DeliveryTypeID", instance.DeliveryTypeID));
                parameters.Add(DbHelper.CreateParameter("TotalCPECredit", instance.TotalCPECredit));
                parameters.Add(DbHelper.CreateParameter("CourseNotes", instance.CourseNotes));
                parameters.Add(DbHelper.CreateParameter("Materials", instance.Materials));
                parameters.Add(DbHelper.CreateParameter("RoomSetUpComments", instance.RoomSetUpComments));
                parameters.Add(DbHelper.CreateParameter("CourseID", instance.CourseID));
                parameters.Add(DbHelper.CreateParameter("Overview", instance.Overview));
                parameters.Add(DbHelper.CreateParameter("Objectives", instance.Objectives));
                parameters.Add(DbHelper.CreateParameter("MaximumAttendeeCount", instance.MaximumAttendeeCount));
                parameters.Add(DbHelper.CreateParameter("MinimumAttendeeCount", instance.MinimumAttendeeCount));
                parameters.Add(DbHelper.CreateParameter("MaximumAttendeeWaitlist", instance.MaximumAttendeeWaitlist));
                parameters.Add(DbHelper.CreateParameter("PrerequisiteCourseID", instance.PrerequisiteCourseID));
                parameters.Add(DbHelper.CreateParameter("EquivalentCourseID", instance.EquivalentCourseID));
                parameters.Add(DbHelper.CreateParameter("FirstDeliveryDate", instance.FirstDeliveryDate));
                parameters.Add(DbHelper.CreateParameter("LevelofEffort", instance.LevelofEffort));
                parameters.Add(DbHelper.CreateParameter("Vendor", instance.Vendor));
                parameters.Add(DbHelper.CreateParameter("ProjectStatusID", instance.ProjectStatusID));
                parameters.Add(DbHelper.CreateParameter("Duration", instance.Duration));
                parameters.Add(DbHelper.CreateParameter("Collateral", instance.Collateral));
                //parameters.Add(DbHelper.CreateParameter("FocusDomain", instance.FocusDomain));
                //parameters.Add(DbHelper.CreateParameter("FocusRetired", instance.FocusRetired));
                //parameters.Add(DbHelper.CreateParameter("FocusDiscFrom", instance.FocusDiscFrom));
                //parameters.Add(DbHelper.CreateParameter("FocusDisplayedToLearner", instance.FocusDisplayedToLearner));
                parameters.Add(DbHelper.CreateParameter("CourseRecordURL", instance.CourseRecordURL));
                parameters.Add(DbHelper.CreateParameter("ServiceNowID", instance.ServiceNowID));
                parameters.Add(DbHelper.CreateParameter("SubjectMatterProfessional", instance.SubjectMatterProfessional));
                //parameters.Add(DbHelper.CreateParameter("@Status", instance.Status));

            }
            else if(operation == OperationType.Delete)
            {
                parameters.Add(DbHelper.CreateParameter("IsDeleted", instance.IsDeleted));
            }
        }

        protected override List<Course> ParseGetAllData(System.Data.DataSet data)
        {
            var GetAllData = data.Tables[0].AsEnumerable().Select(row =>
                new Course
                {
                    CourseMasterID = row.Read<int>("CourseMasterID"),
                    CourseName = row.ReadString("CourseName"),
                    LDIntakeOwner = row.ReadString("LDIntakeOwner"),
                    ProjectManagerContact = row.ReadString("ProjectManagerContact"),
                    BusinessSponsor = row.ReadString("BusinessSponsor"),
                    Descriptions = row.ReadString("Descriptions"),
                    InstructionalDesigner = row.ReadString("InstructionalDesigner"),
                    CourseOwnerID = row.Read<int?>("CourseOwnerID"),
                    ProgramTypeID = row.Read<int>("ProgramTypeID"),
                    DeliveryTypeID = row.Read<int>("DeliveryTypeID"),
                    TotalCPECredit = row.ReadString("TotalCPECredit"),
                    CourseNotes = row.ReadString("CourseNotes"),
                    Materials = row.ReadString("Materials"),
                    RoomSetUpComments = row.ReadString("RoomSetUpComments"),
                    CourseID = row.ReadString("CourseID"),
                    Overview = row.ReadString("Overview"),
                    Objectives = row.ReadString("Objectives"),

                    MaximumAttendeeCount = row.Read<decimal?>("MaximumAttendeeCount"),
                    MinimumAttendeeCount = row.Read<decimal?>("MinimumAttendeeCount"),
                    MaximumAttendeeWaitlist = row.Read<decimal?>("MaximumAttendeeWaitlist"),

                    PrerequisiteCourseID = row.ReadString("PrerequisiteCourseID"),
                    EquivalentCourseID = row.ReadString("EquivalentCourseID"),
                    FirstDeliveryDate = row.Read<DateTime>("FirstDeliveryDate"),
                    LevelofEffort = row.ReadString("LevelofEffort"),

                    Vendor = row.ReadString("Vendor"),
                    ProjectStatusID = row.Read<int?>("ProjectStatusID"),
                    ProjectStatus = row.ReadString("ProjectStatus"),

                    Duration = row.ReadString("Duration"),
                    Collateral = row.Read<bool?>("Collateral"),
                    FocusDomain = row.ReadString("FocusDomain"),
                    FocusRetired = row.ReadString("FocusRetired"),
                    FocusDiscFrom = row.ReadString("FocusDiscFrom"),
                    FocusDisplayedToLearner = row.ReadString("FocusDisplayedToLearner"),
                    CourseRecordURL = row.ReadString("CourseRecordURL"),
                    ServiceNowID = row.ReadString("ServiceNowID"),
                    SubjectMatterProfessional = row.ReadString("SubjectMatterProfessional"),
                    CreatedBy = row.Read<int>("CreatedBy"),
                    CreatedOn = row.Read<DateTime>("CreatedOn"),
                    LastUpdatedBy = row.Read<int>("LastUpdatedBy"),
                    LastUpdatedOn = row.Read<DateTime>("LastUpdatedOn"),
                    IsDeleted = row.Read<bool>("IsDeleted"),
                }).ToList();
            return GetAllData;
        }

        protected override Course Parse(System.Data.DataRow data)
        {
            return new Course
            {
                CourseMasterID = data.Read<int>("CourseMasterID"),
                CourseName = data.ReadString("CourseName"),
                LDIntakeOwner = data.ReadString("LDIntakeOwner"),
                ProjectManagerContact = data.ReadString("ProjectManagerContact"),
                BusinessSponsor = data.ReadString("BusinessSponsor"),
                Descriptions = data.ReadString("Descriptions"),
                InstructionalDesigner = data.ReadString("InstructionalDesigner"),
                CourseOwnerID = data.Read<int>("CourseOwnerID"),
                ProgramTypeID = data.Read<int>("ProgramTypeID"),
                DeliveryTypeID = data.Read<int>("DeliveryTypeID"),
                TotalCPECredit = data.ReadString("TotalCPECredit"),
                CourseNotes = data.ReadString("CourseNotes"),
                Materials = data.ReadString("Materials"),
                RoomSetUpComments = data.ReadString("RoomSetUpComments"),
                CourseID = data.ReadString("CourseID"),
                Overview = data.ReadString("Overview"),
                Objectives = data.ReadString("Objectives"),
                MaximumAttendeeCount = data.Read<decimal?>("MaximumAttendeeCount"),
                MinimumAttendeeCount = data.Read<decimal?>("MinimumAttendeeCount"),
                MaximumAttendeeWaitlist = data.Read<decimal?>("MaximumAttendeeWaitlist"),
                PrerequisiteCourseID = data.ReadString("PrerequisiteCourseID"),
                EquivalentCourseID = data.ReadString("EquivalentCourseID"),
                FirstDeliveryDate = data.Read<DateTime>("FirstDeliveryDate"),
                LevelofEffort = data.ReadString("LevelofEffort"),
                Vendor = data.ReadString("Vendor"),
                ProjectStatusID = data.Read<int?>("ProjectStatusID"),
                Duration = data.ReadString("Duration"),
                Collateral = data.Read<bool?>("Collateral"),
                FocusDomain = data.ReadString("FocusDomain"),
                FocusRetired = data.ReadString("FocusRetired"),
                FocusDiscFrom = data.ReadString("FocusDiscFrom"),
                FocusDisplayedToLearner = data.ReadString("FocusDisplayedToLearner"),
                CourseRecordURL = data.ReadString("CourseRecordURL"),
                ServiceNowID = data.ReadString("ServiceNowID"),
                SubjectMatterProfessional = data.ReadString("SubjectMatterProfessional"),
                CreatedBy = data.Read<int>("CreatedBy"),
                CreatedOn = data.Read<DateTime>("CreatedOn"),
                LastUpdatedBy = data.Read<int>("LastUpdatedBy"),
                LastUpdatedOn = data.Read<DateTime>("LastUpdatedOn"),
                //IsDeleted = data.Read<bool>("IsDeleted"),
            };
        }
    }
}

