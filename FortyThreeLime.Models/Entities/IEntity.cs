/*************************************************************************
/*************************************************************************
 * Author:  DCoreyDuke
 * Version: 1.0.0.0
 * Description: IEntity Interfaces and Base Entity Class
 ************************************************************************/

namespace FortyThreeLime.Models.Entities
{
    public interface IEntity
    {
        int Id { get; set; }
    }

    public interface IEntity<T> : IEntity where T : class
    {
    }

    public abstract class Entity : IEntity<Entity>
    {
        public int Id { get; set; }

        public Entity()
        {

        }
    }
}
