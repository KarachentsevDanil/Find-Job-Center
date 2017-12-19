using System.Collections.Generic;
using FJB.Domain.Entities.Leases;

namespace FJB.DAL.Repositories.Leases.Contracts
{
    public interface ILeaseRepository
    {
        void AddLease(Lease lease);
        Lease GetLeaseById(int leaseId);
        List<Lease> GetLeasesOfClient(int clientId);
        void UpdateLease(Lease lease);
    }
}
