using System.Collections.Generic;
using FJB.DAL.Repositories.Leases;
using FJB.DAL.Repositories.Leases.Contracts;
using FJB.Domain.Entities.Leases;
using RJB.BLL.Leases.Contracts;

namespace RJB.BLL.Leases
{
    public class LeaseService : ILeaseService
    {
        private readonly ILeaseRepository _leaseRepository;

        public LeaseService()
        {
            _leaseRepository = new LeaseRepository();
        }

        public void AddLease(Lease lease)
        {
            _leaseRepository.AddLease(lease);
        }

        public Lease GetLeaseDetailById(int leaseId)
        {
            return _leaseRepository.GetLeaseById(leaseId);
        }

        public List<Lease> GetLeasesOfClient(int clientId)
        {
            return _leaseRepository.GetLeasesOfClient(clientId);
        }

        public void UpdateLease(Lease lease)
        {
            _leaseRepository.UpdateLease(lease);
        }
    }
}
