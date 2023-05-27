using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AdvisoryDatabase.Framework.Entities;
using AdvisoryDatabase.Framework.Logger;
using AdvisoryDatabase.Business.Service;


namespace AdvisoryDatabase.Business.Controllers
{
     public class ProgramTypeMasterController : BaseController
    {

        public List<ProgramTypeMaster> GetAllProgramType()
        {
            List<ProgramTypeMaster> programTypeMaster = new List<ProgramTypeMaster>();
            try
            {
                ProgramTypeMasterService service = new ProgramTypeMasterService();
                programTypeMaster = service.GetAll();

            }
            catch (Exception ex)
            {

                Log4NetLogger.Error(ex.Message);
            }

            return programTypeMaster;
        }
    }
}



