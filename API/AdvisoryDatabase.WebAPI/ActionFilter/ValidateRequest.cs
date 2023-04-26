using System;
using System.Linq;
using System.Web.Http.Controllers;
using System.Web.Routing;
using System.Web.Http.Filters;
using System.Web;
using System.Configuration;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Text;
using AdvisoryDatabase.Business;
using System.Text.RegularExpressions;

namespace AdvisoryDatabase.WebAPI.ActionFilter
{
    public class ValidateRequest : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            string invalidInputParameterMessage = "Input parameters should not be null.";
            HttpRequestMessage request = new HttpRequestMessage();
            string outputData = string.Empty;
            string APIHashKey = string.Empty;

            //Read Controller Name
            string controllerName = actionContext.ControllerContext.Controller.GetType().Name;

            if (actionContext.ActionArguments["meterID"] != null)
            {
                //if (actionContext.ActionArguments["inputParam"].GetType() == typeof(GetXMLRecords))
                //{
                //    var ArgumentObj = (GetXMLRecords)actionContext.ActionArguments["inputParam"];

                //    if (ArgumentObj != null)
                //    {
                        
                //                string validationMessage = WKFS.DataAccess.DataAccessWindowService.DataAccessXmlRepositoryWindowsService.GetClientDetails(ArgumentObj, APIHashKey);
                //                if (!String.IsNullOrEmpty(validationMessage))
                //                {
                //                    outputData = ConvertErrorMessageInObject(controllerName, validationMessage);
                //                }
                            
                //    }
                //    else
                //    {
                //        outputData = "Request is not valid to generate the output"
                //    }
                //}
                //else
                //{
                //    outputData = "Request is not valid to generate the output";
                //}
            }
            else
            {
                outputData = "Request is not valid to generate the output";
            }


            if (!String.IsNullOrEmpty(outputData))
            {
                HttpResponseMessage response = new HttpResponseMessage()
                {
                    Content = new StringContent(outputData, Encoding.UTF8, "application/xml")
                };
                //HttpContext.Current.Response.Write(responce);
                actionContext.Response = response;
            }
            else
            {
                base.OnActionExecuting(actionContext);
            }
        }
    }
}