using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AdvisoryDatabase.Framework.Entities
{
    public class InfoModel
    {
        public List<info> infoData { get; set; }
    }
    public class info
    {
     /*   public string Name { get; set; }
        public string Appointment { get; set; }*/


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
