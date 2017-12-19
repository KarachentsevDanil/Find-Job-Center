using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Data.Entity;
using FJB.DAL.Context;
using FJB.DAL.Repositories.Robots.Contracts;
using FJB.Domain.Entities.Robots;

namespace FJB.DAL.Repositories.Robots
{
    public class RobotRepository : IRobotRepository
    {
        private readonly RobotJobFinderDbContext _dbContext;

        public RobotRepository()
        {
            _dbContext = new RobotJobFinderDbContext();
        }

        public void AddRobot(Robot robot)
        {
            _dbContext.Robots.Add(robot);
            _dbContext.SaveChanges();
        }

        public void UpdateRobot(Robot robot)
        {
            _dbContext.Robots.AddOrUpdate(robot);
            _dbContext.SaveChanges();
        }

        public List<Robot> GetAllRobots()
        {
            return _dbContext.Robots.ToList();
        }

        public Robot GetRobotById(int robotId)
        {
            return _dbContext.Robots
                .Include(x => x.RobotModel.RobotModelSpecializations.Select(p => p.Specialization))
                .FirstOrDefault(x => x.RobotId == robotId);
        }

        public List<Robot> GetAllAvailableRobots(DateTime startDate, DateTime endDate, int specializationId)
        {
            return _dbContext.Robots.Where(x =>
                x.RobotModel.RobotModelSpecializations.Any(p => p.SpecializationId == specializationId) &&
                !x.RobotLeases.Any(s => s.Lease.StartDate < startDate && s.Lease.StartDate < endDate
                                        && s.Lease.EndDate >= startDate && s.Lease.EndDate >= endDate))
                .Include(x => x.RobotModel.RobotModelSpecializations.Select(p => p.Specialization))
                .ToList();
        }

        public List<Robot> GetRobotsOfCompany(int companyId)
        {
            return _dbContext.Robots
                .Include(x => x.RobotModel.RobotModelSpecializations.Select(p => p.Specialization))
                .Where(x => x.CompanyId == companyId)
                .OrderByDescending(x => x.RobotId)
                .ToList();
        }
    }
}
