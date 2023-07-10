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
        //public string CourseNotes { get; set; }//37
       // public string ProjectStatus { get; set; }//38  ----------which select
        public string Price { get; set; }//39
        public string Currency { get; set; }//40
        public string DisplayCallCenter { get; set; }//41DisplayCallCenter
    /*    public string FieldOfStudy1 { get; set; }//42
        public string FieldOfStudy2 { get; set; }//43
        public string FieldOfStudy3 { get; set; }//44
        public string FieldOfStudy4 { get; set; }//45
        public string FOSCredit1 { get; set; }//46
        public string FOSCredit2 { get; set; }//47
        public string FOSCredit3 { get; set; }//48
        public string FOSCredit4 { get; set; }//49
      

        public string PrerequisiteCourseID1 { get; set; }//50
        public string PrerequisiteCourseID2 { get; set; }//51
        public string EquivalentCourseID1 { get; set; }//52
        public string EquivalentCourseID2 { get; set; }//53
        public string AudienceType1 { get; set; }//54
        public string AudienceType2 { get; set; }//55
     
        public string ServiceGroup1 { get; set; }//56
        public string ServiceGroup2 { get; set; }//57
        public string ServiceGroup3 { get; set; }//58
        public string ServiceGroup4 { get; set; }//59 
        public string ServiceLine1 { get; set; }//60
        public string ServiceLine2 { get; set; }//61
        public string ServiceLine3 { get; set; }//62
        public string ServiceLine4 { get; set; }//63
        public string ServiceNetwork1 { get; set; }//64
        public string ServiceNetwork2 { get; set; }//65
        public string ServiceNetwork3 { get; set; }//66
        public string ServiceNetwork4 { get; set; }//67*/
       //68 -----------which select --final 
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

        // addd new 

        //ad new
        // add new


    }
}
/*
CourseMasterID
			    ,ISNULL(CourseID, '') AS CourseID
                 , ISNULL(DeploymentFiscalYear, '') AS DeploymentFiscalYear
				, ISNULL(CourseName, '') AS CourseName
				, ISNULL(DevelopmentYear, '') AS DevelopmentYear
				, ISNULL(Competency, '') AS Competency
				, ISNULL(ProgramKnowledgeLevel, '') AS ProgramKnowledgeLevel
				, ISNULL(CourseOverviewObjective, '') AS CourseOverviewObjective
				, ISNULL(TargetAudience, '') AS TargetAudience
				, ISNULL(EstimatedCPE, '') AS EstimatedCPE
				, ISNULL(SpecialNotice, '') AS SpecialNotice
				, ISNULL(CourseSponsor, '') AS CourseSponsor
				, ISNULL(WhichSGSLSNSponsorLearning, '') AS WhichSGSLSNSponsorLearning
				, ISNULL(SubjectMatterProfessional, '') AS 	SubjectMatterProfessional
				, ISNULL (Vendor, '') AS Vendor
				, ISNULL(ServiceNowID, '') AS ServiceNowID
				, ISnull(Descriptions, '') AS Descriptions
				, ISNULL(IsRegulatoryorLegalRequirement, '') AS IsRegulatoryorLegalRequirement
				, ISNULL(ProgramType, '') AS ProgramType				
				, ISNULL(DeliveryType, '') AS DeliveryType
				, ISNULL(Duration, '') AS Duration
				, ISNULL(FirstDeliveryDate, '') AS FirstDeliveryDate
				, ISNULL(MaximumAttendeeCount, '')  AS MaximumAttendeeCount
				, ISNULL(MinimumAttendeeCount, '') AS MinimumAttendeeCount
				, ISNULL(MaximumAttendeeWaitlist, '') AS MaximumAttendeeWaitlist
				, ISNULL(Material, '') AS Material
				, ISNULL(Collateral, '') AS Collateral
				, ISNULL(RoomSetUpComments, '') AS RoomSetUpComments
				, ISNULL(DeploymentFacilitatorConsideration, '') AS DeploymentFacilitatorConsideration
				, ISNULL(LDIIntakeOwner, 0) AS 	LDIIntakeOwner			--change name
				, ISNULL(ProjectManagerContactMaster, '') AS ProjectManagerContactMaster	--chnage name	
				, ISNULL(InstructionalDesignerMaster, '') AS InstructionalDesignerMaster	--chnage name
				, ISNULL(LevelOfEffort, '') AS LevelOfEffort
			    , ISNULL(FoucsCourseOwner1, '') AS FoucsCourseOwner1 ---add new
			    ,ISNULL(FocusCourseOwner2, '') AS FocusCourseOwner2 --addnew
				, ISNULL(CourseNotes, '') AS CourseNotes
				, ISNULL(FocusDomain, '') AS FocusDomain
				, ISNULL(FocusRetired, '') AS FocusRetired
				, ISNULL(FocusDiscFrom, '') AS FocusDiscFrom
				, ISNULL(FocusDisplayedToLearner, '') AS FocusDisplayedToLearner
				, ISNULL(DisplayCallCenter, '') AS DisplayCallCenter
				, ISNULL(CourseRecordURL, '') AS CourseRecordURL
				, ISNULL(ClarizenStartDate, '') AS ClarizenStartDate
				, ISNULL(Price, '') AS Price
				, ISNULL(Currency, '') AS Currency
				, ISNULL([Status],'') AS[Status]
				,ISNULL(OFFERING_TEMPLATE_NO, '') AS OFFERING_TEMPLATE_NO
               , ISNULL(IsRecordLocked, '') AS IsRecordLocked
				--, ProjectStatusID -- remove
				, ISNULL(Skilltext, '') AS Skilltext
				, ISNULL(IndustryText, '') AS IndustryText
				, ISNULL(AudienceLevelText, '') AS AudienceLevelText
				, ISNULL(FunctionNameText, '') AS FunctionNameText
				, ISNULL(FOSvalues, '') AS FOSvalues
				, ISNULL(SGSLSNValues, '') AS SGSLSNValues
				, ISNULL(PrerequisiteCourseID, '') AS PrerequisiteCourseID
				, ISNULL(EquivalentCourseID, '') AS EquivalentCourseID
				, ISNULL(AudienceType, '') AS AudienceType*/