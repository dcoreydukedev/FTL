/*************************************************************************
 * Author:  DCoreyDuke
 * Version: 1.0.0.0
 * Description: Command Log Record View Model. 
 ************************************************************************/
using FortyThreeLime.Models.Entities;
using System;

namespace FortyThreeLime.Models.ViewModels
{
    public class CommandLogRecordViewModel : IViewModel<CommandLogRecord>
    {

        private CommandLogRecordViewModel()
        {

        }

        public CommandLogRecordViewModel(string userId, string commandId, string timestamp, string latitude, string longitude)
        {
            if (!string.IsNullOrEmpty(userId) && !string.IsNullOrWhiteSpace(userId))
            {
                this.UserId = userId;
            }
            else
            {
                throw new ArgumentNullException("userId", "Proper value for UserId must be provided!");
            }
            if (!string.IsNullOrEmpty(commandId) && !string.IsNullOrWhiteSpace(commandId))
            {
                this.CommandId = commandId;
            }
            else
            {
                throw new ArgumentNullException("commandId", "Proper value for CommandId must be provided!");
            }

            if (!string.IsNullOrEmpty(timestamp) && !string.IsNullOrWhiteSpace(timestamp))
            {
                this.Timestamp = timestamp;
            }
            else
            {
                throw new ArgumentNullException("timestamp", "Proper value for Timestamp must be provided!");
            }
            if ((!string.IsNullOrEmpty(latitude) && !string.IsNullOrWhiteSpace(latitude)))  
            {
                this.Latitude = latitude;
            }
            else
            {
                throw new ArgumentNullException("latitude", "Proper value for Latitude must be provided!");
            }
            if ((!string.IsNullOrEmpty(longitude) && !string.IsNullOrWhiteSpace(longitude)))
            {
                this.Longitude = longitude;
            }
            else
            {
                throw new ArgumentNullException("longitude", "Proper value for Longitude must be provided!");
            }

        }

        public string UserId { get; set; }
        public string CommandId { get; set; }
        public string Timestamp { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
    }
}
