/*************************************************************************
 * Author:  DCoreyDuke
 * Version: 1.0.0.0
 * Description: Button Command Category Entity. 
 *              Represents a logical grouping for Button Commands
 ************************************************************************/
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FortyThreeLime.Models.Entities
{

    public interface IButtonCommandCategory
    {
        string Category { get; set; }
        string Description { get; set; }
    }

    /// <summary>
    /// Button Command Category Entity. Represents a logical grouping for Button Commands
    /// </summary>
    /// <seealso cref="FortyThreeLime.Models.Entities.IEntity{FortyThreeLime.Models.Entities.ButtonCommandCategory}" />
    /// <seealso cref="FortyThreeLime.Models.Entities.IButtonCommandCategory" />
    public class ButtonCommandCategory : IEntity<ButtonCommandCategory>, IButtonCommandCategory
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the category.
        /// </summary>
        [MaxLength(256)]
        public string Category { get; set; }


        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        [MaxLength(1500)]
        public string Description { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ButtonCommandCategory"/> class.
        /// </summary>
        public ButtonCommandCategory()
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ButtonCommandCategory"/> class.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="category">The category.</param>
        /// <param name="description">The description.</param>
        public ButtonCommandCategory(string category, string description) : this()
        {
            Category = category;
            Description = description;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ButtonCommandCategory"/> class.
        /// </summary>
        /// <param name="category">The category.</param>
        /// <param name="description">The description.</param>
        public ButtonCommandCategory(int id, string category, string description) : this(category, description)
        {
            Id = id;         
        }

      
        public virtual List<ButtonCommand> ButtonCommands { get; set; }

    }

    
}
