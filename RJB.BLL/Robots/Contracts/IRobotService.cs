using System;
using System.Collections.Generic;
using FJB.Domain.Entities.Robots;

namespace RJB.BLL.Robots.Contracts
{
    public interface IRobotService
    {
        void AddRobots(Robot robot, int count);

        void UpdateRobot(Robot robot);

        Robot GetRobotById(int robotId);

        List<Robot> GetRobotsOfCompany(int companyId);

        List<Robot> GetAllAvailableRobots(DateTime startDate, DateTime endDate, int specializationId);

        List<Robot> GetRobots();
    }
}
