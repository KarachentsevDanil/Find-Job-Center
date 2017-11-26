using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Web.Mvc;
using FJB.Domain.Entities.Robots;
using FJB.Domain.Entities.Specializations;
using HttpClientExtenctions.RequestHelpers;
using Rjb.WebApplication.Models;
using RJB.BLL.Models;

namespace Rjb.WebApplication.Controllers
{

    [AllowAnonymous]
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
                return View("AddRobot");
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
                ModelState.AddModelError("AddRobot", "Add robot model failed.");
                return View("AddRobotModel");
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
            return PartialView("_Robots", robots);
        }
    }
}