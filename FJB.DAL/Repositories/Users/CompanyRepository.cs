using FJB.DAL.Context;
using FJB.DAL.Repositories.Users.Contracts;
using FJB.Domain.Entities.Users;

namespace FJB.DAL.Repositories.Users
{
    public class CompanyRepository : RjbRepository<Company>, ICompanyRepository
    {
        private RjbDbContext _dbContext;

        public CompanyRepository(RjbDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
