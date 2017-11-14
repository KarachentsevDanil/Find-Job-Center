using FJB.DAL.UnitOfWork.Contracts;
using RJB.BLL.Robots.Contracts;

namespace RJB.BLL.Robots
{
    public class RobotFeedbackService : IRobotFeedbackService
    {
        private readonly IRjbUnitOfWorkBase _unitOfWork;

        public RobotFeedbackService(IRjbUnitOfWorkBase unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
    }
}
