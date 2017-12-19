using System.Collections.Generic;
using FJB.Domain.Entities.Robots;

namespace FJB.DAL.Repositories.Robots.Contracts
{
    public interface IRobotModelRepository
    {
        List<RobotModel> GetRobotModels();
        void AddRobotModel(RobotModel robotModel);
        void UpdateRobotModel(RobotModel robotModel);
    }
}
