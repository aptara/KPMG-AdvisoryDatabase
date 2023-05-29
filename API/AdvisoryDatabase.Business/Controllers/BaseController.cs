using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdvisoryDatabase.Framework.Common;
using AdvisoryDatabase.Framework.CustomException;
using AdvisoryDatabase.Framework.Logger;
using AdvisoryDatabase.Framework.Response;

namespace AdvisoryDatabase.Business.Controllers
{
    public class BaseController
    {
        protected APIResponse<T> SuccessReponse<T>(T data, string error = "")
        {
            return new APIResponse<T>
            {
                Success = true,
                ErrorMessage = error,
                Data = data,
                Count = 0,
            };
        }

        protected APIResponse<T> Erroresponse<T>(string error)
        {
            return new APIResponse<T>
            {
                Success = false,
                ErrorMessage = error,
                Data = default(T)
            };
        }
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

        public APIResponse<ErrorResponse> ErrorResponse(List<string> errors = null, string internalError = "", string message = "")
        {
            var errorRes = new ErrorResponse();
            try
            {
                if (null != errors)
                {
                    errorRes.Errors.AddRange(errors);
                }
                errorRes.InternalError = internalError;

            }
            catch (Exception ex)
            {
                string detailsMessageError;
                if (ex.InnerException != null)
                    detailsMessageError = ex.InnerException.Message + " " + ex.StackTrace;
                else
                {
                    detailsMessageError = ex.StackTrace;
                }
                Log4NetLogger.Error(detailsMessageError, ex);
            }
            return new APIResponse<ErrorResponse> { Data = errorRes, ErrorMessage = string.IsNullOrEmpty(message) ? "Internal server error" : message, Success = true };
        }
    }
}