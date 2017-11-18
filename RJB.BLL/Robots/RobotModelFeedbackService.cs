using System.Collections.Generic;
using System.Linq;
using FJB.DAL.UnitOfWork.Contracts;
using FJB.Domain.Entities.Robots;
using RJB.BLL.Robots.Contracts;

namespace RJB.BLL.Robots
{
    public class RobotModelFeedbackService : IRobotModelFeedbackService
    {
        private readonly IRjbUnitOfWorkBase _unitOfWork;

        public RobotModelFeedbackService(IRjbUnitOfWorkBase unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void AddFeerback(RobotModelFeedback modelFeedback)
        {
            _unitOfWork.RobotFeedbacks.Add(modelFeedback);
            _unitOfWork.Commit();
        }

        public IEnumerable<RobotModelFeedback> GetRobotFeedbacks(int robotId)
        {
            return _unitOfWork.RobotFeedbacks.GetAll().Where(x => x.RobotModelId == robotId).AsEnumerable();
        }
    }
}
