using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using Repository;

namespace DataAccess
{
    public class BaseRepository : IDisposable
    {
        protected IUnitOfWork UnitOfWork { get; set; }
        private bool disposed = false;

        protected StoreEntities Context
        {
            get { return (EfStoreDataContext)this.UnitOfWork; }
        }

        /// <summary>
        /// .ctor
        /// </summary>
        /// <param name="unitOfWork"></param>
        public BaseRepository(IUnitOfWork unitOfWork)
        {
            if (unitOfWork == null) throw new ArgumentNullException("unitOfWork");
            this.UnitOfWork = unitOfWork;
        }

        public void Save()
        {
            try
            {
                using(var scope = new TransactionScope(TransactionScopeOption.RequiresNew))
                {
                    this.Context.SaveChanges();
                    scope.Complete();
                }
            }
            catch (DbUpdateConcurrencyException concurrencyException)
            {
                concurrencyException.Entries.Single().OriginalValues.SetValues(concurrencyException.Entries.Single().GetDatabaseValues());
                throw;
            }
        }

        protected virtual DbSet<TEntity> GetDbSet<TEntity>() where TEntity : class
        {
            return this.Context.Set<TEntity>();
        }

        protected virtual void SetEntityState(object entity, EntityState entityState)
        {
            this.Context.Entry(entity).State = entityState;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    this.Context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        } 
    }
}
