/*************************************************************************
 * Author: DCoreyDuke
 * Logs API CAlls to ~/Logs/ApiRequestLog.log
 ************************************************************************/

namespace FortyThreeLime.Logging
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Text;
    using System.Linq;

    public interface IAPIResponseLogger : ILogger
    {
        void Log(HttpResponseMessage msg);
    }

    /// <summary>
    /// Log API Responses; Keeps Track of Api Calls and Answers
    /// </summary>
    public class APIResponseLogger : Logger, IAPIResponseLogger
    {

        public APIResponseLogger() : base("ApiRequestLog.log")
        {
        }

        /// <summary>
        /// Override Base Log Method; Log The Message
        /// </summary>
        public override void Log(string message)
        {
            base.Log(message);
        }

        // <summary>
        /// Override Base Log Method; Log The LogInfo Object
        /// </summary>
        public override void Log(ILogInfo info)
        {
            base.Log(info);
        }

        /// <summary>
        /// Log the HttpResponseMessage; Preferred MEthod for this Logger
        /// </summary>
        public void Log(HttpResponseMessage message)
        {
            HttpRequestMessage request = message.RequestMessage;

            StringBuilder sb = new StringBuilder();

            string apiLogRecordId = GetLogRecordId().ToString();
            string timestamp = Timestamp;
            string content = FormatHeaders(message.Content.Headers);
            string headers = FormatHeaders(message.Headers);
            bool isSuccessStatusCode = message.IsSuccessStatusCode;
            string reasonPhrase = message.ReasonPhrase.ToString();
            string requestContent = FormatHeaders(request.Content.Headers);
            string requestHeaders = FormatHeaders(request.Headers);
            string requestMethod = request.Method.ToString();
            string requestProperties = FormatProperties(request.Properties);
            string requestRequestUri = request.RequestUri.ToString();
            string requestVersion = request.Version.ToString();
            string statusCode = message.StatusCode.ToString();
            string version = message.Version.ToString();       

            sb.AppendFormat("| API Response {0} | {1} | {Content: {2}} | {Headers: {3}} | IsSccessStatusCode: {4} | ReasonPhrase: {5} " +
                "| {Request: {Content: {6}} | {Headers: {7}} | {Method: {8}} | {Properties: {9}} | {RequestUri: {10}} | {Version: {11}}}" +
                "| {StatusCode: {12}} | {Version: {13}} | End API Response {0} |\n", 
                apiLogRecordId, 
                timestamp, 
                content, 
                headers, 
                isSuccessStatusCode,
                reasonPhrase, 
                requestContent, 
                requestHeaders, 
                requestMethod, 
                requestProperties, 
                requestRequestUri, 
                requestVersion, 
                statusCode, 
                version);

            using (StreamWriter writer = new StreamWriter(LogFilePath))
            {
                writer.Write(sb.ToString());
            }
        }

        #region Helpers

        /// <summary>
        /// Format Headers into a Single Line
        /// </summary>
        private string FormatHeaders(HttpHeaders headers)
        {
            StringBuilder sb = new StringBuilder();
           
            var headerList = headers.ToList();
            foreach(KeyValuePair<string, IEnumerable<string>> h in headerList)
            {
                StringBuilder sb2 = new StringBuilder();
                string key = CleanString(h.Key);
                foreach(string v in h.Value)
                {
                    sb2.AppendFormat("{0};", v);
                }
                string values = CleanString(sb2.ToString().Trim());
                sb.AppendFormat("{Header: {0} | Value: {1}}", key, values);
            }
            return sb.ToString().Trim();
        }

        /// <summary>
        /// Format Properties into a Single Line
        /// </summary>
        private string FormatProperties(IDictionary<string, object> properties)
        {
            StringBuilder sb = new StringBuilder();
            
            foreach (KeyValuePair<string, object> h in properties)
            {               
                string key = CleanString(h.Key);
                string value = CleanString(h.Value.ToString());
                sb.AppendFormat("{Property: {0} | Value: {1}}", key, value);
            }
            return sb.ToString().Trim();
        }

        #endregion
    }

   

    
}