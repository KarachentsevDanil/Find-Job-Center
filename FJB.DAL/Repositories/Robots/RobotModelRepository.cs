using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using FJB.DAL.Context;
using FJB.DAL.Repositories.Robots.Contracts;
using FJB.Domain.Entities.Robots;

namespace FJB.DAL.Repositories.Robots
{
    public class RobotModelRepository : IRobotModelRepository
    {
        private readonly RobotJobFinderDbContext _dbContext;

        public RobotModelRepository()
        {
            _dbContext = new RobotJobFinderDbContext();
        }

        public List<RobotModel> GetRobotModels()
        {
            return _dbContext.RobotModels
                .Include(x => x.RobotModelSpecializations.Select(p => p.Specialization))
                .OrderBy(x => x.Name)
                .ToList();
        }

        public void AddRobotModel(RobotModel robotModel)
        {
            _dbContext.RobotModels.Add(robotModel);
            _dbContext.SaveChanges();
        }

        public void UpdateRobotModel(RobotModel robotModel)
        {
            _dbContext.RobotModels.AddOrUpdate(robotModel);
            _dbContext.SaveChanges();
        }
    }
}
