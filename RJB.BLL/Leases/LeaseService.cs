using FJB.DAL.UnitOfWork;
using FJB.DAL.UnitOfWork.Contracts;
using RJB.BLL.Leases.Contracts;

namespace RJB.BLL.Leases
{
    public class LeaseService : ILeaseService
    {
        private readonly IRjbUnitOfWorkBase _unitOfWork;

        public LeaseService(IRjbUnitOfWorkBase unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
    }
}
