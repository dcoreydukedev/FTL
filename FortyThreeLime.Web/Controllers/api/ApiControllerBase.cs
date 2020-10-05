/*************************************************************************
 * Author: DCoreyDuke
 * Provides Common Controller Logging Functionality 
 ************************************************************************/

using System;
using System.Collections.Generic;
using System.Net.Http;
using FortyThreeLime.Logging;
using System.Web.Http;

namespace FortyThreeLime.Web.Controllers
{
    /// <summary>
    /// Base Class For Api Controllers, Provides Logging Functionality
    /// </summary>
    /// <seealso cref="System.Web.Http.ApiController" />
    public class ApiControllerBase : ApiController
    {
        /// <summary>
        /// Private Instance of Admin Logger
        /// </summary>
        private readonly AdminLogger _adminLogger;

        /// <summary>
        /// Private Instance of ErrorLogger
        /// </summary>
        private readonly ErrorLogger _errorLogger;

        /// <summary>
        /// Private Instance of ApiRequestLogger
        /// </summary>
        private readonly APIResponseLogger _apiLogger;

        /// <summary>
        /// Initializes a new instance of the <see cref="ApiControllerBase"/> class.
        /// </summary>
        public ApiControllerBase()
        {
            _adminLogger = new AdminLogger();
            _errorLogger = new ErrorLogger();
            _apiLogger = new APIResponseLogger();
        }

        /// <summary>
        /// Logs the API response.
        /// </summary>
        /// <param name="message">The message.</param>
        internal void LogApiResponse(HttpResponseMessage message)
        {
            _apiLogger.Log(message);
        }

        /// <summary>
        /// Logs the admin.
        /// </summary>
        /// <param name="controllerName">Name of the controller.</param>
        /// <param name="actionName">Name of the action.</param>
        /// <param name="message">The message.</param>
        internal void LogAdmin(string controllerName, string actionName, string message)
        {
            ILogInfo info = new LogInfo(controllerName, actionName, message, null);

            _adminLogger.Log(info);
        }

        /// <summary>
        /// Logs the admin.
        /// </summary>
        /// <param name="controllerName">Name of the controller.</param>
        /// <param name="actionName">Name of the action.</param>
        /// <param name="message">The message.</param>
        /// <param name="data">The data.</param>
        internal void LogAdmin(string controllerName, string actionName, string message, IDictionary<string, string> data)
        {
            ILogInfo info = new LogInfo(controllerName, actionName, message, data);

            _adminLogger.Log(info);
        }

        /// <summary>
        /// Logs the error.
        /// </summary>
        /// <param name="controllerName">Name of the controller.</param>
        /// <param name="actionName">Name of the action.</param>
        /// <param name="ex">The ex.</param>
        internal void LogError(string controllerName, string actionName, Exception ex)
        {
            HandleErrorInfo info = new HandleErrorInfo(ex, controllerName, actionName);
            _errorLogger.Log(info);
        }
    }

}
