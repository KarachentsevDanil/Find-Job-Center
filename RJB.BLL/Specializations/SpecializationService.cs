using System.Collections.Generic;
using FJB.DAL.Repositories.Specializations;
using FJB.DAL.Repositories.Specializations.Contracts;
using FJB.Domain.Entities.Specializations;
using RJB.BLL.Specializations.Contracts;

namespace RJB.BLL.Specializations
{
    public class SpecializationService : ISpecializationService
    {
        private readonly ISpecializationRepository _specializationRepository;

        public SpecializationService()
        {
            _specializationRepository = new SpecializationRepository();
        }

        public void AddSpecialization(string name)
        {
            _specializationRepository.AddSpecialization(new Specialization { Name = name });
        }
        

        public List<Specialization> GetRobotSpecializations()
        {
            return _specializationRepository.GetRobotSpecializations();
        }
    }
}
