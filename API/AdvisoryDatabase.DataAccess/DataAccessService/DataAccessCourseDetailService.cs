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
                       

                         CourseMasterID = row.ReadString("CourseMasterID"),
                         CourseName =row.ReadString("CourseName"),
                         LDIntakeOwner = row.ReadString("LDIntakeOwner"),
                         ProjectManagerContact = row.ReadString("ProjectManagerContact"),
                         BusinessSponsor = row.ReadString("BusinessSponsor"),
                         Descriptions = row.ReadString("Descriptions"),
                         InstructionalDesigner = row.ReadString("InstructionalDesigner"),
                         CourseOwnerID = row.ReadString("CourseOwnerID"),
                         ProgramTypeID = row.ReadString("ProgramTypeID"),
                         DeliveryTypeID = row.ReadString("DeliveryTypeID"),
                         TotalCPECredit = row.ReadString("TotalCPECredit"),
                         CourseNotes = row.ReadString("CourseNotes"),
                         Materials = row.ReadString("Materials"),
                         RoomSetUpComments = row.ReadString("RoomSetUpComments"),
                         CourseID = row.ReadString("CourseID"),
                         Overview = row.ReadString("Overview"),
                         Objectives = row.ReadString("Objectives"),

                         MaximumAttendeeCount = row.ReadString("MaximumAttendeeCount"),
                         MinimumAttendeeCount = row.ReadString("MinimumAttendeeCount"),

                         MaximumAttendeeWaitlist = row.ReadString("MaximumAttendeeWaitlist"),
                         PrerequisiteCourseID = row.ReadString("PrerequisiteCourseID"),
                         EquivalentCourseID = row.ReadString("EquivalentCourseID"),

                         FirstDeliveryDate = row.ReadString("FirstDeliveryDate"),
                         LevelofEffort = row.ReadString("LevelofEffort"),
                         Vendor = row.ReadString("Vendor"),
                         ProjectStatusID = row.ReadString("ProjectStatusID"),
                         Duration = row.ReadString("Duration"),
                         Collateral = row.ReadString("Collateral"),
                         FocusDomain = row.ReadString("FocusDomain"),
                         FocusRetired = row.ReadString("FocusRetired"),
                         FocusDiscFrom = row.ReadString("FocusDiscFrom"),
                         FocusDisplayedToLearner = row.ReadString("FocusDisplayedToLearner"),
                         CourseRecordURL = row.ReadString("CourseRecordURL"),

                         ServiceNowID = row.ReadString("ServiceNowID"),
                         SubjectMatterProfessional = row.ReadString("SubjectMatterProfessional")



                     }).ToList();

            return GetAllData;
        }

        protected override Course Parse(System.Data.DataRow data)
        {
            return new Course
            {


                CourseMasterID = data.ReadString("CourseMasterID"),
                CourseName = data.ReadString("CourseName"),
                 LDIntakeOwner = data.ReadString("LDIntakeOwner"),
                ProjectManagerContact = data.ReadString("ProjectManagerContact"),
                BusinessSponsor = data.ReadString("BusinessSponsor"),
                Descriptions = data.ReadString("Descriptions"),
                InstructionalDesigner = data.ReadString("InstructionalDesigner"),
                CourseOwnerID = data.ReadString("CourseOwnerID"),
                ProgramTypeID = data.ReadString("ProgramTypeID"),
                DeliveryTypeID = data.ReadString("DeliveryTypeID"),
                TotalCPECredit = data.ReadString("TotalCPECredit"),
                CourseNotes = data.ReadString("CourseNotes"),
                Materials = data.ReadString("Materials"),
                RoomSetUpComments = data.ReadString("RoomSetUpComments"),
                CourseID = data.ReadString("CourseID"),
                Overview = data.ReadString("Overview"),
                Objectives = data.ReadString("Objectives"),

                MaximumAttendeeCount = data.ReadString("MaximumAttendeeCount"),
                MinimumAttendeeCount = data.ReadString("MinimumAttendeeCount"),

                MaximumAttendeeWaitlist = data.ReadString("MaximumAttendeeWaitlist"),
                PrerequisiteCourseID = data.ReadString("PrerequisiteCourseID"),
                EquivalentCourseID = data.ReadString("EquivalentCourseID"),

                FirstDeliveryDate = data.ReadString("FirstDeliveryDate"),
                LevelofEffort = data.ReadString("LevelofEffort"),
                Vendor = data.ReadString("Vendor"),
                ProjectStatusID = data.ReadString("ProjectStatusID"),
                Duration = data.ReadString("Duration"),
                Collateral = data.ReadString("Collateral"),
                FocusDomain = data.ReadString("FocusDomain"),
                FocusRetired = data.ReadString("FocusRetired"),
                FocusDiscFrom = data.ReadString("FocusDiscFrom"),
                FocusDisplayedToLearner = data.ReadString("FocusDisplayedToLearner"),
                CourseRecordURL = data.ReadString("CourseRecordURL"),

                ServiceNowID = data.ReadString("ServiceNowID"),
                SubjectMatterProfessional = data.ReadString("SubjectMatterProfessional")


            };

        }

    }
}

