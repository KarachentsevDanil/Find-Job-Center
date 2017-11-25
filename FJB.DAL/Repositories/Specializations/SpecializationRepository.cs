using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using FJB.DAL.Context;
using FJB.DAL.Repositories.Specializations.Contracts;
using FJB.Domain.Entities.Params;
using FJB.Domain.Entities.Specializations;

namespace FJB.DAL.Repositories.Specializations
{
    public class SpecializationRepository : RjbRepository<Specialization>, ISpecializationRepository
    {
        private RjbDbContext _dbContext;

        public SpecializationRepository(RjbDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Specialization> GetItemsByExpression(FilterParams<Specialization> filterParams)
        {
            return _dbContext.Specializations.Where(filterParams.Expression).ToList();
        }

        public IEnumerable<Specialization> GetItemsByExpression(FilterParams<Specialization> filterParams, out int totalCount)
        {
            var specializations = _dbContext.Specializations.Where(filterParams.Expression);
            totalCount = specializations.Count();

            return specializations
                .OrderBy(x => x.Name)
                .Skip(filterParams.PageSize * (filterParams.PageNumber - 1))
                .Take(filterParams.PageSize)
                .ToList();
        }

        public Specialization GetItemByExpression(Expression<Func<Specialization, bool>> expression)
        {
            return _dbContext.Specializations.FirstOrDefault(expression);
        }
    }
}
