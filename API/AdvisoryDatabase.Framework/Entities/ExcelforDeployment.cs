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
    
        public string CourseName { get; set; }
        public string CourseID { get; set; }
      
        
        public string DeploymentFiscalYear { get; set; }//3
  
        public string Competency { get; set; }// add in sp --done
        public string Skilltext { get; set; }//4  --------//Skilltext --done
        public string IndustryText { get; set; }
        public string ProgramKnowledgeLevel { get; set; }
        public string Status { get; set; }
        public string CourseOverviewObjective { get; set; }//7
        public string TargetAudience { get; set; }//8
        public string AudienceLevelText { get; set; }
        public string DevelopmentYear { get; set; }
        public string SGSLSNValues { get; set; }
        public string FOSvalues { get; set; }
        public string EstimatedCPE { get; set; }//10

        public string PrerequisiteCourseID { get; set; }// add new 
        public string EquivalentCourseID { get; set; }
        public string SpecialNotice { get; set; }//11
        public string FunctionNameText { get; set; }
        public string AudienceType { get; set; }
        public string CourseSponsor { get; set; }//13
        public string WhichSGSLSNSponsorLearning { get; set; }//14
        public string SubjectMatterProfessional { get; set; }//15
        public string Vendor { get; set; }//16
        public string ServiceNowID { get; set; }//17
        public string Descriptions { get; set; }//18
        public string IsRegulatoryorLegalRequirement { get; set; }//19
        public string ProgramType { get; set; }//20
        public string DeliveryType { get; set; }//21
        public string Duration { get; set; }//22
        public string FirstDeliveryDate { get; set; }//23
        public string MaximumAttendeeCount { get; set; }//24
        public string MinimumAttendeeCount { get; set; }//25
        public string MaximumAttendeeWaitlist { get; set; }//26
        public string Material { get; set; }//27
        public string Collateral { get; set; }//28
        public string LevelOfEffort { get; set; }
        public string RoomSetUpComments { get; set; }//29
        public string DeploymentFacilitatorConsideration { get; set; }//30
        public string LDIIntakeOwner { get; set; }//31
        public string ProjectManagerContactMaster { get; set; }//32
        public string InstructionalDesignerMaster { get; set; }//33
       //34
       public string FoucsCourseOwner1 { get; set; }//35
       public string FocusCourseOwner2 { get; set; }//36
      
        public string Price { get; set; }//39
        public string Currency { get; set; }//40
        public string DisplayCallCenter { get; set; }//41DisplayCallCenter

   
        public string OFFERING_TEMPLATE_NO { get; set; }//69
        //70
        public string IsRecordLocked { get; set; }//71
        public string ClarizenStartDate { get; set; }//72
        public string CourseRecordURL { get; set; }//73
        public string FocusDomain { get; set; }//74  --------hard code
        public string FocusRetired { get; set; }//75  ----hard code 2
        public string FocusDiscFrom { get; set; }//76 ---- hard code 3
        public string FocusDisplayedToLearner { get; set; }//77 --hard code4
        public string CourseMasterID { get; set; }

   
    }
}
