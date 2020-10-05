/*************************************************************************
 * Author:  DCoreyDuke
 * Version: 1.0.0.0
 * Description: Role Entity
 ************************************************************************/

using System.ComponentModel.DataAnnotations;

namespace FortyThreeLime.Models.Entities
{
    public interface IRole
    {
        int Id { get; set; }
        string RoleName { get; set; }
    }

    /// <summary>
    /// Role Entity. Defines a Role for a User
    /// </summary>
    /// <seealso cref="FortyThreeLime.Models.Entities.IEntity{FortyThreeLime.Models.Entities.Role}" />
    /// <seealso cref="FortyThreeLime.Models.Entities.IRole" />
    public class Role : IEntity<Role>, IRole
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the role.
        /// </summary>
        /// <value>
        /// The name of the role.
        /// </value>
        [MaxLength(128)]
        public string RoleName { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Role"/> class.
        /// </summary>
        public Role()
        {
            this.RoleName = string.Empty;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Role"/> class.
        /// </summary>
        /// <param name="roleName">Name of the role.</param>
        public Role(string roleName)
        {
            this.RoleName = roleName;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Role"/> class.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="roleName">Name of the role.</param>
        public Role(int id, string roleName)
        {
            this.Id = id;
            this.RoleName = roleName;
        }
    }
}
