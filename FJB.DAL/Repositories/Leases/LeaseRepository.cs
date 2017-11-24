using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using FJB.DAL.Context;
using FJB.DAL.Repositories.Leases.Contracts;
using FJB.Domain.Entities.Leases;
using FJB.Domain.Entities.Params;

namespace FJB.DAL.Repositories.Leases
{
    public class LeaseRepository : RjbRepository<Lease>, ILeaseRepository
    {
        private readonly RjbDbContext _dbContext;

        public LeaseRepository(RjbDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Lease> GetItemsByExpression(FilterParams<Lease> filterParams)
        {
            return _dbContext.Lease.Where(filterParams.Expression).AsEnumerable();
        }

        public IEnumerable<Lease> GetItemsByExpression(FilterParams<Lease> filterParams, out int totalCount)
        {
            var items = _dbContext.Lease.Where(filterParams.Expression);
            totalCount = items.Count();

            return items
                .Skip(filterParams.PageSize * (filterParams.PageNumber - 1))
                .Take(filterParams.PageSize)
                .AsEnumerable();
        }

        public Lease GetItemByExpression(Expression<Func<Lease, bool>> expression)
        {
            return _dbContext.Lease.FirstOrDefault(expression);
        }
    }
}
