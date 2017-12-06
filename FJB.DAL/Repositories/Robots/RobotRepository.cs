using System;
using System.Collections.Generic;
using System.Data.Entity;
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
            return _dbContext.Robots
                .Include(x => x.RobotModel)
                .Include(x => x.RobotModel.RobotModelSpecializations)
                .Include(x => x.RobotModel.RobotModelSpecializations.Select(p => p.Specialization))
                .Where(filterParams.Expression).ToList();
        }

        public IEnumerable<Robot> GetItemsByExpression(FilterParams<Robot> filterParams, out int totalCount)
        {
            var robots = _dbContext.Robots.Where(filterParams.Expression);
            totalCount = robots.Count();

            return robots
                .Include(x => x.RobotModel)
                .Include(x => x.RobotModel.RobotModelSpecializations)
                .Include(x => x.RobotModel.RobotModelSpecializations.Select(p => p.Specialization))
                .OrderByDescending(x => x.RobotId)
                .Skip(filterParams.PageSize * (filterParams.PageNumber - 1))
                .Take(filterParams.PageSize)
                .ToList();
        }

        public Robot GetItemByExpression(Expression<Func<Robot, bool>> expression)
        {
            return _dbContext.Robots
                .Include(x => x.RobotModel)
                .Include(x => x.RobotModel.RobotModelSpecializations)
                .Include(x => x.RobotModel.RobotModelSpecializations.Select(p => p.Specialization))
                .Include(x => x.RobotLeases)
                .Include(x => x.RobotLeases.Select(p => p.Lease))
                .Include(x => x.RobotLeases.Select(p => p.Lease.Client))
                .FirstOrDefault(expression);
        }
    }
}
