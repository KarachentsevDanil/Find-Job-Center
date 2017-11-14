using FJB.DAL.Context;
using FJB.DAL.Repositories.Specializations.Contracts;
using FJB.Domain.Entities.Specializations;

namespace FJB.DAL.Repositories.Specializations
{
    public class SpecializationRepository : RjbRepository<Specialization>, ISpecializationRepository
    {
        private RjbDbContext _dbContext;

        public SpecializationRepository(RjbDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
