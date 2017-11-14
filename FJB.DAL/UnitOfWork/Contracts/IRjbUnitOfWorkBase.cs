using System;
using FJB.DAL.Repositories;
using FJB.DAL.Repositories.Leases.Contracts;
using FJB.DAL.Repositories.Robots.Contracts;
using FJB.DAL.Repositories.Specializations.Contracts;
using FJB.DAL.Repositories.Users.Contracts;
using FJB.Domain.Entities.Specializations;

namespace FJB.DAL.UnitOfWork.Contracts
{
    public interface IRjbUnitOfWorkBase : IUnitOfWorkBase, IDisposable
    {
        ISpecializationRepository Specializations { get; set; }

        IRjbRepository<SubSpecialization> SubSpecializations { get; set; }

        ILeaseRepository Leases { get; set; }

        IRobotRepository Robots { get; set; }

        IRobotFeedbackRepository RobotFeedbacks { get; set; }

        IClientRepository Clients { get; set; }

        ICompanyRepository Companies { get; set; }
    }
}
