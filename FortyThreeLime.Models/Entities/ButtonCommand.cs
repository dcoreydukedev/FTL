/*************************************************************************
 * Author:  DCoreyDuke
 * Version: 1.0.0.0
 * Description: Button Command Entity. 
 *              Represents a command sent from mobile device when
 *              the user clicks a button.
 ************************************************************************/
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FortyThreeLime.Models.Entities
{
    public interface IButtonCommand
    {
        string Command { get; set; }
        int CommandId { get; set; }
        int Id { get; set; }
        int? ParentId { get; set; }

    }

    /// <summary>
    /// Button Command Entity. Represents a command sent from mobile device when the user clicks a button.
    /// </summary>
    /// <seealso cref="FortyThreeLime.Models.Entities.IEntity{FortyThreeLime.Models.Entities.ButtonCommand}" />
    /// <seealso cref="FortyThreeLime.Models.Entities.IButtonCommand" />
    public class ButtonCommand : IEntity<ButtonCommand>, IButtonCommand
    {

        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the integer command identifier.
        /// </summary>
        public int CommandId { get; set; }

        /// <summary>
        /// Gets or sets the command.
        /// </summary>
        [MaxLength(256)]
        public string Command { get; set; }

        /// <summary>
        /// Gets or sets the parent identifier.
        /// The Id of the Parent Command
        /// Parent Id is basically the Id of the Equipment Selector Command
        /// </summary>
        public int? ParentId { get; set; }

        /// <summary>
        /// Gets or sets the category identifier.
        /// </summary>
        public int CategoryId { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ButtonCommand"/> class.
        /// </summary>
        public ButtonCommand()
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ButtonCommand"/> class.
        /// </summary>
        /// <param name="commandId">The command identifier.</param>
        /// <param name="command">The command.</param>
        /// <param name="categoryId">The category identifier.</param>
        public ButtonCommand(int commandId, string command, int categoryId) : this(commandId, command, null, categoryId)
        {
            
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ButtonCommand"/> class.
        /// </summary>
        /// <param name="commandId">The command identifier.</param>
        /// <param name="command">The command.</param>
        /// <param name="parentId">The parent identifier.</param>
        /// <param name="categoryId">The category identifier.</param>
        public ButtonCommand(int commandId, string command, int? parentId, int categoryId) : this()
        {
            this.CommandId = commandId;
            this.Command = command;
            this.ParentId = parentId;
            this.CategoryId = categoryId;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ButtonCommand"/> class.
        /// </summary>
        /// <param name="commandId">The command identifier.</param>
        /// <param name="command">The command.</param>
        /// <param name="parentId">The parent identifier.</param>
        /// <param name="category">The category.</param>
        public ButtonCommand(int commandId, string command, int parentId, ButtonCommandCategory category) : this(commandId, command, parentId, category.Id)
        {
           
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ButtonCommand"/> class.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="commandId">The command identifier.</param>
        /// <param name="command">The command.</param>
        /// <param name="parentId">The parent identifier.</param>
        /// <param name="categoryId">The category identifier.</param>
        public ButtonCommand(int id, int commandId, string command, int parentId, int categoryId) : this(commandId, command, parentId, categoryId)
        {
            this.Id = id;           
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ButtonCommand"/> class.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="commandId">The command identifier.</param>
        /// <param name="command">The command.</param>
        /// <param name="parentId">The parent identifier.</param>
        /// <param name="category">The category.</param>
        public ButtonCommand(int id, int commandId, string command, int parentId, ButtonCommandCategory category) : this(commandId, command, parentId, category.Id)
        {
            this.Id = id;
        }

        public virtual ButtonCommandCategory Category { get; set; }

        public virtual List<CommandLogRecord> CommandLogs { get; set; }
    }
}
