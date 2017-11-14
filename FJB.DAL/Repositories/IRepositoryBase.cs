using System.Data.Entity;
using System.Linq;

namespace FJB.DAL.Repositories
{
    public interface IRepositoryBase<T> where T : class
    {
        IQueryable<T> GetAll();
        T GetById(int id);
        EntityState GetEntityState(T entity);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Delete(int id);
        void Detach(T entity);
        void Reload(T entity);
    }
}
