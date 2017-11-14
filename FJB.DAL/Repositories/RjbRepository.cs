using FJB.DAL.Context;

namespace FJB.DAL.Repositories
{
    public class RjbRepository<T> : RepositoryBase<T>, IRjbRepository<T> where T : class
    {
        public RjbRepository(RjbDbContext dbContext) 
            : base(dbContext)
        {
        }
    }
}
