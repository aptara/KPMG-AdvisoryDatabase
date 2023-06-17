using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdvisoryDatabase.Framework.Common;

namespace AdvisoryDatabase.Framework.Entities
{
    public class GetExcelForFocusInfo : BaseEntity<Int32>
    {



        public int CourseMasterID { get; set; }
        public string CourseName { get; set; }

        // public string FieldOfStudy { get; set; }
        /*      public string FOS_DEFAULT_CREDITS1 { get; set; }
              public string FOS_DEFAULT_CREDITS2 { get; set; }
              public string FOS_DEFAULT_CREDITS3 { get; set; }
              public string FOS_DEFAULT_CREDITS4 { get; set; }*/


        public string PrerequisiteCourseID { get; set; }
        public string EquivalentCourseID { get; set; }
        // public string CourseOwner { get; set; }
        public string DeliveryType { get; set; }
        public string EstimatedCPE { get; set; }
        public string CourseID { get; set; }
        public string CourseOverviewObjective { get; set; }
        // public string Objectives { get; set; }
        public string MaximumAttendeeCount { get; set; }
        public string MinimumAttendeeCount { get; set; }
        public string MaximumAttendeeWaitlist { get; set; }
        public string FoucsCourseOwner1 { get; set; }
        public string FocusCourseOwner2 { get; set; }

        public string FirstDeliveryDate { get; set; }
        public string Duration { get; set; }


        public string FocusDomain { get; set; }
        public string FocusDiscFrom { get; set; }
        public string FocusDisplayedToLearner { get; set; }
        public string FunctionName { get; set; }
        public string DeploymentFiscalYear { get; set; }
        public string Price { get; set; }
        public string Currency { get; set; }

        public string DisplayCallCenter { get; set; }

        public string AudienceType1 { get; set; }
        public string AudienceType2 { get; set; }


        public string ProgramKnowledgeLevel { get; set; }
        public string TargetAudience { get; set; }
        public string SpecialNotice { get; set; }

        public string Status { get; set; }
        // public string SubjectMatterProfessional { get; set; }





    }
}