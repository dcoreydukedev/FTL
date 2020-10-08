/*************************************************************************
 * Author: DCoreyDuke
 * Provides Common Controller Functionality 
 ************************************************************************/

using System;
using FortyThreeLime.Logging;
using Microsoft.AspNetCore.Mvc;

namespace FortyThreeLime.API.Controllers
{
    /// <summary>
    /// Base Class For Api Controllers, Provides Logging Functionality
    /// </summary>
    public class ApiControllerBase : ControllerBase
    {
       

        /// <summary>
        /// Private Instance of ErrorLogger
        /// </summary>
        private readonly ErrorLogger _errorLogger;

        /// <summary>
        /// Private Instance of ActionLogger
        /// </summary>
        private readonly ActionLogger _actionLogger;

        /// <summary>
        /// Initializes a new instance of the <see cref="ApiControllerBase"/> class.
        /// </summary>
        public ApiControllerBase() : base()
        {
            _errorLogger = new ErrorLogger();
            _actionLogger = new ActionLogger();
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

        /// <summary>
        /// Logs the action
        /// </summary>
        /// <param name="controllerName">Name of the controller.</param>
        /// <param name="actionName">Name of the action.</param>
        /// <param name="message">The message</param>
        internal void LogAction(string controllerName, string actionName, string message)
        {
            LogInfo info = new LogInfo(controllerName, actionName, message);
            _actionLogger.Log(info);
        }

        /* -- Return Messages -- */
       
        internal static readonly string LOGIN_TOKEN_NULL = "Login Token Must Be Provided!";
        internal static readonly string LOGIN_TOKEN_INVALID = "The Value Provided for the Login Token is Invalid or Cannot Be Found!";
        internal static readonly string LOGIN_REQUIRED = "You Must Login and Provide a Valid Login Token to Access This Data";

        internal static readonly string SUCCESS_DATA = "Data Retrieval Successful";
        internal static readonly string SUCCESS_ACTION = "Action Executed Successfully";

        internal static readonly string FAILURE_DATA = "Data Retrieval Failed!";
        internal static readonly string FAILURE_ACTION = "Action Execution Failure";

        internal static readonly string UNAUTHORIZED_DATA = "You Do Not Have Permission To Access That Data";
        internal static readonly string UNAUTHORIZED_ACTION = "You Do Not Have Permission To Perform That Action";

        internal static readonly string USERID_NULL = "UserId Must Be Provided!";
        internal static readonly string USERID_INVALID = "The Value Provided for the User Id is Invalid or Cannot Be Found!";

        internal static readonly string ID_NULL = "An Identifier Must Be Provided!";
        internal static readonly string ID_INVALID = "A Valid Identifier Must Be Provided!";
    }

   
}
