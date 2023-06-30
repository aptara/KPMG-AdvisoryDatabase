using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdvisoryDatabase.Framework.Common;

namespace AdvisoryDatabase.Framework.Entities
{
    public class ExcelforDeployment : BaseEntity<Int32>
    {
        public string CourseMasterID { get; set; }
        public string CourseName { get; set; }
        public string LDIIntakeOwner { get; set; }
        public string ProjectManagerContactMaster { get; set; }

        public string CourseSponsor { get; set; }
        public string InstructionalDesignerMaster { get; set; }
        public string EstimatedCPE { get; set; }

        public string Material { get; set; }
        public string RoomSetUpComments { get; set; }
        public string CourseID { get; set; }
        public string CourseOverviewObjective { get; set; }
        // public string Objectives { get; set; }
        public string MaximumAttendeeCount { get; set; }
        public string MinimumAttendeeCount { get; set; }
        public string MaximumAttendeeWaitlist { get; set; }
        public string PrerequisiteCourseID1 { get; set; }
        public string PrerequisiteCourseID2 { get; set; }
        public string EquivalentCourseID1 { get; set; }
        public string EquivalentCourseID2 { get; set; }
        public string FirstDeliveryDate { get; set; }
        public string Duration { get; set; }
        public string Collateral { get; set; }
        public string Status { get; set; }


    }
}


