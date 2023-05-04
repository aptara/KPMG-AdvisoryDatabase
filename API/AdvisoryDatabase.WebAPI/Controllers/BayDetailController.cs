using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Http;
using System.Xml;
using System.Xml.Serialization;
using AdvisoryDatabase.Framework.Entities;
using AdvisoryDatabase.Business;
using AdvisoryDatabase.Framework.Logger;
using Newtonsoft.Json;
//using AdvisoryDatabase.WebAPI.ActionFilter;



namespace AdvisoryDatabase.WebAPI.Controllers
{

  public class BayDetailsController : ApiController
  {

    // http://localhost:62220//api/BayDetails/GetBayData
    //        {
    //"BayID": "22",
    //"SubStationID":"11",
    //"Name":"Test Name",
    //"Description":"Test Description"
    //}
    [HttpPost]
    /*  public HttpResponseMessage GetBayData(BayDetails ObjInputParameters)*/
    public HttpResponseMessage GetBayData()
    {
      try
      {
        AdvisoryDatabase.Business.Controllers.BayDetailController ObjBayDetai = new Business.Controllers.BayDetailController();
        BayDetails ObjInputParameters = new BayDetails();
        ObjInputParameters.LastUpdatedBy = 1;
        ObjInputParameters.IsActive = true;
        ObjBayDetai.GetBayDetails(ObjInputParameters);

        string outputData = string.Empty;

        return new HttpResponseMessage()
        {
          Content = new StringContent(outputData, Encoding.UTF8, "application/xml")
        };
      }
      catch (Exception ex)
      {
        string errorMessage = (ex.Message.ToString());
        return new HttpResponseMessage()
        {
          Content = new StringContent(errorMessage, Encoding.UTF8, "application/xml")
        };
      }
    }

    [HttpGet]
    public HttpResponseMessage ShowData() {

      try
      {
        AdvisoryDatabase.Business.Controllers.BayDetailController ObjBayDetai = new Business.Controllers.BayDetailController();
        BayDetails ObjInputParameters = new BayDetails();
        ObjInputParameters.LastUpdatedBy = 1;
        ObjInputParameters.IsActive = true;
        ObjBayDetai.GetBayDetails(ObjInputParameters);

        List<BayDetails> outputData = ObjBayDetai.GetBayDetails(ObjInputParameters);
        

        string jsonData = JsonConvert.SerializeObject(outputData);
        HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
        response.Content = new StringContent(jsonData, Encoding.UTF8, "application/json");
        return response;


      }
      catch (Exception ex)
      {
        HttpResponseMessage errorResponse = new HttpResponseMessage(HttpStatusCode.InternalServerError);
        errorResponse.Content = new StringContent("An error occurred: " + ex.Message, Encoding.UTF8, "text/plain");
        return errorResponse;
      };
    }
  


    






    }
}
