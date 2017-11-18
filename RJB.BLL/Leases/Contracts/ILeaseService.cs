using System.Collections.Generic;
using FJB.Domain.Entities.Leases;
using FJB.Domain.Entities.Robots;

namespace RJB.BLL.Leases.Contracts
{
    public interface ILeaseService
    {
        int AddLease(Lease lease);

        Lease GetLeaseDetailById(int leaseId);

        IEnumerable<Lease> GetLeasesOfClient(int clientId);

        void UpdateLease(Lease lease);
    }
}
