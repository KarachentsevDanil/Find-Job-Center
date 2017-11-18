using System.Collections.Generic;
using FJB.Domain.Entities.Robots;

namespace RJB.BLL.Robots.Contracts
{
    public interface IRobotModelFeedbackService
    {
        void AddFeerback(RobotModelFeedback modelFeedback);

        IEnumerable<RobotModelFeedback> GetRobotFeedbacks(int robotId);
    }
}
