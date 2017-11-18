using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using FJB.DAL.Context;
using FJB.DAL.Repositories.Leases.Contracts;
using FJB.Domain.Entities.Leases;

namespace FJB.DAL.Repositories.Leases
{
    public class LeaseRepository : RjbRepository<Lease>, ILeaseRepository
    {
        private readonly RjbDbContext _dbContext;

        public LeaseRepository(RjbDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Lease> GetItemsByExpression(Expression<Func<Lease, bool>> expression)
        {
            return _dbContext.Lease.Where(expression).AsEnumerable();
        }

        public Lease GetItemByExpression(Expression<Func<Lease, bool>> expression)
        {
            return _dbContext.Lease.FirstOrDefault(expression);
        }
    }
}
