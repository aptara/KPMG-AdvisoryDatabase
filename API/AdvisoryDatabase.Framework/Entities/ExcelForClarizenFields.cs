using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdvisoryDatabase.Framework.Common;

namespace AdvisoryDatabase.Framework.Entities
{
    public class ExcelForClarizen : BaseEntity<Int32>
    {


        public string CourseName { get; set; }

        public string LDIntakeOwner { get; set; }

        public string ProjectManagerContact { get; set; }

        public string CourseSponsor { get; set; }
        public string Descriptions { get; set; }
        public string InstructionalDesigner { get; set; }
        public string SubjectMatterProfessional { get; set; }
        public string ProgramType { get; set; }
        public string DeliveryType { get; set; }

        public string EstimatedCPE { get; set; }
        public string CourseID { get; set; }
        public string FirstDeliveryDate { get; set; }
        public string DeploymentFiscalYear { get; set; }

        public string LevelofEffort { get; set; }
       // public string Duration { get; set; }// remove

        public string ClarizenStartDate { get; set; }
        public string CourseRecordURL { get; set; }

        public string FocusTemplateName { get; set; }
        public string ErrorMessage { get; set; }


        public string Status { get; set; }
        public string CourseMasterIDs { get; set; }
        public int CourseMasterID { get; set; }

        //public string ProjectStatusID { get; set; }
        //  public string ServiceNowID { get; set; }



        /*public string CourseOwnerID { get; set; }
        public string CourseOwner { get; set; }*/
    }
}
