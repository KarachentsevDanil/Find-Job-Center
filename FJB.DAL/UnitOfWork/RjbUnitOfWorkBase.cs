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

        public RjbUnitOfWorkBase(RjbDbContext dbContext,
            IRobotModelRepository robotModelRepository,
            ISpecializationRepository specializationRepository,
            ILeaseRepository leaseRepository,
            IRobotRepository robotRepository,
            IRobotModelFeedbackRepository robotModelFeedback,
            IClientRepository clientRepository,
            ICompanyRepository companyRepository) : base(dbContext)
        {
            RobotModels = robotModelRepository;
            Specializations = specializationRepository;
            Leases = leaseRepository;
            Robots = robotRepository;
            RobotFeedbacks = robotModelFeedback;
            Clients = clientRepository;
            Companies = companyRepository;

            _dbContext = dbContext;
        }

        public IRobotModelRepository RobotModels { get; set; }
        public ISpecializationRepository Specializations { get; set; }
        public ILeaseRepository Leases { get; set; }
        public IRobotRepository Robots { get; set; }
        public IRobotModelFeedbackRepository RobotFeedbacks { get; set; }
        public IClientRepository Clients { get; set; }
        public ICompanyRepository Companies { get; set; }
    }
}
