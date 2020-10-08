﻿/*************************************************************************
 * Author: DCoreyDuke
 * Logs Errors to ~/Logs/{Application}/Error.log
 ************************************************************************/

namespace FortyThreeLime.Logging
{
    using System;
    using System.Collections;
    using System.IO;
    using System.Text;

    public interface IErrorLogger : ILogger
    {
        void Log(Exception ex);
        void Log(HandleErrorInfo info);
        void Log(LogInfo info, Exception ex);
        void Log(LogInfo logInfo, HandleErrorInfo errorInfo);
    }

    public class HandleErrorInfo
    {
        public string ControllerName { get; set; }
        public string ActionName { get; set; }
        public Exception Exception { get; set; }

        public HandleErrorInfo()
        {

        }

        public HandleErrorInfo(Exception ex, string controllerName, string actionName)
        {
            this.Exception = ex;
            this.ControllerName = controllerName;
            this.ActionName = actionName;
        }

        public HandleErrorInfo(string controllerName, string actionName, string message)
        {
            this.Exception = new Exception(message);
            this.ControllerName = controllerName;
            this.ActionName = actionName;
        }
    }

    /// <summary>
    /// Logs Errors
    /// </summary>
    public class ErrorLogger : Logger, IErrorLogger
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ErrorLogger"/> class.
        /// </summary>
        public ErrorLogger() : base("Error.log")
        {
        }

        /// <summary>
        /// Override Base Log Method; Log The Message
        /// </summary>
        public override void Log(string message)
        {
            base.Log(message);
        }

        /// Override Base Log Method; Log The LogInfo Object
        /// </summary>
        public override void Log(ILogInfo info)
        {
            base.Log(info);
        }

        /// <summary>
        /// Log Handle Error Info
        /// </summary>
        public void Log(HandleErrorInfo info)
        {
            string errorLogRecordId = GetLogRecordId().ToString();
            string timestamp = Timestamp;
            string controller = info.ControllerName;
            string action = info.ActionName;
            string formattedException = FormatExceptionForLogging(info.Exception);

            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("| Error {0} | {1} | Controller: {2} | Action: {3} | Exception: {4} | End Error {0} |\n",
                errorLogRecordId,
                timestamp,
                controller,
                action,
                formattedException);

            using (StreamWriter writer = new StreamWriter(LogFilePath, true))
            {
                writer.WriteLine(CleanString(sb.ToString()));
            }
            return;
        }

        /// <summary>
        /// Log LogInfo and Handle Error Info
        /// </summary>
        public void Log(LogInfo logInfo, HandleErrorInfo errorInfo)
        {
            string errorLogRecordId = GetLogRecordId().ToString();
            string timestamp = Timestamp;

            string message = logInfo.Message;
            string data = FormatILogInfoData(logInfo.Data);

            string controller = errorInfo.ControllerName;
            string action = errorInfo.ActionName;
            string formattedException = FormatExceptionForLogging(errorInfo.Exception);

            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("| Error {0} | {1} | {Controller: {2}} | Action: {3}} | {Exception: {4}} | {Message: {5}} | Additional Data: {6}} | End Error {0} |\n",
                errorLogRecordId,
                timestamp,
                controller,
                action,
                formattedException,
                message,
                data);

            using (StreamWriter writer = new StreamWriter(LogFilePath, true))
            {
                writer.WriteLine(CleanString(sb.ToString()));
            }
            return;
        }

        /// <summary>
        /// Log Exception
        /// </summary>
        public void Log(Exception ex)
        {
            string errorLogRecordId = GetLogRecordId().ToString();
            string timestamp = Timestamp;
            string formattedException = FormatExceptionForLogging(ex);

            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("| Error {0} | {1} | {2} | End Error {0} |\n",
                errorLogRecordId,
                timestamp,
                formattedException);

            using (StreamWriter writer = new StreamWriter(LogFilePath, true))
            {
                writer.WriteLine(CleanString(sb.ToString()));
            }
            return;
        }

        /// <summary>
        /// Log LogInfo and Exception
        /// </summary>
        public void Log(LogInfo info, Exception ex)
        {
            string errorLogRecordId = GetLogRecordId().ToString();
            string timestamp = Timestamp;
            string formattedException = FormatExceptionForLogging(ex);

            string controller = info.ControllerName;
            string action = info.ActionName;
            string message = info.Message;
            string data = FormatILogInfoData(info.Data);

            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("| Error {0} | {1} | {Controller: {2}} {Action: {3}} | {Exception: {4}} | {Message: {5}} | Additional Data: {6}} | End Error {0} |\n",
                errorLogRecordId,
                timestamp,
                controller,
                action,
                formattedException,
                message,
                data);

            using (StreamWriter writer = new StreamWriter(LogFilePath, true))
            {
                writer.WriteLine(CleanString(sb.ToString()));
            }
            return;
        }

        /// <summary>
        /// Create HandleErrorInfo HandleErrorInfo
        /// </summary>
        public HandleErrorInfo CreateHandleErrorInfo(string controllerName, string actionName, Exception ex)
        {
            return new HandleErrorInfo(ex, controllerName, actionName);
        }
        /// <summary>
        /// Create HandleErrorInfo HandleErrorInfo
        /// </summary>
        public HandleErrorInfo CreateHandleErrorInfo(LogInfo info, Exception ex)
        {
            return new HandleErrorInfo(ex, info.ControllerName, info.ActionName);
        }

        #region Helpers

        /// <summary>
        /// Format Exception for Logging
        /// * Long Name to avoid conflict with FormatException, a Type of Exception
        /// </summary>
        private string FormatExceptionForLogging(Exception ex)
        {
            string data = FormatExceptionData(ex.Data);
            string hResult = ex.HResult.ToString().Trim();
            string innerException = ex.InnerException != null && string.IsNullOrEmpty(ex.InnerException.Message) ? ex.InnerException.Message.ToString() : string.Empty;
            string message = !string.IsNullOrEmpty(ex.Message) ? ex.Message.ToString() : string.Empty;
            string source = !string.IsNullOrEmpty(ex.Source) ? ex.Source.ToString() : string.Empty;
            string stackTrace = !string.IsNullOrEmpty(ex.StackTrace) ? ex.StackTrace.ToString() : string.Empty;
            string targetSite = ex.TargetSite != null && !string.IsNullOrEmpty(ex.TargetSite.ToString()) ? ex.TargetSite.ToString() : string.Empty;

            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("Data: {0}  | HResult: {1}  | InnerException: {2}  | Message : {3}  | Source: {4}  | Stack Trace: {5}  | Target Site: {6}",
                data,
                hResult,
                innerException,
                message,
                source,
                stackTrace,
                targetSite);

            return sb.ToString();
        }

        /// <summary>
        /// Format Exception Data into a Single Line
        /// </summary>
        private string FormatExceptionData(IDictionary data)
        {
            StringBuilder sb = new StringBuilder();

            foreach (DictionaryEntry d in data)
            {
                string key = d.Key.ToString();
                string value = d.Value.ToString();
                FormattableString valueString = $"| {{Header: {key} | Value: {value}}} |";
                sb.AppendFormat(valueString.ToString());
            }
            return sb.ToString();
        }

        #endregion
    }

}