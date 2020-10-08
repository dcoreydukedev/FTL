/*************************************************************************
 * Author: DCoreyDuke
 * Version: 1.0.0.0
 * Description: Generic Repository for Solution
 ************************************************************************/
using FortyThreeLime.Data;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace FortyThreeLime.Repository
{


    public interface IRepository<TEntity> where TEntity : class
    {
        void Add(TEntity obj);
        Task AddAsync(TEntity obj);
        void Delete(int id);
        Task DeleteAsync(int id);
        void Dispose();
        IEnumerable<TEntity> GetAll();
        Task<IEnumerable<TEntity>> GetAllAsync();
        TEntity GetById(int id);
        Task<TEntity> GetByIdAsync(int id);
        int GetCount();
        Task<int> GetCountAsync();
        void Update(TEntity obj);
        Task UpdateAsync(TEntity obj);
    }

    /// <summary>
    /// Generic Repository for Solution
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    /// <seealso cref="IDisposable" />
    /// <seealso cref="IRepository{TEntity}" />
    public class Repository<TEntity> : IDisposable, IRepository<TEntity> where TEntity : class
    {

        private ApplicationDbContext context;
        private DbSet<TEntity> table = null;
        private bool disposedValue;

        public Repository()
        {
            this.context = new ApplicationDbContext();
            table = context.Set<TEntity>();
        }

        public Repository(ApplicationDbContext _context)
        {
            this.context = _context;
            table = context.Set<TEntity>();
        }

        public void Add(TEntity obj)
        {
            table.Add(obj);
            context.SaveChanges();
        }

        public async Task AddAsync(TEntity obj)
        {
            await table.AddAsync(obj);
            await context.SaveChangesAsync();
        }

        public TEntity GetById(int id)
        {
            return table.Find(id);
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await table.FindAsync(id);
        }

        public int GetCount()
        {
            return table.Count();
        }

        public async Task<int> GetCountAsync()
        {
            return await table.CountAsync();
        }

        public IEnumerable<TEntity> GetAll()
        {
            return table.ToList();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await table.ToListAsync();
        }

        public void Update(TEntity obj)
        {
            table.Attach(obj);
            context.Entry(obj).State = EntityState.Modified;
            context.SaveChanges();
        }

        public async Task UpdateAsync(TEntity obj)
        {
            table.Attach(obj);
            context.Entry(obj).State = EntityState.Modified;
            await context.SaveChangesAsync();

        }

        private void Remove(int id)
        {
            TEntity existing = table.Find(id);
            table.Remove(existing);
            context.SaveChanges();
        }

        private async Task RemoveAsync(int id)
        {
            TEntity existing = await table.FindAsync(id);
            table.Remove(existing);
            await context.SaveChangesAsync();
        }

        public void Delete(int id)
        {
            Remove(id);
        }

        public async Task DeleteAsync(int id)
        {
            await RemoveAsync(id);
        }

        #region Dispose

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                }
                this.context = null;
                this.table = null;

                disposedValue = true;
            }
        }

        ~Repository()
        {
            Dispose(disposing: false);
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        #endregion
    }


}
