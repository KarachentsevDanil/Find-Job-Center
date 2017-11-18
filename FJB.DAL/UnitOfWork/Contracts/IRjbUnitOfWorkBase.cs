using System;
using FJB.DAL.Repositories.Leases.Contracts;
using FJB.DAL.Repositories.Robots.Contracts;
using FJB.DAL.Repositories.Specializations.Contracts;
using FJB.DAL.Repositories.Users.Contracts;

namespace FJB.DAL.UnitOfWork.Contracts
{
    public interface IRjbUnitOfWorkBase : IUnitOfWorkBase, IDisposable
    {
        IRobotModelRepository RobotModels { get; set; }

        ISpecializationRepository Specializations { get; set; }
        
        ILeaseRepository Leases { get; set; }

        IRobotRepository Robots { get; set; }

        IRobotModelFeedbackRepository RobotFeedbacks { get; set; }

        IClientRepository Clients { get; set; }

        ICompanyRepository Companies { get; set; }
    }
}
