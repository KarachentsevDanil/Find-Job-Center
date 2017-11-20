using System.Collections.Generic;
using System.Linq;
using FJB.DAL.UnitOfWork.Contracts;
using FJB.Domain.Entities.Robots;
using RJB.BLL.Robots.Contracts;

namespace RJB.BLL.Robots
{
    public class RobotModelService : IRobotModelService
    {
        private readonly IRjbUnitOfWorkBase _unitOfWork;

        public RobotModelService(IRjbUnitOfWorkBase unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<RobotModel> GetRobotModels()
        {
            return _unitOfWork.RobotModels.GetAll().OrderBy(x => x.Name).ToList();
        }

        public void AddRobotModel(RobotModel robotModel)
        {
            _unitOfWork.RobotModels.Add(robotModel);
            _unitOfWork.Commit();
        }

        public void UpdateRobotModel(RobotModel robotModel)
        {
            _unitOfWork.RobotModels.Update(robotModel);
            _unitOfWork.Commit();
        }
    }
}
