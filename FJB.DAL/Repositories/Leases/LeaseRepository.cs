using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using FJB.DAL.Context;
using FJB.DAL.Repositories.Leases.Contracts;
using FJB.Domain.Entities.Leases;

namespace FJB.DAL.Repositories.Leases
{
    public class LeaseRepository : ILeaseRepository
    {
        private readonly RobotJobFinderDbContext _dbContext;

        public LeaseRepository()
        {
            _dbContext = new RobotJobFinderDbContext();
        }

        public void AddLease(Lease lease)
        {
            _dbContext.Lease.Add(lease);
            _dbContext.SaveChanges();
        }

        public Lease GetLeaseById(int leaseId)
        {
            return _dbContext.Lease.FirstOrDefault(x => x.LeaseId == leaseId);
        }

        public List<Lease> GetLeasesOfClient(int clientId)
        {
            return _dbContext.Lease.Where(x => x.ClientId == clientId).OrderByDescending(x => x.LeaseId).ToList();
        }

        public void UpdateLease(Lease lease)
        {
            _dbContext.Lease.AddOrUpdate(lease);
            _dbContext.SaveChanges();
        }
    }
}
