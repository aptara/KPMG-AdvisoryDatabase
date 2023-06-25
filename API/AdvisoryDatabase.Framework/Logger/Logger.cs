using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvisoryDatabase.Framework.Logger
{
    using Microsoft.Practices.EnterpriseLibrary.Data;
    using Microsoft.Practices.EnterpriseLibrary.Logging;
    using System.Configuration;
    using System.Diagnostics;
    using System.Runtime.CompilerServices;

    public static class AdvisoryLogger
    {
        private static bool LogAudit
        {

            get
            {
                return !string.IsNullOrWhiteSpace(ConfigurationManager.AppSettings["LogAudit"]) &&
                       ConfigurationManager.AppSettings["LogAudit"].Equals("yes",
                           StringComparison.CurrentCultureIgnoreCase);

            }
        }

        private static bool Log4NetAudit
        {

            get
            {
                return !string.IsNullOrWhiteSpace(ConfigurationManager.AppSettings["Log4NetAudit"]) &&
                       ConfigurationManager.AppSettings["Log4NetAudit"].Equals("yes",
                           StringComparison.CurrentCultureIgnoreCase);

            }
        }


        static AdvisoryLogger()
        {
            DatabaseFactory.SetDatabaseProviderFactory(new DatabaseProviderFactory());
            Logger.SetLogWriter(new LogWriterFactory().Create());
            //var path = System.Web.HttpContext.Current.Server.MapPath("~/App.config");
            //Log4NetLogger.Init(path);

            //Log4NetLogger.Info("-------------------------------------------------------");
            //Log4NetLogger.Info("********* Initializing Application... *********");
            //DatabaseProviderFactory factory = new DatabaseProviderFactory();
            //Database db = factory.Create("ConnectionString");
        }

        public static void WriteError(
            string message,
            [CallerMemberName] string memberName = "",
            [CallerFilePath] string sourceFilePath = "",
            [CallerLineNumber] int sourceLineNumber = 0)
        {
            try
            {
                //Logger.SetLogWriter(new LogWriterFactory().Create());
                var entry = new LogEntry
                {
                    Title =
                        string.Format(
                            "Function Name: {0}, Class/File Name: {1}, Line number{2}",
                            memberName,
                            sourceFilePath,
                            sourceLineNumber),
                    Message = string.Format("Error Message: {0}", message),
                    Severity = TraceEventType.Error
                };
                //Logger.Write(entry);
                if (Log4NetAudit)
                {
                    Log4NetLogger.Error(string.Format("Error message : {0}", message));
                }
            }
            catch (Exception)
            {

            }
        }

        public static void WriteError(
            string message,
            Exception ex,
            [CallerMemberName] string memberName = "",
            [CallerFilePath] string sourceFilePath = "",
            [CallerLineNumber] int sourceLineNumber = 0)
        {
            try
            {

                var entry = new LogEntry
                {
                    Title =
                        string.Format(
                            "Function Name: {0}, Class/File Name: {1}, Line number{2}",
                            memberName,
                            sourceFilePath,
                            sourceLineNumber),
                    Message =
                        string.Format(
                            "Error Message: {0}, Exception : {1}, StackTrace: {2}, Inner exception {3}",
                            message,
                            ex.Message,
                            ex.StackTrace,
                            ex.InnerException == null
                                ? string.Empty
                                : ex.InnerException.Message),
                    Severity = TraceEventType.Error
                };
                //Logger.Write(entry);
                if (Log4NetAudit)
                {
                    Log4NetLogger.Error(
                        string.Format("Web-server Name:{0}, Error message : {1}", entry.MachineName, message), ex);
                }
            }
            catch (Exception)
            {

            }

        }

        public static void WriteErrorWithoutTitle(string message, Exception ex)
        {
            try
            {
                //Logger.SetLogWriter(new LogWriterFactory().Create());
                var entry = new LogEntry
                {
                    Message =
                        string.Format(
                            "Error Message: {0}, Exception : {1}, StackTrace: {2}, Inner exception {3}",
                            message,
                            ex.Message,
                            ex.StackTrace,
                            ex.InnerException == null ? string.Empty : ex.InnerException.Message),
                    Severity = TraceEventType.Error
                };
                //Logger.Write(entry);
                if (Log4NetAudit)
                {
                    Log4NetLogger.Error(
                        string.Format("Web-server Name:{0}, Error message : {1}", entry.MachineName, message), ex);
                }
            }
            catch (Exception)
            {

            }
        }

        public static void WriteInfo(
            string message,
            [CallerMemberName] string memberName = "",
            [CallerFilePath] string sourceFilePath = "",
            [CallerLineNumber] int sourceLineNumber = 0)
        {
            try
            {
                //Logger.SetLogWriter(new LogWriterFactory().Create());
                var entry = new LogEntry
                {
                    Message = message,
                    Title =
                        string.Format(
                            "Function Name: {0}, Class/File Name: {1}, Line number{2}",
                            memberName,
                            sourceFilePath,
                            sourceLineNumber),
                    Severity = TraceEventType.Information
                };
                //if (LogAudit)
                //{
                //    Logger.Write(entry);
                //}
                if (Log4NetAudit)
                {
                    Log4NetLogger.Info(string.Format("Web-server Name:{0}, Info: {1}", entry.MachineName, message));
                }
            }
            catch
            {


            }
        }


        public static void CustomizedWriteInfo(string message, [CallerMemberName] string memberName = "",
                                                                [CallerFilePath] string sourceFilePath = "",
                                                                [CallerLineNumber] int sourceLineNumber = 0)
        {
            try
            {
                //Logger.SetLogWriter(new LogWriterFactory().Create());
                var entry = new LogEntry
                {
                    Message = message,
                    Title =
                        string.Format(
                            "Function Name: {0}, Class/File Name: {1}, Line number{2}",
                            memberName,
                            sourceFilePath,
                            sourceLineNumber),
                    Severity = TraceEventType.Information
                };
                if (LogAudit)
                {
                    Logger.Write(entry);
                }
                if (Log4NetAudit)
                {
                    Log4NetLogger.Info(string.Format("Web-server Name:{0}, Info: {1}", entry.MachineName, message));
                }
            }
            catch
            {


            }
        }
    }
}
