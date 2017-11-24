using System;
using System.Collections.Generic;
using FJB.Domain.Entities.Robots;

namespace RJB.BLL.Robots.Contracts
{
    public interface IRobotService
    {
        void AddRobots(Robot robot, int count);

        void UpdateRobot(Robot robot);

        IEnumerable<Robot> GetRobotsBySpecializationIds(int[] specializationIds);

        IEnumerable<Robot> GetRobotsBySpecializationName(string specialization);

        IEnumerable<Robot> GetRobotsOfCompany(int companyId, out int totalCount);

        IEnumerable<Robot> GetAllAvailableRobots(DateTime startDate, DateTime endDate, int specializationId);
    }
}
