using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using FJB.DAL.Context;

namespace FJB.DAL.Repositories
{
    public abstract class RepositoryBase<T> where T : class
    {
        protected RepositoryBase(RjbDbContext dbContext)
        {
            DbContext = dbContext;
            DbSet = DbContext.Set<T>();
        }

        protected RjbDbContext DbContext { get; set; }

        protected DbSet<T> DbSet { get; set; }

        public virtual IQueryable<T> GetAll()
        {
            return DbSet;
        }

        public virtual T GetById(int id)
        {
            return DbSet.Find(id);
        }

        public virtual EntityState GetEntityState(T entity)
        {
            DbEntityEntry dbEntityEntry = DbContext.Entry(entity);
            return dbEntityEntry.State;
        }

        public virtual void Add(T entity)
        {
            DbEntityEntry dbEntityEntry = DbContext.Entry(entity);
            if (dbEntityEntry.State != EntityState.Detached)
            {
                dbEntityEntry.State = EntityState.Added;
            }
            else
            {
                DbSet.Add(entity);
            }
        }

        public virtual void Update(T entity)
        {
            DbEntityEntry dbEntityEntry = DbContext.Entry(entity);

            if (dbEntityEntry.State == EntityState.Detached)
            {
                DbSet.Attach(entity);
            }

            dbEntityEntry.State = EntityState.Modified;
        }

        public virtual void Delete(T entity)
        {
            DbEntityEntry dbEntityEntry = DbContext.Entry(entity);
            if (dbEntityEntry.State != EntityState.Deleted)
            {
                dbEntityEntry.State = EntityState.Deleted;
            }
            else
            {
                DbSet.Attach(entity);
                DbSet.Remove(entity);
            }
        }

        public virtual void Delete(int id)
        {
            T entity = GetById(id);

            if (entity == null)
            {
                return;
            }

            Delete(entity);
        }

        public virtual void Detach(T entity)
        {
            DbEntityEntry dbEntityEntry = DbContext.Entry(entity);
            dbEntityEntry.State = EntityState.Detached;
        }

        public void Reload(T entity)
        {
            DbEntityEntry dbEntityEntry = DbContext.Entry(entity);
            dbEntityEntry?.Reload();
        }
    }
}
