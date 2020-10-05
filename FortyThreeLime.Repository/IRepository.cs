/*************************************************************************
 * Author: DCoreyDuke
 ************************************************************************/
using System.Collections.Generic;

namespace FortyThreeLime.Repository
{
    public interface IRepository<TEntity> where TEntity : class
    {
        void Add(TEntity obj);
        TEntity GetById(int id);
        IEnumerable<TEntity> GetAll();
        int GetCount();
        void Update(TEntity obj);
        void Remove(int id);
    }
    

}
