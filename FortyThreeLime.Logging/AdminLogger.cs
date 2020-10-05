/*************************************************************************
 * Author: DCoreyDuke
 * Logs Administrative Actions to ~/Logs/AdminLog.log
 ************************************************************************/

namespace FortyThreeLime.Logging
{
    /// <summary>
    /// Logs Administrative Actions
    /// </summary>
    public class AdminLogger : Logger, ILogger
    {
        public AdminLogger() : base("AdminLog.log")
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