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
        public string LDIntakeOwner { get; set; }
        public string ProjectManagerContact { get; set; }

        public string CourseSponsor { get; set; }
        public string InstructionalDesigner { get; set; }
        public string EstimatedCPE { get; set; }

        public string Material { get; set; }
        public string RoomSetUpComments { get; set; }
        public string CourseID { get; set; }
        public string CourseOverviewObjective { get; set; }
        // public string Objectives { get; set; }
        public string MaximumAttendeeCount { get; set; }
        public string MinimumAttendeeCount { get; set; }
        public string MaximumAttendeeWaitlist { get; set; }
        public string PrerequisiteCourseID { get; set; }
        public string EquivalentCourseID { get; set; }
        public string FirstDeliveryDate { get; set; }
        public string Duration { get; set; }
        public string Collateral { get; set; }
        public string Status { get; set; }


    }
}


/*CourseMaster.CourseMasterID,CourseMaster.CourseName,CourseMaster.LDIntakeOwner,CourseMaster.ProjectManagerContact,CourseMaster.CourseSponsor,
 CourseMaster.InstructionalDesigner,CourseMaster.EstimatedCPE,CourseMaster.RoomSetUpComments,CourseMaster.CourseID,
 CourseMaster.CourseOverviewObjective,CourseMaster.MaximumAttendeeCount,CourseMaster.MinimumAttendeeCount,CourseMaster.MaximumAttendeeWaitlist,CourseMaster.PrerequisiteCourseID,
 CourseMaster.EquivalentCourseID,CourseMaster.FirstDeliveryDate,CourseMaster.Duration,CourseMaster.Collateral,
 
 MaterialMaster.Material*/