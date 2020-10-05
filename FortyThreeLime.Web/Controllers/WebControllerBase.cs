/*************************************************************************
 * Author: DCoreyDuke
 * Provides Common Controller Logging Functionality
 ************************************************************************/

using FortyThreeLime.Logging;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace FortyThreeLime.Web.Controllers
{

    [FortyThreeLimeErrorHandler]
    public class WebControllerBase : Controller
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
        /// Private Instance of UserLogger
        /// </summary>
        private readonly UserLogger _userLogger;

        public WebControllerBase()
        {
            _adminLogger = new AdminLogger();
            _errorLogger = new ErrorLogger();
            _userLogger = new UserLogger();
        }

        internal void LogAdmin(string controllerName, string actionName, string message)
        {
            ILogInfo info = new LogInfo(controllerName, actionName, message, null);

            _adminLogger.Log(info);
        }

        internal void LogAdmin(string controllerName, string actionName, string message, IDictionary<string, string> data)
        {
            ILogInfo info = new LogInfo(controllerName, actionName, message, data);

            _adminLogger.Log(info);
        }

        internal void LogUser(string controllerName, string actionName, string message)
        {
            ILogInfo info = new LogInfo(controllerName, actionName, message, null);

            _userLogger.Log(info);
        }

        internal void LogUser(string controllerName, string actionName, string message, IDictionary<string, string> data)
        {
            ILogInfo info = new LogInfo(controllerName, actionName, message, data);

            _userLogger.Log(info);
        }

        internal void LogError(string controllerName, string actionName, Exception ex)
        {
            HandleErrorInfo info = new HandleErrorInfo(ex, controllerName, actionName);
            _errorLogger.Log(info);
        }

        internal ActionResult ShowErrorView(string controllerName, string actionName, Exception ex)
        {
            HandleErrorInfo info = new HandleErrorInfo(ex, controllerName, actionName);
            _errorLogger.Log(info);
            return View("Error", info);
        }
    }
}
