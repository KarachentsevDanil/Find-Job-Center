using System.Collections.Generic;
using FJB.Domain.Entities.Robots;

namespace RJB.BLL.Robots.Contracts
{
    public interface IRobotModelService
    {
        List<RobotModel> GetRobotModels();

        void AddRobotModel(RobotModel robotModel);

        void UpdateRobotModel(RobotModel robotModel);
    }
}
