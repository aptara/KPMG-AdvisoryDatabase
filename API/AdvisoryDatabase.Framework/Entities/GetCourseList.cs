using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AdvisoryDatabase.Framework.Common;

namespace AdvisoryDatabase.Framework.Entities
{
   public class GetCourseList : BaseEntity<Int32>
    {
        
        public string CourseID { get; set; }
        public string CourseName { get; set; }

        public string TargetAudience { get; set; }
        public string FirstDeliveryDate { get; set; }
        public string FOSvalues { get; set; }
        /*
         public string FieldOfStudy1 { get; set; }
         public string FieldOfStudy2 { get; set; }
         public string FieldOfStudy3 { get; set; }
         public string FieldOfStudy4 { get; set; }
 */
        public string EstimatedCPE { get; set; }

        public string Skilltext { get; set; }
        public string ProgramType { get; set; }
        public string DeliveryType { get; set; }
        public string LDIIntakeOwner { get; set; }
        public string ProgramKnowledgeLevel { get; set; }
        public string InstructionalDesignerMaster { get; set; }
        public string ProjectManagerContactMaster { get; set; }
        public string Competency { get; set; }
        public string IndustryText { get; set; }
        public string CourseSponsor { get; set; }
        public string Vendor { get; set; }
        public string ServiceNowID { get; set; }
        public string SGSLSNValues { get; set; }

        /*      public string ServiceGroup1 { get; set; }
              public string ServiceGroup2 { get; set; }
              public string ServiceGroup3 { get; set; }
              public string ServiceGroup4 { get; set; }
              public string ServiceLine1 { get; set; }
              public string ServiceLine2 { get; set; }
              public string ServiceLine3 { get; set; }
              public string ServiceLine4 { get; set; }
              public string ServiceNetwork1 { get; set; }
              public string ServiceNetwork2 { get; set; }
              public string ServiceNetwork3 { get; set; }
              public string ServiceNetwork4 { get; set; }*/

        public string FocusDomain { get; set; }
        public string Duration { get; set; }

       
        public string Status { get; set; }

       
        
        public string CourseMasterID { get; set; }
    }
}

