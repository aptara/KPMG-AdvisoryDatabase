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
        public string CourseMasterID { get; set; }
        public string CourseName { get; set; }
        public string LDIntakeOwner { get; set; }
        public string ProjectManagerContact { get; set; }
        public string BusinessSponsor { get; set; }
        public string Descriptions { get; set; }
        public string InstructionalDesigner { get; set; }
        public string CourseOwnerID { get; set; }
        public string ProgramTypeID { get; set; }
        public string DeliveryTypeID { get; set; }
        public string TotalCPECredit { get; set; }
        public string CourseNotes { get; set; }
        public string Materials { get; set; }
        public string RoomSetUpComments { get; set; }
        public string CourseID { get; set; }

        public string Overview { get; set; }
        public string Objectives { get; set; }
        public string MaximumAttendeeCount { get; set; }
        public string MinimumAttendeeCount { get; set; }
        public string MaximumAttendeeWaitlist { get; set; }
        public string PrerequisiteCourseID { get; set; }
        public string EquivalentCourseID { get; set; }
        public string FirstDeliveryDate { get; set; }
        public string LevelofEffort { get; set; }
        public string Vendor { get; set; }
        public string ProjectStatusID { get; set; }
        public string Duration { get; set; }
        public string Collateral { get; set; }
        public string FocusDomain { get; set; }
        public string FocusRetired { get; set; }
        public string FocusDiscFrom { get; set; }
        public string FocusDisplayedToLearner { get; set; }
        public string CourseRecordURL { get; set; }
        public string ServiceNowID { get; set; }
        public string SubjectMatterProfessional { get; set; }
       /* public string CreatedBy { get; set; }

        public string CreatedOn { get; set; }
        public string LastUpdatedBy { get; set; }
        public string LastUpdatedOn { get; set; }
*/

    }
}
