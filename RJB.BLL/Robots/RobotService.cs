using FJB.DAL.UnitOfWork.Contracts;
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
    }
}
