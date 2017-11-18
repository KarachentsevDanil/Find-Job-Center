using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using FJB.DAL.Context;
using FJB.DAL.Repositories.Specializations.Contracts;
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

        public IEnumerable<Specialization> GetItemsByExpression(Expression<Func<Specialization, bool>> expression)
        {
            return _dbContext.Specializations.Where(expression).AsEnumerable();
        }

        public Specialization GetItemByExpression(Expression<Func<Specialization, bool>> expression)
        {
            return _dbContext.Specializations.FirstOrDefault(expression);
        }
    }
}
