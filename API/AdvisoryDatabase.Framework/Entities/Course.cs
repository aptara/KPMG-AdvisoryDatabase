using AdvisoryDatabase.Framework.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvisoryDatabase.Framework.Entities
{

    [Serializable]
    public class Course : BaseEntity<Int32>
    {
        public int CourseMasterID { get; set; }
        public string CourseName { get; set; }
        public string LDIntakeOwner { get; set; }
        public string ProjectManagerContact { get; set; }
        public string BusinessSponsor { get; set; }
        public string Descriptions { get; set; }
        public string InstructionalDesigner { get; set; }
        public int? CourseOwnerID { get; set; }
        public int ProgramTypeID { get; set; }
        public int DeliveryTypeID { get; set; }
        public string TotalCPECredit { get; set; }
        public string CourseNotes { get; set; }
        public string Materials { get; set; }
        public string RoomSetUpComments { get; set; }
        public string CourseID { get; set; }
        public string Overview { get; set; }
        public string Objectives { get; set; }
        public decimal? MaximumAttendeeCount { get; set; }
        public decimal? MinimumAttendeeCount { get; set; }
        public decimal? MaximumAttendeeWaitlist { get; set; }
        public string PrerequisiteCourseID { get; set; }
        public string EquivalentCourseID { get; set; }
        public DateTime FirstDeliveryDate { get; set; }
        public string LevelofEffort { get; set; }
        public string Vendor { get; set; }
        public int? ProjectStatusID { get; set; }
        public string Duration { get; set; }
        public bool? Collateral { get; set; }
        public string FocusDomain { get; set; }
        public string FocusRetired { get; set; }
        public string FocusDiscFrom { get; set; }
        public string FocusDisplayedToLearner { get; set; }
        public string CourseRecordURL { get; set; }
        public string ServiceNowID { get; set; }
        public string SubjectMatterProfessional { get; set; }
        public bool IsDeleted { get; set; }
    }
}
