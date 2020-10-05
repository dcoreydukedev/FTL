/*************************************************************************
 * Author: DCoreyDuke
 ************************************************************************/

using FortyThreeLime.Logging;
using System;
using Microsoft.AspNetCore.Mvc.Filters;

namespace FortyThreeLime
{
    public class FortyThreeLimeErrorHandler : ExceptionFilterAttribute
    {
        /// <summary>
        /// Private Instance of ErrorLogger
        /// </summary>
        private readonly ErrorLogger _errorLogger;

        public FortyThreeLimeErrorHandler()
        {
            this._errorLogger = new ErrorLogger();
        }

        public override void OnException(ExceptionContext filterContext)
        {
            var controllerName = filterContext.RouteData.Values["controller"].ToString();
            var actionName = filterContext.RouteData.Values["action"].ToString();
            var ex = filterContext.Exception;

            LogError(controllerName, actionName, ex);

            base.OnException(filterContext);
        }

        private void LogError(string controllerName, string actionName, Exception ex)
        {
            var info = new HandleErrorInfo(ex, controllerName, actionName);
            _errorLogger.Log(info);
        }
    }
}
