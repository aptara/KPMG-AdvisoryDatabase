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
        public string CourseID { get; set; }//0 -- add in sp
        public string CourseMasterID { get; set; }//1
        public string CourseName { get; set; }//2
        public string DeploymentFiscalYear { get; set; }//3

        public string Competency { get; set; }// add in sp
        public string Skill { get; set; }//4
        public string Industry { get; set; }//5
        public string ProgramKnowledgeLevel { get; set; }//6        
        public string CourseOverviewObjective { get; set; }//7
        public string TargetAudience { get; set; }//8
        public string AudienceLevel { get; set; }//9
        public string EstimatedCPE { get; set; }//10
        public string SpecialNotice { get; set; }//11
        public string FunctionName { get; set; }//12
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
        public string RoomSetUpComments { get; set; }//29
        public string DeploymentFacilitatorConsideration { get; set; }//30
        public string LDIIntakeOwner { get; set; }//31
        public string ProjectManagerContactMaster { get; set; }//32
        public string InstructionalDesignerMaster { get; set; }//33
        public string LevelOfEffort { get; set; }//34
        public string FoucsCourseOwner1 { get; set; }//35
        public string FocusCourseOwner2 { get; set; }//36
        public string CourseNotes { get; set; }//37
        public string ProjectStatus { get; set; }//38  ----------which select
        public string Price { get; set; }//39
        public string Currency { get; set; }//40
        public string DisplayCallCenter { get; set; }//41
        public string FieldOfStudy1 { get; set; }//42
        public string FieldOfStudy2 { get; set; }//43
        public string FieldOfStudy3 { get; set; }//44
        public string FieldOfStudy4 { get; set; }//45
        public string Status { get; set; }//46 -----------which select
        public string OFFERING_TEMPLATE_NO { get; set; }//47-----remove or not
        public string DevelopmentYear { get; set; }//48
        public string IsRecordLocked { get; set; }//49 --------remove or not
        public string DoesCourseFromSingularity { get; set; }//50 --------remove
        public string CourseSingularityID { get; set; }//51 ------------remove
        public string IsvalueSelected { get; set; }//52  -------------- remove
        public string PrerequisiteCourseID1 { get; set; }//53
        public string PrerequisiteCourseID2 { get; set; }//54
        public string EquivalentCourseID1 { get; set; }//55
        public string EquivalentCourseID2 { get; set; }//56
        public string AudienceType1 { get; set; }//57
        public string AudienceType2 { get; set; }//58
        public string FOSCredit1 { get; set; }//59
        public string FOSCredit2 { get; set; }//60
        public string FOSCredit3 { get; set; }//61
        public string FOSCredit4 { get; set; }//62
        public string ServiceGroup1 { get; set; }//63
        public string ServiceGroup2 { get; set; }//64
        public string ServiceGroup3 { get; set; }//65
        public string ServiceGroup4 { get; set; }//66
        public string ServiceLine1 { get; set; }//67
        public string ServiceLine2 { get; set; }//68
        public string ServiceLine3 { get; set; }//69
        public string ServiceLine4 { get; set; }//70
        public string ServiceNetwork1 { get; set; }//71
        public string ServiceNetwork2 { get; set; }//72
        public string ServiceNetwork3 { get; set; }//73
        public string ServiceNetwork4 { get; set; }//74
        public string ClarizenStartDate { get; set; }//75
        public string CourseRecordURL { get; set; }//76
        public string FocusDomain { get; set; }//77  --------hard code
        public string FocusRetired { get; set; }//78  ----hard code 2
        public string FocusDiscFrom { get; set; }//79 ---- hard code 3
        public string FocusDisplayedToLearner { get; set; }//80 --hard code4
     


    }
}

/*

public string CourseMasterID { get; set; } //1
public string CourseName { get; set; }//2
public string DeploymentFiscalYear { get; set; }//3
public string Competency { get; set; }//4
public string Skill { get; set; }//5
public string Industry { get; set; }//6
public string ProgramKnowledgeLevel { get; set; }//5
public string CourseOverviewObjective { get; set; }
public string TargetAudience { get; set; }//5
public string AudienceLevel1 { get; set; }//5
public string AudienceLevel2 { get; set; }//5
public string EstimatedCPE { get; set; }
public string SpecialNotice { get; set; }//5
public string FunctionName { get; set; }//5
public string CourseSponsor { get; set; }
public string WhichSGSLSNSponsorLearning { get; set; }//5
public string SubjectMatterProfessional { get; set; }//5
public string Skill { get; set; }//5
public string Skill { get; set; }//5
public string Skill { get; set; }//5
public string Skill { get; set; }//5
public string Skill { get; set; }//5
public string Skill { get; set; }//5
public string Skill { get; set; }//5
public string Skill { get; set; }//5
public string LDIIntakeOwner { get; set; }


public string ProjectManagerContactMaster { get; set; }


public string InstructionalDesignerMaster { get; set; }


public string Material { get; set; }
public string RoomSetUpComments { get; set; }
public string CourseID { get; set; }

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
*/