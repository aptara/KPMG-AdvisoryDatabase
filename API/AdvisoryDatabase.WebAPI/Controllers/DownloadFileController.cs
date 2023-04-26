using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Http;
using System.Xml.Serialization;
using WKFS.DataAccess.Common;
//using WKFS.FrameWork.ClientAPI;
//using WKFS.WebAPI.Models;
//using WKFS.WebAPI.XMLRepository;
using WKFS.FrameWork.Logger;
using System.Xml;
using WKFS.DataAccess.DataAccessWindowService;
using WKFS.FrameWork.Entites;
using System.Configuration;
using WKFS.WebAPI.ActionFilter;
using WKFS.FrameWork.EntitesWindowService;

namespace WKFS.WebAPI.Controllers
{
    public class DownloadFileController : ApiController
    {

        [HttpGet]
        public HttpResponseMessage DownloadOutputFile(string InputFileName)
        {
            try
            {
                string FolderPath = ConfigurationManager.AppSettings["WKFSOutputFilePath"].ToString();
                Logger.Info("WKFS WebAPI DownloadFileController - DownloadOutputFile :-  FolderPath while download " + FolderPath);
                string filePath = Path.Combine(FolderPath, InputFileName);
                DownloadUrl(filePath, InputFileName);
                return new HttpResponseMessage() { };
            }
            catch (Exception ex)
            {
                Logger.Info(" Exception " + ex.Message);
                return new HttpResponseMessage() { };
            }
        }
        [HttpGet]
        public HttpResponseMessage DownloadImportFile(string InputFileName)
        {
            try
            {
                string FolderPath = ConfigurationManager.AppSettings["ImportRegLibraryFilePath"].ToString();
                Logger.Info("WKFS WebAPI DownloadFileController - DownloadImportFile:-  FolderPath while download " + FolderPath);
                string filePath = Path.Combine(FolderPath, InputFileName);
                DownloadUrl(filePath, InputFileName);
                return new HttpResponseMessage() { };
            }
            catch (Exception ex)
            {
                Logger.Info(" Exception " + ex.Message);
                return new HttpResponseMessage() { };
            }
        }
       

        private static void DownloadUrl(string filePath, string InputFileName)
        {
            try
            {
                if (File.Exists(filePath))
                {
                    //Logger.Info("WKFS WebAPI DownloadFileController :- File found successfully.");
                    //Logger.Info("Download file: " + InputFileName);
                    //System.IO.FileStream fs = null;
                    //fs = System.IO.File.Open(filePath, System.IO.FileMode.Open);
                    //byte[] btFile = new byte[fs.Length];
                    //fs.Read(btFile, 0, Convert.ToInt32(fs.Length));
                    //fs.Close();
                    //HttpResponse response = HttpContext.Current.Response;
                    //response.Clear();
                    //response.ClearContent();
                    //response.ClearHeaders();
                    //response.Buffer = true;
                    //response.BufferOutput = false;
                    //response.AddHeader("Content-disposition", "attachment; filename=" + InputFileName);
                    //response.ContentType = "application/octet-stream";
                    //Logger.Info("WKFS WebAPI DownloadFileController :- Binary Writter is in progress " + InputFileName);
                    //response.BinaryWrite(btFile);
                    //Logger.Info("WKFS WebAPI DownloadFileController :- File successfully Write by Binary Writter. " + InputFileName);
                    //response.End();
                    //Logger.Info("WKFS WebAPI DownloadFileController :- File Download successfully. " + InputFileName);





                    Logger.Info("WKFS WebAPI DownloadFileController :- File found successfully.");
                    Logger.Info("Download file: " + InputFileName);
                    Stream stream = null;

                    //foreach (var line in File.ReadLines(filePath))
                    //{
                    //    //_lines.Add(line);
                    //}

                    // read buffer in 1 MB chunks
                    // change this if you want a different buffer size
                    int bufferSize = 1048576;

                    byte[] buffer = new Byte[bufferSize];
                    HttpResponse response = HttpContext.Current.Response;
                    // buffer read length
                    int length;
                    // Total length of file
                    long lengthToRead;

                    try
                    {
                        // Open the file in read only mode 
                        stream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read);

                        // Total length of file
                        lengthToRead = stream.Length;
                        response.ContentType = "application/octet-stream";
                        response.AddHeader("Content-Disposition", "attachment; filename=" + HttpUtility.UrlEncode(InputFileName, System.Text.Encoding.UTF8));

                        Logger.Info("WKFS WebAPI DownloadFileController :- Binary Writter is in progress " + InputFileName);
                        while (lengthToRead > 0)
                        {
                            // Verify that the client is connected.
                            if (response.IsClientConnected)
                            {
                                // Read the data in buffer
                                length = stream.Read(buffer, 0, bufferSize);

                                // Write the data to output stream.
                                response.OutputStream.Write(buffer, 0, length);

                                // Flush the data 
                                response.Flush();

                                //buffer = new Byte[10000];
                                lengthToRead -= length;
                            }
                            else
                            {
                                // if user disconnects stop the loop
                                lengthToRead = -1;
                            }
                        }
                        Logger.Info("WKFS WebAPI DownloadFileController :- File successfully Write by Binary Writter. " + InputFileName);
                    }
                    catch (Exception exp)
                    {
                        // handle exception
                        response.ContentType = "text/html";
                        response.Write("Error : " + exp.Message);
                    }
                    finally
                    {
                        if (stream != null)
                        {
                            stream.Close();
                        }
                        response.End();
                        response.Close();
                        Logger.Info("WKFS WebAPI DownloadFileController :- File Downloaded successfully. " + InputFileName);
                    }

                }
                else
                {
                    Logger.Info("WKFS WebAPI DownloadFileController :-  File not found. " + InputFileName);
                }
            }
            catch (Exception ex)
            {
                Log4NetLogger.Error("DownloadUrl:- Exception Block: DownloadUrl." + InputFileName);
                Log4NetLogger.Error("DownloadUrl:- " + ex.Message, ex);
            }
        }

    }
}