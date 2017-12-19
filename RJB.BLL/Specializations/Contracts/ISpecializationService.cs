using System.Collections.Generic;
using FJB.Domain.Entities.Specializations;

namespace RJB.BLL.Specializations.Contracts
{
    public interface ISpecializationService
    {
        void AddSpecialization(string name);

        List<Specialization> GetRobotSpecializations();

    }
}
