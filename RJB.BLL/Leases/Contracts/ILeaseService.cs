using System.Collections.Generic;
using FJB.Domain.Entities.Leases;

namespace RJB.BLL.Leases.Contracts
{
    public interface ILeaseService
    {
        void AddLease(Lease lease);

        Lease GetLeaseDetailById(int leaseId);

        List<Lease> GetLeasesOfClient(int clientId);

        void UpdateLease(Lease lease);
    }
}
