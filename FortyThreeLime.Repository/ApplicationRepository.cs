/*************************************************************************
 * Author: DCoreyDuke
 ************************************************************************/
using FortyThreeLime.Data;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace FortyThreeLime.Repository
{
    public class ApplicationRepository<TEntity> : IDisposable, IRepository<TEntity> where TEntity : class
    {

        private ApplicationDbContext context;
        private DbSet<TEntity> table = null;
        private bool disposedValue;

        public ApplicationRepository()
        {
            this.context = new ApplicationDbContext();
            table = context.Set<TEntity>();
        }

        public ApplicationRepository(ApplicationDbContext _context)
        {
            this.context = _context;
            table = context.Set<TEntity>();
        }

        public void Add(TEntity obj)
        {
            table.Add(obj);
            context.SaveChanges();
        }
       
        public TEntity GetById(int id)
        {           
            return table.Find(id);
        }        

        public int GetCount()
        {
            return table.Count();
        }

        public IEnumerable<TEntity> GetAll()
        {
            return table.ToList();
        }

        public void Update(TEntity obj)
        {
            table.Attach(obj);
            context.Entry(obj).State = EntityState.Modified;
            context.SaveChanges();
        }

        private void Remove(int id)
        {
            TEntity existing = table.Find(id);
            table.Remove(existing);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            Remove(id);
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

        ~ApplicationRepository()
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
