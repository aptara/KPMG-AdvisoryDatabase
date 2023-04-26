using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdvisoryDatabase.Framework.CustomException;
using AdvisoryDatabase.Framework.Logger;
namespace AdvisoryDatabase.Business.Controllers
{
    public class BaseController
    {

        protected string LogError(Exception ex)
        {
            var msbException = ex as MSBException;
            if (null != msbException)
            {
                MSBLogger.WriteError(msbException.Message, msbException);
                return msbException.Message;
            }
            string detailsMessageError;
            if (ex.InnerException != null)
            {
                detailsMessageError = ex.InnerException.Message + " " + ex.StackTrace;
            }
            else
            {
                detailsMessageError = ex.StackTrace;
            }
            MSBLogger.WriteError(detailsMessageError, ex);
            return detailsMessageError;

        }
    }
}