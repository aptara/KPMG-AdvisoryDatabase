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
    public class DataAccessCourseDetailService : DataAccessRepository<Course, Int32>
    {
        protected override string GetProcedureName(OperationType operation)
        {
            string spName = string.Empty;
            switch (operation)
            {
                case OperationType.GetAll:
                    spName = "CourseDetail";
                    break;
                default:
                    spName = string.Empty;
                    break;
            }
            return spName;
        }
        protected override void FillParameters(OperationType operation, Course instance, List<System.Data.Common.DbParameter> parameters)
        {

        }

        protected override List<Course> ParseGetAllData(System.Data.DataSet data)
        {
            var GetAllData = data.Tables[0].AsEnumerable().Select(row =>
                     new Course
                     {
                       /*  Id = row.Read<Int32>("UserMasterID"),
                         BayID = row.ReadString("FirstName"),
                         Description = row.ReadString("LastName"),
                         SubStationID = row.Read<Int32>("LocationID"),
                         Name = row.ReadString("Email"),*/

                         CourseMasterID = row.ReadString("CourseMasterID"),
                         CourseName =row.ReadString("CourseName"),
                         ProjectManagerContact = row.ReadString("CourseName"),
                         BusinessSponsor = row.ReadString("CourseName"),
                         Descriptions = row.ReadString("CourseName"),
                         InstructionalDesigner = row.ReadString("CourseName"),
                         CourseOwnerID = row.ReadString("CourseName"),
                         ProgramTypeID = row.ReadString("CourseName"),
                         DeliveryTypeID = row.ReadString("CourseName"),
                         TotalCPECredit = row.ReadString("CourseName"),
                         CourseNotes = row.ReadString("CourseName"),
                         Materials = row.ReadString("CourseName"),
                         RoomSetUpComments = row.ReadString("CourseName"),
                         CourseID = row.ReadString("CourseName"),
                         Overview = row.ReadString("CourseName"),
                         Objectives = row.ReadString("CourseName"),

                         MaximumAttendeeCount = row.ReadString("CourseName"),
                         MinimumAttendeeCount = row.ReadString("CourseName"),

                         MaximumAttendeeWaitlist = row.ReadString("CourseName"),
                         PrerequisiteCourseID = row.ReadString("CourseName"),
                         EquivalentCourseID = row.ReadString("CourseName"),

                         FirstDeliveryDate = row.ReadString("CourseName"),
                         LevelofEffort = row.ReadString("CourseName"),
                         Vendor = row.ReadString("CourseName"),
                         ProjectStatusID = row.ReadString("CourseName"),
                         Duration = row.ReadString("CourseName"),
                         Collateral = row.ReadString("CourseName"),
                         FocusDomain = row.ReadString("CourseName"),
                         FocusRetired = row.ReadString("CourseName"),
                         FocusDiscFrom = row.ReadString("CourseName"),
                         FocusDisplayedToLearner = row.ReadString("CourseName"),
                         CourseRecordURL = row.ReadString("CourseName"),

                         ServiceNowID = row.ReadString("CourseName"),
                         SubjectMatterProfessional = row.ReadString("CourseName")



                     }).ToList();

            return GetAllData;
        }

        protected override Course Parse(System.Data.DataRow data)
        {
            return new Course
            {
               
                CourseMasterID = data.ReadString("CourseMasterID"),
                CourseName = data.ReadString("CourseName"),
                ProjectManagerContact = data.ReadString("CourseName"),
                BusinessSponsor = data.ReadString("CourseName"),
                Descriptions = data.ReadString("CourseName"),
                InstructionalDesigner = data.ReadString("CourseName"),
                CourseOwnerID = data.ReadString("CourseName"),
                ProgramTypeID = data.ReadString("CourseName"),
                DeliveryTypeID = data.ReadString("CourseName"),
                TotalCPECredit = data.ReadString("CourseName"),
                CourseNotes = data.ReadString("CourseName"),
                Materials = data.ReadString("CourseName"),
                RoomSetUpComments = data.ReadString("CourseName"),
                CourseID = data.ReadString("CourseName"),
                Overview = data.ReadString("CourseName"),
                Objectives = data.ReadString("CourseName"),

                MaximumAttendeeCount = data.ReadString("CourseName"),
                MinimumAttendeeCount = data.ReadString("CourseName"),

                MaximumAttendeeWaitlist = data.ReadString("CourseName"),
                PrerequisiteCourseID = data.ReadString("CourseName"),
                EquivalentCourseID = data.ReadString("CourseName"),

                FirstDeliveryDate = data.ReadString("CourseName"),
                LevelofEffort = data.ReadString("CourseName"),
                Vendor = data.ReadString("CourseName"),
                ProjectStatusID = data.ReadString("CourseName"),
                Duration = data.ReadString("CourseName"),
                Collateral = data.ReadString("CourseName"),
                FocusDomain = data.ReadString("CourseName"),
                FocusRetired = data.ReadString("CourseName"),
                FocusDiscFrom = data.ReadString("CourseName"),
                FocusDisplayedToLearner = data.ReadString("CourseName"),
                CourseRecordURL = data.ReadString("CourseName"),

                ServiceNowID = data.ReadString("CourseName"),
                SubjectMatterProfessional = data.ReadString("CourseName")


            };

        }

    }
}

