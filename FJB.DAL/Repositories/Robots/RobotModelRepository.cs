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
    public class RobotModelRepository : RjbRepository<RobotModel>, IRobotModelRepository
    {
        private readonly RjbDbContext _dbContext;

        public RobotModelRepository(RjbDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<RobotModel> GetItemsByExpression(FilterParams<RobotModel> filterParams)
        {
            return _dbContext.RobotModels.Where(filterParams.Expression).AsEnumerable();
        }

        public IEnumerable<RobotModel> GetItemsByExpression(FilterParams<RobotModel> filterParams, out int totalCount)
        {
            var robots = _dbContext.RobotModels.Where(filterParams.Expression);
            totalCount = robots.Count();

            return robots
                .OrderBy(x => x.Name)
                .Skip(filterParams.PageSize * (filterParams.PageNumber - 1))
                .Take(filterParams.PageSize)
                .ToList();
        }

        public RobotModel GetItemByExpression(Expression<Func<RobotModel, bool>> expression)
        {
            return _dbContext.RobotModels.FirstOrDefault(expression);
        }

        public IEnumerable<RobotModel> GetModels()
        {
            return _dbContext.RobotModels.Include(x => x.RobotModelSpecializations.Select(p => p.Specialization))
                .ToList();
        }
    }
}
