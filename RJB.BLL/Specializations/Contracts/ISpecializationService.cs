using System.Collections.Generic;
using FJB.Domain.Entities.Specializations;

namespace RJB.BLL.Specializations.Contracts
{
    public interface ISpecializationService
    {
        void AddSpecialization(string name);

        void AddSubSpecialization(int parentId, string name);

        IEnumerable<Specialization> GetSpecializationsByName(string name);

        Specialization GetSpecializationById(int id);

        IEnumerable<Specialization> GetChildSpecializationsByParentId(int id);

        IEnumerable<Specialization> GetSpecializationsByIds(int[] ids);

        IEnumerable<Specialization> GetRootSpecializations();

    }
}
