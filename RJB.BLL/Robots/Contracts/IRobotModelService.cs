using FJB.Domain.Entities.Robots;

namespace RJB.BLL.Robots.Contracts
{
    public interface IRobotModelService
    {
        void AddRobotModel(RobotModel robotModel);

        void UpdateRobotModel(RobotModel robotModel);
    }
}
