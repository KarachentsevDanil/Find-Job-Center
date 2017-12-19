using System.Collections.Generic;
using FJB.Domain.Entities.Specializations;

namespace FJB.DAL.Repositories.Specializations.Contracts
{
    public interface ISpecializationRepository
    {
        void AddSpecialization(Specialization specialization);
        List<Specialization> GetRobotSpecializations();
    }
}
