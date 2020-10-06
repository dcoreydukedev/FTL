/*************************************************************************
 * Author:  DCoreyDuke
 * Version: 1.0.0.0
 * Description: Application Entity. 
 *              Represents an application in the solution
 ************************************************************************/
using System;
using System.ComponentModel.DataAnnotations;

namespace FortyThreeLime.Models.Entities
{

    public interface IApplication
    {
        int Id { get; set; }
        string AppName { get; set; }
        string Description { get; set; }
        string AppToken { get; set; }
    }

    /// <summary>
    /// Application Type Enumeration
    /// </summary>
    [Serializable]
    public enum ApplicationType
    {
        API = 0,
        Web = 1,
        Mobile = 2,
        Desktop = 3,
        Console = 4,
        Library = 5
    }

    /// <summary>
    /// Application Entity. Represents an application in the solution
    /// </summary>
    /// <seealso cref="FortyThreeLime.Models.Entities.IEntity{FortyThreeLime.Models.Entities.Application}" />
    /// <seealso cref="FortyThreeLime.Models.Entities.IApplication" />
    [Serializable]
    public class Application : IEntity<Application>, IApplication
    {

        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the Application Name.
        /// </summary>
        [MaxLength(256)]
        public string AppName { get; set; }

        /// <summary>
        /// Gets or Sets the Application Type
        /// </summary>
        public int AppType { get; set; }

        /// <summary>
        /// Gets or Sets the Application Description
        /// </summary>
        [MaxLength(250)]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the Application Token.
        /// </summary>
        [MaxLength(512)]
        public string AppToken { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Application"/> class.
        /// </summary>
        public Application()
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Application"/> class.
        /// </summary>
        /// <param name="appName"></param>
        /// <param name="description"></param>
        /// <param name="appToken"></param>
        public Application(string appName, int appType, string description, string appToken) : this()
        {
            this.AppName = appName;
            this.AppType = appType;
            this.Description = description;
            this.AppToken = appToken;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Application"/> class.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="appName"></param>
        /// <param name="description"></param>
        /// <param name="appToken"></param>
        public Application(int id, string appName, int appType, string description, string appToken) : this(appName, appType, description, appToken)
        {
            this.Id = id;           
        }

    }
}
