using System;
using System.Collections.Generic;
using System.Linq;
using FJB.DAL.UnitOfWork.Contracts;
using FJB.Domain.Entities.Params;
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

        public Robot GetRobotById(int robotId)
        {
            return _unitOfWork.Robots.GetItemByExpression(x => x.RobotId == robotId);
        }

        public IEnumerable<Robot> GetRobotsBySpecializationIds(int[] specializationIds)
        {
            var robotFilterParams = new FilterParams<Robot>(x => x.RobotModel.RobotModelSpecializations.Any(s => specializationIds.Contains(s.SpecializationId)));
            return _unitOfWork.Robots.GetItemsByExpression(robotFilterParams);
        }

        public IEnumerable<Robot> GetRobotsBySpecializationName(string specialization)
        {
            var robotFilterParams = new FilterParams<Robot>(x => x.RobotModel.RobotModelSpecializations.Any(s => string.Equals(s.Specialization.Name, specialization, StringComparison.CurrentCultureIgnoreCase)));
            return _unitOfWork.Robots.GetItemsByExpression(robotFilterParams);
        }

        public IEnumerable<Robot> GetAllAvailableRobots(DateTime startDate, DateTime endDate, int specializationId)
        {
            var robotFilterParams = new FilterParams<Robot>(x =>
                x.RobotModel.RobotModelSpecializations.Any(p=> p.SpecializationId == specializationId) && 
                !x.RobotLeases.Any(s => s.Lease.StartDate <= endDate && s.Lease.EndDate <= startDate));

            var robotWithLeases =  _unitOfWork.Robots.GetItemsByExpression(robotFilterParams);

            robotFilterParams = new FilterParams<Robot>(x =>
                x.RobotModel.RobotModelSpecializations.Any(p => p.SpecializationId == specializationId));

            var robotWihoutLeases = _unitOfWork.Robots.GetItemsByExpression(robotFilterParams);

            return robotWihoutLeases.Where(x => robotWithLeases.All(p => p.RobotId != x.RobotId)).ToList();
        }

        public IEnumerable<Robot> GetRobotsOfCompany(int companyId, out int totalCount)
        {
            var robotFilterParams = new FilterParams<Robot>(x => x.CompanyId == companyId);
            return _unitOfWork.Robots.GetItemsByExpression(robotFilterParams, out totalCount);
        }
    }
}
