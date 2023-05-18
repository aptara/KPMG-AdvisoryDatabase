using AdvisoryDatabase.Framework.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AdvisoryDatabase.Framework.Entities
{
  [Serializable]
  public class Task : BaseEntity<Int32>
  {
    public string TaskMasterID { get; set; } 
    public string TaskMasterName { get; set; }
  }

  [Serializable]
  public class LocationDetail : BaseEntity<Int32>
  {
    public string LocationID { get; set; }
    public string Location { get; set; }

  }
}
