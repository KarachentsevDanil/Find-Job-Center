using FJB.DAL.Context;
using FJB.DAL.Repositories.Leases.Contracts;
using FJB.Domain.Entities.Leases;

namespace FJB.DAL.Repositories.Leases
{
    public class LeaseRepository : RjbRepository<Lease>, ILeaseRepository
    {
        private readonly RjbDbContext _dbContext;

        public LeaseRepository(RjbDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
