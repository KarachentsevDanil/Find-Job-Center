using FJB.DAL.UnitOfWork.Contracts;
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
    }
}
