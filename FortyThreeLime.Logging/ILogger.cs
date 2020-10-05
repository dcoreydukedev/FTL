/*************************************************************************
 * Author: DCoreyDuke
 ************************************************************************/

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace FortyThreeLime.Logging
{

    public interface ILogger
    {
        void Log(string message);
        void Log(ILogInfo info);
        string LogsDirectory { get; }
        string LogFile { get; }
        string LogFilePath { get; }
    }

    /// <summary>
    /// Abstract Implementation of ILogger
    /// </summary>
    public abstract class Logger : ILogger
    {
        public string Timestamp { get; }

        public string LogsDirectory { get; } = @"C:\Logs";

        public string LogFilePath { get; }

        public string LogFile { get; }

        public string LogName { get; }

        protected Logger(string logFile)
        {
            Timestamp = DateTime.Now.ToString("mm/dd/yyyy hh:mm:ss:ffff");
         
            LogFile = logFile;

            LogName = LogFile.Replace("Log.log", " ").Trim();

            if (Directory.Exists(this.LogsDirectory))
            {
                if (!string.IsNullOrEmpty(this.LogFile))
                {
                    this.LogFilePath = Path.Combine(LogsDirectory, LogFile);
                    if (!File.Exists(LogFilePath))
                    {
                        try
                        {
                            File.Create(LogFilePath);
                        }
                        catch (Exception ex)
                        {
                            throw ex;
                        }
                    }
                }
                else
                {
                    ArgumentException ex = new ArgumentException("Valid LogFile name must be provided!");
                    throw ex;
                }
            }
            else
            {
                try
                {
                    Directory.CreateDirectory(this.LogsDirectory);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        /// <summary>
        ///  Removes Unwanted Spaces, NewLines, and/or Other Characters
        /// </summary>
        /// <param name="rawString"></param>
        /// <returns></returns>
        public string CleanString(string rawString)
        {
            //if (string.IsNullOrEmpty(rawString))
            //{
            //    throw new ArgumentException("Raw String Value must be provided!");
            //}

            // Replace any White Space (i.e. Tabs, NewLines, etc 
            // Regualar Expression \s is equivalent to  [  \f\n\r\t\v]
            rawString = Regex.Replace(rawString, @"(\s)\s+", " ");

            return rawString.ToString().Trim();
        }

        /// <summary>
        /// Logs the Message
        /// </summary>
        public virtual void Log(string message)
        {
            string logRecordId = GetLogRecordId().ToString();
            string timestamp = Timestamp;

            FormattableString logInfoString = $@"| {{ Id: {CleanString(logRecordId)} }}
                                                 | {{ Timestamp: {CleanString(timestamp)} }}
                                                 | {{ Message: {CleanString(message)} }}";

            using (StreamWriter writer = new StreamWriter(LogFilePath))
            {
                writer.WriteLine(CleanString(logInfoString.ToString()));
            }
            return;
        }
        
        /// <summary>
        /// Logs ILogInfo LogInfo
        /// </summary>
        public virtual void Log(ILogInfo info)
        {
            string logRecordId = GetLogRecordId().ToString();
            string timestamp = Timestamp;
            FormattableString logInfoString = null;
            string data;
            
            data = FormatILogInfoData(info.Data);
            logInfoString = $@"| {{ Id: {CleanString(logRecordId)} }}
                            | {{ Timestamp: {CleanString(timestamp)} }}
                            | {{ Action: {CleanString(info.ActionName)} }} 
                            | {{ Controller: {CleanString(info.ActionName)} }}
                            | {{ Message: {CleanString(info.Message)} }}
                            | {{ Data: {CleanString(data)} }}";            

            using (StreamWriter writer = new StreamWriter(LogFilePath))
            {
                writer.WriteLine(CleanString(logInfoString.ToString()));
            }
            return;
        }

        /// <summary>
        /// Format ILogInfo.Data as String
        /// </summary>
        protected string FormatILogInfoData(IDictionary<string, string> data)
        {
            StringBuilder sb = new StringBuilder();
            if (data != null && data.Count > 0)
            {
                foreach (KeyValuePair<string, string> kvp in data)
                {
                    sb.AppendFormat("{0} | {1}", CleanString(kvp.Key), CleanString(kvp.Value));
                }
            }
            return CleanString(sb.ToString());
        }

        /// <summary>
        /// Get the Records From The Log File
        /// </summary>
        protected List<string> GetLogRecords()
        {
            return File.ReadLines(LogFilePath).ToList();
        }

        /// <summary>
        /// Get Log Record Id By Counting Lines and Adding 1
        /// </summary>
        protected int GetLogRecordId()
        {
            List<string> l = GetLogRecords();
            int count = l.Count;
            l = null; // Cleanup Resource 
            return count + 1;
        }

        /// <summary>
        /// Delete Log File and Create New One
        /// </summary>
        protected void ClearLog()
        {
            if(File.Exists(LogFilePath))
            {
                File.Delete(LogFilePath);
            }
            File.Create(LogFilePath);
            return;
        }
    }
}