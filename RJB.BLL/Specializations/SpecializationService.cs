using FJB.DAL.UnitOfWork.Contracts;
using FJB.Domain.Entities.Specializations;
using RJB.BLL.Specializations.Contracts;

namespace RJB.BLL.Specializations
{
    public class SpecializationService : ISpecializationService
    {
        private readonly IRjbUnitOfWorkBase _unitOfWork;

        public SpecializationService(IRjbUnitOfWorkBase unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void AddSpecialization(string name)
        {
            _unitOfWork.Specializations.Add(new Specialization { Name = name });
            _unitOfWork.Commit();
        }

        public void AddSubSpecialization(int parentId, string name)
        {
            _unitOfWork.Specializations.Add(new Specialization { Name = name, ParentSpecializationId = parentId});
            _unitOfWork.Commit();
        }
    }
}
