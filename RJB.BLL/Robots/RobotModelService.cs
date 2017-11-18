using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FJB.DAL.UnitOfWork.Contracts;
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
    }
}
