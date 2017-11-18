using System;
using System.Collections.Generic;
using System.Linq;
using FJB.DAL.UnitOfWork.Contracts;
using FJB.Domain.Entities.Robots;
using RJB.BLL.Robots.Contracts;

namespace RJB.BLL.Robots
{
    public class RobotService : IRobotService
    {
        private readonly IRjbUnitOfWorkBase _unitOfWork;

        public RobotService(IRjbUnitOfWorkBase unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void AddRobots(Robot robot, int count)
        {
            var robots = new List<Robot>(count);

            for (var i = 0; i < count; i++)
            {
                robots.Add(new Robot(robot));
            }

            robots.ForEach(x => _unitOfWork.Robots.Add(x));
            _unitOfWork.Commit();
        }

        public void UpdateRobot(Robot robot)
        {
            _unitOfWork.Robots.Update(robot);
            _unitOfWork.Commit();
        }

        public IEnumerable<Robot> GetRobotsBySpecializationIds(int[] specializationIds)
        {
            return _unitOfWork.Robots
                .GetItemsByExpression(x =>
                    x.RobotModel.RobotModelSpecializations.Any(s => specializationIds.Contains(s.SpecializationId)));
        }

        public IEnumerable<Robot> GetRobotsBySpecializationName(string specialization)
        {
            return _unitOfWork.Robots
                .GetItemsByExpression(x =>
                    x.RobotModel.RobotModelSpecializations.Any(s => string.Equals(s.Specialization.Name, specialization, StringComparison.CurrentCultureIgnoreCase)));
        }

        public IEnumerable<Robot> GetAllAvailableRobots(DateTime startDate, DateTime endDate, int specializationId)
        {
            return _unitOfWork.Robots
                .GetItemsByExpression(x =>
                    !x.RobotLeases.Any(s => s.Lease.StartDate < endDate && s.Lease.EndDate < startDate));
        }

        public IEnumerable<Robot> GetRobotsOfCompany(int companyId)
        {
            return _unitOfWork.Robots.GetItemsByExpression(x => x.CompanyId == companyId);
        }
    }
}
