using System.Collections.Generic;
using FJB.DAL.UnitOfWork.Contracts;
using FJB.Domain.Entities.Leases;
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

        public int AddLease(Lease lease)
        {
            _unitOfWork.Leases.Add(lease);
            _unitOfWork.Commit();
            return lease.LeaseId;
        }

        public Lease GetLeaseDetailById(int leaseId)
        {
            return _unitOfWork.Leases.GetItemByExpression(x => x.LeaseId == leaseId);
        }

        public IEnumerable<Lease> GetLeasesOfClient(int clientId)
        {
            return _unitOfWork.Leases.GetItemsByExpression(x => x.ClientId == clientId);
        }

        public void UpdateLease(Lease lease)
        {
            _unitOfWork.Leases.Update(lease);
            _unitOfWork.Commit();
        }
    }
}
