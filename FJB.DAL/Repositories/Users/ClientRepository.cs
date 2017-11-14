using FJB.DAL.Context;
using FJB.DAL.Repositories.Users.Contracts;
using FJB.Domain.Entities.Users;

namespace FJB.DAL.Repositories.Users
{
    public class ClientRepository : RjbRepository<Client>, IClientRepository
    {
        private RjbDbContext _dbContext;

        public ClientRepository(RjbDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
