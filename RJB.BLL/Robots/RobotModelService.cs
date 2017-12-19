using System.Collections.Generic;
using System.Linq;
using FJB.DAL.Repositories.Leases;
using FJB.DAL.Repositories.Robots;
using FJB.DAL.Repositories.Robots.Contracts;
using FJB.Domain.Entities.Robots;
using RJB.BLL.Robots.Contracts;

namespace RJB.BLL.Robots
{
    public class RobotModelService : IRobotModelService
    {
        private readonly IRobotModelRepository _robotModelRepository;

        public RobotModelService()
        {
            _robotModelRepository = new RobotModelRepository();
        }

        public List<RobotModel> GetRobotModels()
        {
            return _robotModelRepository.GetRobotModels();
        }

        public void AddRobotModel(RobotModel robotModel)
        {
            _robotModelRepository.AddRobotModel(robotModel);
        }

        public void UpdateRobotModel(RobotModel robotModel)
        {
            _robotModelRepository.UpdateRobotModel(robotModel);
        }
    }
}
