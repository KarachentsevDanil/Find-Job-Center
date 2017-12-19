using System.Collections.Generic;
using System.Web.Http;
using FJB.Domain.Entities.Robots;
using RJB.BLL.Models;
using RJB.BLL.Robots;
using RJB.BLL.Robots.Contracts;
using RJF.WebService.Attributes;

namespace RJF.WebService.Controllers.Api
{

    [BasicAuthentication(false)]
    public class RobotController : ApiController
    {
        private readonly IRobotService _robotService;
        private readonly IRobotModelService _robotModelService;

        public RobotController()
        {
            _robotService = new RobotService();
            _robotModelService = new RobotModelService();
        }

        [HttpPost]
        public void AddRobot([FromBody] RobotViewModel robot)
        {
            _robotService.AddRobots(robot, robot.Count);
        }

        [HttpPost]
        public void AddRobotModel([FromBody] RobotModel robotModel)
        {
            _robotModelService.AddRobotModel(robotModel);
        }

        public List<RobotModel> GetRobotsModel()
        {
            return _robotModelService.GetRobotModels();
        }

        public List<Robot> GetRobotsByOfCompany(int companyId)
        {
            var robots = _robotService.GetRobotsOfCompany(companyId);
            return robots;
        }

        public List<Robot> GetRobots()
        {
            var robots = _robotService.GetRobots();
            return robots;
        }

        public void UpdateRobotsStatus(List<Robot> robots)
        {
            foreach (var robot in robots)
            {
                _robotService.UpdateRobot(robot);
            }
        }

        public Robot GetRobotById(int robotId)
        {
            return _robotService.GetRobotById(robotId);
        }
    }
}