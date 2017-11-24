using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using FJB.DAL.Context;
using FJB.DAL.Repositories.Robots.Contracts;
using FJB.Domain.Entities.Params;
using FJB.Domain.Entities.Robots;

namespace FJB.DAL.Repositories.Robots
{
    public class RobotRepository : RjbRepository<Robot>, IRobotRepository
    {
        private readonly RjbDbContext _dbContext;

        public RobotRepository(RjbDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Robot> GetItemsByExpression(FilterParams<Robot> filterParams)
        {
            return _dbContext.Robots.Where(filterParams.Expression).AsEnumerable();
        }

        public IEnumerable<Robot> GetItemsByExpression(FilterParams<Robot> filterParams, out int totalCount)
        {
            var robots = _dbContext.Robots.Where(filterParams.Expression);
            totalCount = robots.Count();

            return robots
                .Skip(filterParams.PageSize * (filterParams.PageNumber - 1))
                .Take(filterParams.PageSize)
                .AsEnumerable();
        }

        public Robot GetItemByExpression(Expression<Func<Robot, bool>> expression)
        {
            return _dbContext.Robots.FirstOrDefault(expression);
        }
    }
}
