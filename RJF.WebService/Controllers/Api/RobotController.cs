using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FJB.Domain.Entities.Robots;
using RJB.BLL.Models;
using RJB.BLL.Robots.Contracts;

namespace RJF.WebService.Controllers.Api
{
    public class RobotController : ApiController
    {
        private readonly IRobotService _robotService;
        private readonly IRobotModelService _robotModelService;

        public RobotController(IRobotService robotService, IRobotModelService robotModelService)
        {
            _robotService = robotService;
            _robotModelService = robotModelService;
        }

        [HttpPost]
        public HttpResponseMessage AddRobot([FromBody] RobotViewModel robot)
        {
            try
            {
                _robotService.AddRobots(robot, robot.Count);
                return Request.CreateResponse(HttpStatusCode.Created);
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpPost]
        public HttpResponseMessage AddRobotModel([FromBody] RobotModel robotModel)
        {
            try
            {
                _robotModelService.AddRobotModel(robotModel);
                return Request.CreateResponse(HttpStatusCode.Created);
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        public HttpResponseMessage GetRobotsModel()
        {
            try
            {
                var robots = _robotModelService.GetRobotModels();
                return Request.CreateResponse(HttpStatusCode.Created, robots);
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpPost]
        public HttpResponseMessage GetRobotsOnSpecificDateRange([FromBody] SearchRobotModel model)
        {
            try
            {
                var robots = _robotService.GetAllAvailableRobots(model.StartDate, model.EndDate, model.SpecializationId);
                return Request.CreateResponse(HttpStatusCode.Created, robots);
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }
        
        public HttpResponseMessage GetRobotsBySpecialization(string name)
        {
            try
            {
                var robots = _robotService.GetRobotsBySpecializationName(name);
                return Request.CreateResponse(HttpStatusCode.OK, robots);
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        public HttpResponseMessage GetRobotsByOfCompany(int companyId)
        {
            try
            {
                int totalCount;
                var robots = _robotService.GetRobotsOfCompany(companyId, out totalCount);
                var result = new CollectionResult<Robot>
                {
                    Collection = robots,
                    TotalCount = totalCount
                };

                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }
    }
}