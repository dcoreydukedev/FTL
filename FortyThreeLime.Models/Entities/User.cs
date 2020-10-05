/*************************************************************************
 * Author:  DCoreyDuke
 * Version: 1.0.0.0
 * Description: User Entity
 ************************************************************************/
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FortyThreeLime.Models.Entities
{
    public interface IUser
    {
        int Id { get; set; }
        bool? IsActive { get; set; }
        bool? IsOnline { get; set; }
        int RoleId { get; set; }
        string UserId { get; set; }
        string Username { get; set; }
    }

    /// <summary>
    /// User Entity. Defines a User
    /// </summary>
    /// <seealso cref="FortyThreeLime.Models.Entities.IEntity{FortyThreeLime.Models.Entities.User}" />
    /// <seealso cref="FortyThreeLime.Models.Entities.IUser" />
    public class User : IEntity<User>, IUser
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// 4 Character String User Identifier
        /// </summary>
        [MinLength(4), MaxLength(4)]
        public string UserId { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the username. Limited to 56 Characters
        /// </summary>        
        [MaxLength(56)]
        public string Username { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the role identifier. Defaults to 3 (User)
        /// </summary>
        public int RoleId { get; set; } = 3;

        /// <summary>
        /// Is Active User
        /// </summary>       
        public bool? IsActive { get; set; } = null;

        /// <summary>
        /// Is the User Currently Logged In?
        /// </summary>        
        public bool? IsOnline { get; set; } = null;

        /// <summary>
        /// Initializes a new instance of the <see cref="User"/> class.
        /// </summary>
        public User()
        {
            this.UserId = string.Empty;
            this.Username = string.Empty;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="User"/> class.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="username">The username.</param>
        /// <param name="roleId">The role identifier.</param>
        /// <param name="isActive">if set to <c>true</c> [is active].</param>
        /// <param name="isOnline">if set to <c>true</c> [is online].</param>
        public User(string userId, string username, int roleId, bool isActive, bool isOnline)
        {
            this.UserId = userId;
            this.Username = username;
            this.RoleId = roleId;
            this.IsActive = isActive;
            this.IsOnline = isOnline;
        }


        public virtual List<CommandLogRecord> CommandLogs { get; set; }
    }
}
