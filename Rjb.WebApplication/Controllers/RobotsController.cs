using System.Collections.Generic;
using System.Web.Mvc;
using FJB.Domain.Entities.Robots;
using FJB.Domain.Entities.Specializations;
using HttpClientExtenctions.RequestHelpers;
using Rjb.WebApplication.Attributes;
using Rjb.WebApplication.Models;
using RJB.BLL.Models;

namespace Rjb.WebApplication.Controllers
{
    [Authorization]
    public class RobotsController : Controller
    {
        public ActionResult AddRobot()
        {
            var robotModels = RobotClientService.GetRobotsModel();
            var robotModel = new RobotViewModel()
            {
                RobotModels = robotModels
            };

            return View(robotModel);
        }

        public ActionResult AddRobotModel()
        {
            var specializations = SpecializationClientService.GetAllSpecializations();
            var robotModel = new RobotModelViewModel
            {
                Specializations = specializations
            };
            return View(robotModel);
        }

        public ActionResult CompanyRobots()
        {
            var robots = RobotClientService.GetRobotsByOfCompany(CurrentUser.User.UserId);
            return View(robots.Collection);
        }

        public ActionResult RobotDetails(int robotId)
        {
            var robot = RobotClientService.GetRobotById(robotId);
            return View(robot);
        }

        [HttpPost]
        public ActionResult AddRobot(RobotViewModel robot)
        {
            var isSuccess = RobotClientService.AddRobot(robot);

            if (!isSuccess)
            {
                ModelState.AddModelError("AddRobot", "Add robot failed.");
                var robotModels = RobotClientService.GetRobotsModel();
                robot.RobotModels = robotModels;

                return View("AddRobot", robot);
            }

            return RedirectToAction("CompanyRobots", "Robots");
        }

        [HttpPost]
        public ActionResult AddRobotModel(RobotModelViewModel robotModel)
        {
            robotModel.RobotModelSpecializations = new List<RobotModelSpecialization>
            {
                new RobotModelSpecialization
                {
                    SpecializationId = robotModel.SpecializationId,
                    SkillLevel = SkillLevel.High
                }
            };

            var isSuccess = RobotClientService.AddRobotModel(robotModel);

            if (!isSuccess)
            {
                var specializations = SpecializationClientService.GetAllSpecializations();
                robotModel.Specializations = specializations;

                ModelState.AddModelError("AddRobot", "Add robot model failed.");
                return View("AddRobotModel", robotModel);
            }

            return RedirectToAction("AddRobot");
        }

        [HttpPost]
        public ActionResult GetRobotsBySpecialization(string specialization)
        {
            var robots = RobotClientService.GetRobotsBySpecialization(specialization);
            return PartialView("_Robots", robots);
        }

        [HttpPost]
        public ActionResult GetRobotsOnSpecificDate(SearchRobotModel searchRobotModel)
        {
            var robots = RobotClientService.GetRobotsOnSpecificDateRange(searchRobotModel);
            ViewBag.IsSearchView = true;

            return PartialView("_Robots", robots);
        }
    }
}