using System.Collections.Generic;
using FJB.DAL.UnitOfWork.Contracts;
using FJB.Domain.Entities.Leases;
using FJB.Domain.Entities.Params;
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

        public IEnumerable<Lease> GetLeasesOfClient(int clientId, out int totalCount)
        {
            var leaseFilterParams = new FilterParams<Lease>(x => x.ClientId == clientId);
            return _unitOfWork.Leases.GetItemsByExpression(leaseFilterParams, out totalCount);
        }

        public void UpdateLease(Lease lease)
        {
            _unitOfWork.Leases.Update(lease);
            _unitOfWork.Commit();
        }
    }
}
