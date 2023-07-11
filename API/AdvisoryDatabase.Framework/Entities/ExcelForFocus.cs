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
        public string ID { get; set; }
        public string OFFERING_TEMPLATE_NO { get; set; }
      //  public string CourseID { get; set; }

        public string Version { get; set; }
        public string CourseName { get; set; }


        public string CourseDomain { get; set; }

        public string AvailableFrom { get; set; }
        public string DiscontinuedFrom { get; set; }
        public string Currency { get; set; }
        public string Price { get; set; }
         public string CourseOverviewObjective { get; set; }

        public string DisplaytoLearner { get; set; }
        public string DisplaytoCallCenter { get; set; }
        public string AudienceType1 { get; set; }
        public string AudienceType2 { get; set; }
        public string Vendor { get; set; } 
        public string FunctionName { get; set; }
        public string DevelopmentYear { get; set; }
       
        public string ProgramKnowledgeLevel { get; set; }
        public string EstimatedCPE { get; set; }

        public string TargetAudience { get; set; }
        public string SpecialNotice { get; set; }
        public string FoucsCourseOwner1 { get; set; }
        public string FocusCourseOwner2 { get; set; }
        public string PrerequisiteCourseID1 { get; set; }
        public string PREREQUISITE_VERSION1 { get; set; }// add new
        public string PrerequisiteCourseID2 { get; set; }
        public string PREREQUISITE_VERSION2 { get; set; }// add new
        public string EquivalentCourseID1 { get; set; }
        public string EQUIVALENT_VERSION1 { get; set; }
        public string EquivalentCourseID2 { get; set; }
        public string EQUIVALENT_VERSION2 { get; set; }//add new
        public string DeliveryType { get; set; }
        public string Duration { get; set; }
        public string FieldOfStudy1 { get; set; }
        public string FOSCredit1 { get; set; } 
        public string FieldOfStudy2 { get; set; }

        public string FOSCredit2 { get; set; }
        public string FieldOfStudy3 { get; set; }//
        public string FOSCredit3 { get; set; }//
        public string FieldOfStudy4 { get; set; }//
        public string FOSCredit4 { get; set; }//


        public string MinimumAttendeeCount { get; set; }

        public string MaximumAttendeeCount { get; set; }

        public string MaximumAttendeeWaitlist { get; set; }
    // public string DiscontinuedFrom { get; set; }

        public string FocusTemplateName { get; set; }
    public string ErrorMessage { get; set; }

        public string CourseMasterIDs { get; set; }
        public int CourseMasterID { get; set; }

        // add new col

        //---------------------------------------end-------------

       //not show in the client excel 
       //not show in the client excel 
       //not show in the client excel 

       //not show in the client excel 
      
       //not show in the client excel 

        public string IsAllowedToFocusRDI { get; set; }//not show in the client excel 
        public string Status { get; set; }//not show in the client excel 







    }
}
