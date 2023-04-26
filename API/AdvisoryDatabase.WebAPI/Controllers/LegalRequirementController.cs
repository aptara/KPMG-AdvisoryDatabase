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
using WKFS.DataAccess.Common;
using WKFS.FrameWork.ClientAPI;
using WKFS.FrameWork.Entites;
using WKFS.FrameWork.Logger;
using WKFS.WebAPI.ActionFilter;
using WKFS.DataAccess.DataAccessService;
using WKFS.FrameWork.EntitesWindowService;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using WKFS.FrameWork.Common;
using WKFS.DataAccess.DataAccessWindowService;
using System.Text.RegularExpressions;


namespace WKFS.WebAPI.Controllers
{
     [ToCheckUserCanProcessData]
    public class LegalRequirementController : ApiController
    {
        [HttpPost]
        public HttpResponseMessage LegalRequirementJsonData(JObject jsonResult)
        {

            var errorDetails = string.Empty;
            string errorMessage = string.Empty;
            WKFS.Business.Controllers.XSDValidationController serializeData = new Business.Controllers.XSDValidationController();
            try
            {
                //LegalRequirementRegLibUpdateRecord ProvisioMasterObject = JsonConvert.DeserializeObject<LegalRequirementRegLibUpdateRecord>(jsonResult.ToString());
                LegalRequirementJsonData ProvisioMasterObject = JsonConvert.DeserializeObject<LegalRequirementJsonData>(jsonResult.ToString());
                if (ProvisioMasterObject == null || ProvisioMasterObject.legalRequirements == null)
                {
                    errorMessage = serializeData.SerializeLegalRequirementErrorData("Please ensure that Citation ID and Legal Requirement record exists in the input json data.");
                }
                else
                {
                    var citationID = ProvisioMasterObject.CitationID;
                    if (!String.IsNullOrEmpty(ProvisioMasterObject.CitationID))
                    {

                        Logger.Info("Legal Requirement Input. Controller: LegalRequirementController. Action: Post. Start Time: " + DateTime.Now.ToString());
                        Common legRequirementCommon = new Common();
                        //string ProvisioXMLString = Utility.Serialize<LegalRequirementRegLibUpdateRecord>(ProvisioMasterObject);
                        string ProvisioXMLString = Utility.Serialize<LegalRequirementJsonData>(ProvisioMasterObject);
                        string processedXMLRecordOutput = DataAccessLegalRequirementService.AddLegalRequirementLog(ProvisioXMLString);

                        if (processedXMLRecordOutput.ToLower() == "SUCCESS".ToLower()) //SUCCESS
                        {
                            errorMessage = serializeData.SerializeLegalRequirementErrorData("Record saved successfully.");  //success given as xml in message property
                            return new HttpResponseMessage()
                            {
                                Content = new StringContent(errorMessage, System.Text.Encoding.UTF8, "application/xml")
                            };                           
                        }
                        else
                        {
                            //errorMessage = serializeData.SerializeLegalRequirementErrorData(null, null, processedXMLRecordOutput);    //need to change this as per result from sql
                            errorMessage = serializeData.SerializeLegalRequirementErrorData(processedXMLRecordOutput);
                        }
                    }
                    else
                    {
                        errorMessage = serializeData.SerializeLegalRequirementErrorData("Invalid Citation ID");
                        //errorMessage = serializeData.SerializeLegalRequirementErrorData(ProvisioMasterObject.CitationID, null, "Invalid Citation ID");
                    }

                }
            }
            catch (Exception ex)
            {
                errorMessage = serializeData.SerializeLegalRequirementErrorData(ex.Message.ToString());
                return new HttpResponseMessage()
                {
                    Content = new StringContent(errorMessage, System.Text.Encoding.UTF8, "application/xml")
                };
            }

            return new HttpResponseMessage()
            {
                Content = new StringContent(errorMessage, System.Text.Encoding.UTF8, "application/xml")
            };


        }

