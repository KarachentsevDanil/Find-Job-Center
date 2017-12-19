using System;
using System.Collections.Generic;
using FJB.Domain.Entities.Robots;

namespace FJB.DAL.Repositories.Robots.Contracts
{
    public interface IRobotRepository
    {
        void AddRobot(Robot robot);
        void UpdateRobot(Robot robot);
        Robot GetRobotById(int robotId);
        List<Robot> GetAllAvailableRobots(DateTime startDate, DateTime endDate, int specializationId);
        List<Robot> GetRobotsOfCompany(int companyId);
        List<Robot> GetAllRobots();
    }
}
