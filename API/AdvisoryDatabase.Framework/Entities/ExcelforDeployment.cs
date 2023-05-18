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
        /*  public string CourseOwnerID { get; set; }
          public string CourseOwner { get; set; }*/



       public string CourseName { get; set; }
       public string LDIntakeOwner { get; set; }
       public string ProjectManagerContact { get; set; }
         
       public string BusinessSponsor { get; set; }
       public string InstructionalDesigner { get; set; }
       public string TotalCPECredit { get; set; }
        
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
       public string Duration { get; set; }
       public string Collateral { get; set; }


    }
}

