using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdvisoryDatabase.Framework.Common;

namespace AdvisoryDatabase.Framework.Entities
{
    public class ExcelForClarizen: BaseEntity<Int32>
    {

        public string CourseName { get; set; }

        public string LDIntakeOwner { get; set; }

        public string ProjectManagerContact { get; set; }

        public string BusinessSponsor { get; set; }
        public string InstructionalDesigner { get; set; }
        public string ProgramType { get; set; }
        public string DeliveryType { get; set; }

        public string TotalCPECredit { get; set; }
        public string CourseID { get; set; }
        public string FirstDeliveryDate { get; set; }
        public string LevelofEffort { get; set; }
        public string Duration { get; set; }
    }
}
