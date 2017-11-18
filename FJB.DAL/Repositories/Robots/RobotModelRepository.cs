using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using FJB.DAL.Context;
using FJB.DAL.Repositories.Robots.Contracts;
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

        public IEnumerable<RobotModel> GetItemsByExpression(Expression<Func<RobotModel, bool>> expression)
        {
            return _dbContext.RobotModels.Where(expression).AsEnumerable();
        }

        public RobotModel GetItemByExpression(Expression<Func<RobotModel, bool>> expression)
        {
            return _dbContext.RobotModels.FirstOrDefault(expression);
        }
    }
}
