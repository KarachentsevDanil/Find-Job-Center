using System;
using FJB.DAL.Context;
using FJB.DAL.UnitOfWork.Contracts;

namespace FJB.DAL.UnitOfWork
{
    public abstract class UnitOfWorkBase : IUnitOfWorkBase, IDisposable
    {
        private readonly RjbDbContext _dbContext;

        protected UnitOfWorkBase(RjbDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _dbContext?.Dispose();
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Commit()
        {
            _dbContext.SaveChanges();
        }
        
        public void DisableAutoDetectChanges()
        {
            _dbContext.Configuration.AutoDetectChangesEnabled = false;
        }

        public void EnableAutoDetectChanges()
        {
            _dbContext.Configuration.AutoDetectChangesEnabled = true;
        }
    }
}
