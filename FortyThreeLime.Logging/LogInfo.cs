/*************************************************************************
 * Author: DCoreyDuke
 * Encapsulates Information Passed to Logger from Controller or Calling Class
 ************************************************************************/

namespace FortyThreeLime.Logging
{
    using System.Collections.Generic;

    public interface ILogInfo
    {
        string ActionName { get; set; }
        string ControllerName { get; set; }
        IDictionary<string, string> Data { get; set; }
        string Message { get; set; }
    }

    /// <summary>
    /// Encapsulates Information Passed to Logger from Controller or Calling Class
    /// </summary>
    public class LogInfo : ILogInfo
    {
        public string ControllerName { get; set; }
        public string ActionName { get; set; }
        public string Message { get; set; }
        public IDictionary<string, string> Data { get; set; }

        public LogInfo()
        {

        }

        public LogInfo(string controllerName, string actionName) : this(controllerName, actionName, string.Empty, null)
        {

        }

        public LogInfo(string controllerName, string actionName, string message) : this(controllerName, actionName, message, null)
        {
        }

        public LogInfo(string controllerName, string actionName, string message, IDictionary<string, string> data) : this()
        {
            this.ControllerName = controllerName;
            this.ActionName = actionName;
            this.Message = message;
            this.Data = data;
        }
    }   
}