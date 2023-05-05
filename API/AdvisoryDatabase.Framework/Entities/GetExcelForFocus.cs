using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdvisoryDatabase.Framework.Common;

namespace AdvisoryDatabase.Framework.Entities
{
    public class GetExcelForFocusInfo: BaseEntity<Int32>
    {
        public string CourseName { get; set; }
        public string CourseOwner { get; set; }
        public string DeliveryType { get; set; }
        public string TotalCPECredit { get; set; }
        public string CourseID { get; set; }
        public string Overview { get; set; }
        public string Objectives { get; set; }
        public string MaximumAttendeeCount { get; set; }
        public string MinimumAttendeeCount { get; set; }
        public string PrerequisiteCourseID { get; set; }
        public string EquivalentCourseID { get; set; }
        public string FirstDeliveryDate { get; set; }

        public string LevelofEffort { get; set; }
        public string Vendor { get; set; }
        public string ProjectStatusID { get; set; }
        public string Duration { get; set; }
    }
}

