using FJB.DAL.Context;
using FJB.DAL.Repositories;
using FJB.DAL.Repositories.Leases.Contracts;
using FJB.DAL.Repositories.Robots.Contracts;
using FJB.DAL.Repositories.Specializations.Contracts;
using FJB.DAL.Repositories.Users.Contracts;
using FJB.DAL.UnitOfWork.Contracts;
using FJB.Domain.Entities.Specializations;

namespace FJB.DAL.UnitOfWork
{
    public class RjbUnitOfWorkBase : UnitOfWorkBase, IRjbUnitOfWorkBase
    {
        private readonly RjbDbContext _dbContext;

        public RjbUnitOfWorkBase(RjbDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public IRjbRepository<SubSpecialization> SubSpecializations { get; set; }
        public ISpecializationRepository Specializations { get; set; }
        public ILeaseRepository Leases { get; set; }
        public IRobotRepository Robots { get; set; }
        public IRobotFeedbackRepository RobotFeedbacks { get; set; }
        public IClientRepository Clients { get; set; }
        public ICompanyRepository Companies { get; set; }
    }
}
