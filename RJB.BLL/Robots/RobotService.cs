using System;
using System.Collections.Generic;
using FJB.DAL.Repositories.Robots;
using FJB.DAL.Repositories.Robots.Contracts;
using FJB.Domain.Entities.Robots;
using RJB.BLL.Robots.Contracts;

namespace RJB.BLL.Robots
{
    public class RobotService : IRobotService
    {
        private readonly IRobotRepository _robotRepository;

        public RobotService()
        {
            _robotRepository = new RobotRepository();
        }

        public void AddRobots(Robot robot, int count)
        {
            var robots = new List<Robot>(count);

            for (var i = 0; i < count; i++)
            {
                robots.Add(new Robot(robot));
            }

            robots.ForEach(x => _robotRepository.AddRobot(x));
        }

        public void UpdateRobot(Robot robot)
        {
            _robotRepository.UpdateRobot(robot);
        }

        public Robot GetRobotById(int robotId)
        {
            return _robotRepository.GetRobotById(robotId);
        }

        public List<Robot> GetAllAvailableRobots(DateTime startDate, DateTime endDate, int specializationId)
        {
            return _robotRepository.GetAllAvailableRobots(startDate, endDate, specializationId);
        }

        public List<Robot> GetRobotsOfCompany(int companyId)
        {
            return _robotRepository.GetRobotsOfCompany(companyId);
        }

        public List<Robot> GetRobots()
        {
            return _robotRepository.GetAllRobots();
        }
    }
}
