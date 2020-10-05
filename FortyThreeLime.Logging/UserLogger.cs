/*************************************************************************
 * Author: DCoreyDuke

 ************************************************************************/

namespace FortyThreeLime.Logging
{
    using System;
    using System.IO;
    using System.Text;

    /// <summary>
    /// Logs User Actions
    /// </summary>
    public class UserLogger : Logger, ILogger
    {
        public UserLogger() : base("UserLog.log")
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
    }
}