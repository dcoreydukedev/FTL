/*************************************************************************
 * Author: DCoreyDuke
 * Logs Actions to ~/Logs/{Application}/Action.log
 ************************************************************************/

namespace FortyThreeLime.Logging
{
    public interface IActionLogger
    {
        void Log(ILogInfo info);
        void Log(string message);
    }

    /// <summary>
    /// Logs Actions
    /// </summary>
    public class ActionLogger : Logger, IActionLogger
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ActionLogger"/> class.
        /// </summary>
        public ActionLogger() : base("Action.log")
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

    }

}