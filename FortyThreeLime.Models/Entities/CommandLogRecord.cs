/*************************************************************************
 * Author:  DCoreyDuke
 * Version: 1.0.0.0
 * Description: Command Log Entity. 
 *              Represents an Entry into the Command Log.
 *              These records are sent from the mobile device to the API
 ************************************************************************/
using System.ComponentModel.DataAnnotations;
using System;
using FortyThreeLime.Models.Domain;
using FortyThreeLime.Models.ViewModels;
using System.ComponentModel.DataAnnotations.Schema;

namespace FortyThreeLime.Models.Entities
{

    /// <summary>
    /// Command Log Entity. Represents an Entry into the Command Log. These records are sent from the mobile device to the API
    /// </summary>
    /// <seealso cref="FortyThreeLime.Models.Entities.IEntity{FortyThreeLime.Models.Entities.CommandLogRecord}" />
    [Serializable]
    public class CommandLogRecord : IEntity<CommandLogRecord>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CommandLogRecord"/> class.
        /// </summary>
        public CommandLogRecord()
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CommandLogRecord"/> class.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="commandId">The command identifier.</param>
        /// <param name="timestamp">The timestamp.</param>
        /// <param name="latitude">The latitude.</param>
        /// <param name="longitude">The longitude.</param>
        public CommandLogRecord(string userId, int commandId, long timestamp, string latitude, string longitude) : this()
        {
            this.UserId = userId;
            this.CommandId = commandId;
            this.Timestamp = timestamp;
            this.Latitude = latitude;
            this.Longitude = longitude;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CommandLogRecord"/> class.
        /// </summary>
        /// <param name="vm">CommandLogViewModel Instance</param>
        public CommandLogRecord(CommandLogRecordViewModel vm) : this(vm.UserId, int.Parse(vm.CommandId), long.Parse(vm.Timestamp), vm.Latitude, vm.Longitude)
        {
            
        }

        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// 4 Character String User Identifier
        /// </summary>
        [MinLength(4), MaxLength(4)]
        public string UserId { get; set; }

        /// <summary>
        /// Gets or sets the integer command identifier.
        /// </summary>
        public int CommandId { get; set; }

        /// <summary>
        /// Gets or sets the epoch timestamp
        /// </summary>
        public long Timestamp { get; set; }

        /// <summary>
        /// Gets or sets the latitude
        /// </summary>
        public string Latitude { get; set; }

        /// <summary>
        /// Gets or sets the longitude
        /// </summary>
        public string Longitude { get; set; }

        [NotMapped]
        public LatLng Location
        {
            get
            {
                return new LatLng(this.Latitude, this.Longitude);
            }
        }

        public  User User { get; set; }

        public  ButtonCommand Command { get; set; }
    }

    /// <summary>
    /// For Compatibility with old API;
    /// </summary>
    /// <seealso cref="FortyThreeLime.Models.Entities.CommandLogRecord" />
    [Obsolete("This class included for compatibility with old API")]
    public class CommandLogSync : CommandLogRecord
    {
        public CommandLogSync() : base()
        {

        }
    }
}
