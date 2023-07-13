using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AdvisoryDatabase.Framework.Entities;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.IO;
using AdvisoryDatabase.Business;
using AdvisoryDatabase.Framework.Logger;
using System.Web.Http.Results;
using System.Web.Script.Serialization;
using System.Web.Http;


namespace AdvisoryDatabase.WebAPI.Controllers
{
    public class GetExcelForDeploymentReportController : ApiController
    {
        [System.Web.Http.HttpGet]
        public HttpResponseMessage ShowDataofdeployment()
     
        {
            try
            {
                AdvisoryDatabase.Framework.Logger.AdvisoryLogger.WriteInfo("ShowDataofdeployment Method Start");
                AdvisoryDatabase.Business.Controllers.GETExcelForDeploymentReportController DataForDeployment = new Business.Controllers.GETExcelForDeploymentReportController();
                ExcelforDeployment ObjInputParameters = new ExcelforDeployment();
                ObjInputParameters.LastUpdatedBy = 1;
                ObjInputParameters.IsActive = true;
                DataForDeployment.GetExcelForDeploymentReportDetails(ObjInputParameters);


                List<ExcelforDeployment> outputData = DataForDeployment.GetExcelForDeploymentReportDetails(ObjInputParameters);

                string jsonData = JsonConvert.SerializeObject(outputData);
                HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
                response.Content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                AdvisoryDatabase.Framework.Logger.AdvisoryLogger.WriteInfo("ShowDataofdeployment Method Record Count" + outputData.Count);
                return response;

            }
            catch (Exception ex)
            {
                AdvisoryDatabase.Framework.Logger.AdvisoryLogger.WriteError("ShowDataofdeployment Method end", ex.Message);
                HttpResponseMessage errorResponse = new HttpResponseMessage(HttpStatusCode.InternalServerError);
                errorResponse.Content = new StringContent("An error occurred: " + ex.Message, Encoding.UTF8, "text/plain");
                return errorResponse;

            };

        }
    }
}