        [HttpPost]
        public HttpResponseMessage Post(GetXMLRecords inputParam)
        {

            WKFS.Business.Controllers.XSDValidationController serializeErrorData = new Business.Controllers.XSDValidationController();

            try
            {
                Common common = new Common();
                string outputData = string.Empty;
                XMLOutputInputData XMLOutputInputDataParam = new XMLOutputInputData();
                if (inputParam == null)
                {
                    outputData = serializeErrorData.SerializeLegalRequirementErrorData("Input parameters should not be null.");
                }
                else if (!Regex.IsMatch(inputParam.ClientCode, @"^\d+$"))
                {
                    string ClientCodeFromat = "Invalid client code.";
                    outputData = serializeErrorData.SerializeLegalRequirementErrorData(ClientCodeFromat);
                }
                else
                {
                    if (!String.IsNullOrEmpty(inputParam.OutputType) && inputParam.OutputType.ToUpper() == "EXCEL" && (inputParam.RegulatorIds == null || inputParam.UserEmail == null))
                    {
                        outputData = serializeErrorData.SerializeLegalRequirementErrorData("You have requested for Excel output so in the input parameter Regulator ID/User Email  should not be null.");
                    }
                    else
                    {
                        if (!String.IsNullOrEmpty(inputParam.FromDate) || !String.IsNullOrEmpty(inputParam.FromTime) || !String.IsNullOrEmpty(inputParam.ToDate))
                        {
                            outputData = serializeErrorData.SerializeRegLibraryErrorData("Invalid Argument Parameters: FromDate, FromTime, ToDate.");
                        }
                        else
                        {
                            inputParam.ISRegChange = "False";
                            inputParam.IsRequestForRiskAndControl = "False";
                            inputParam.OutPutTypeId = "4";
                            XMLOutputInputDataParam = common.ReadRequestParameters(inputParam);
                            XMLOutputInputDataParam.Comment = "Request From Legal Requirement output API. ClientIP Address is :- " + HttpContext.Current.Request.UserHostAddress.ToString();
                            int ProcessId = common.SaveRequestInDatabase(XMLOutputInputDataParam);
                            if (ProcessId == 0)
                            {
                                outputData = serializeErrorData.SerializeLegalRequirementErrorData("Request is not saved in the database. Please contact to Administrator.");
                            }
                            else
                            {
                                XMLOutputInputDataParam.Id = ProcessId;

                                if (String.IsNullOrEmpty(inputParam.UserEmail))
                                {
                                    WKFS.Business.Controllers.WKFSProcessServiceController ObjWKFSProcessService = new WKFS.Business.Controllers.WKFSProcessServiceController();
                                    XmlOutPut xmlOutPut = ObjWKFSProcessService.PostXmlOutputForLegalRequirement(XMLOutputInputDataParam);

                                    if (xmlOutPut.IsRecordNotFound == "True")
                                    {
                                        if (xmlOutPut.IsSubscriptionExpired.ToUpper() == "TRUE")
                                        {
                                            outputData = xmlOutPut.XmlString.ToString();
                                        }
                                        else
                                        {
                                            outputData = serializeErrorData.SerializeLegalRequirementErrorData(xmlOutPut.XmlString.ToString());
                                        }
                                    }
                                    else
                                    {
                                        if (xmlOutPut.IsError == "False")
                                        {
                                            if (XMLOutputInputDataParam.OutputType.ToUpper() == "XML")
                                            {
                                                XmlDocument XDoc = new XmlDocument();
                                                XDoc.Load(xmlOutPut.FileName);
                                                outputData = XDoc.InnerXml.ToString();
                                            }
                                            else if (XMLOutputInputDataParam.OutputType.ToUpper() == "EXCEL")
                                            {
                                                outputData = "Your requested output is generated successfully. Output file name is " + xmlOutPut.FileName + " path. You will receive an email shortly on " + inputParam.UserEmail + " email ID to download the file.";
                                                outputData = serializeErrorData.SerializeLegalRequirementErrorData(outputData);
                                            }

                                        }
                                        else
                                        {
                                            outputData = serializeErrorData.SerializeLegalRequirementErrorData(xmlOutPut.ErrorMessage.ToString());
                                        }
                                    }
                                }
                                else
                                {
                                    outputData = "Your output request is saved successfully. You will receive an email shortly on " + inputParam.UserEmail + " email ID to download the file. Request ID is :- " + XMLOutputInputDataParam.Id;
                                    outputData = serializeErrorData.SerializeLegalRequirementErrorData(outputData);
                                }
                            }

                        }
                    }
                }
                return new HttpResponseMessage()
                {
                    Content = new StringContent(outputData, Encoding.UTF8, "application/xml")
                };
            }
            catch (Exception ex)
            {
                string errorMessage = serializeErrorData.SerializeRegLibraryErrorData(ex.Message.ToString());
                return new HttpResponseMessage()
                {
                    Content = new StringContent(errorMessage, Encoding.UTF8, "application/xml")
                };
            }


        }

    }
}