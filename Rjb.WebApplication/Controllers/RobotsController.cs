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
            var robotModels = HttpRobotService.GetRobotsModel();
            var robotModel = new RobotViewModel()
            {
                RobotModels = robotModels
            };

            return View(robotModel);
        }

        public ActionResult AddSpecialization()
        {
            return View();
        }

        public ActionResult AddRobotModel()
        {
            var specializations = HttpSpecializationService.GetAllSpecializations();
            var robotModel = new RobotModelViewModel
            {
                Specializations = specializations
            };
            return View(robotModel);
        }

        public ActionResult CompanyRobots()
        {
            var robots = HttpRobotService.GetRobotsByOfCompany(CurrentUser.User.UserId);
            return View(robots);
        }

        public ActionResult RobotDetails(int robotId)
        {
            var robot = HttpRobotService.GetRobotById(robotId);
            return View(robot);
        }

        [HttpPost]
        public ActionResult AddRobot(RobotViewModel robot)
        {
            var isSuccess = HttpRobotService.AddRobot(robot);

            if (!isSuccess)
            {
                ModelState.AddModelError("AddRobot", "Add robot failed.");
                var robotModels = HttpRobotService.GetRobotsModel();
                robot.RobotModels = robotModels;

                return View("AddRobot", robot);
            }

            return RedirectToAction("CompanyRobots", "Robots");
        }

        [HttpPost]
        public ActionResult AddSpecialization(Specialization specialization)
        {
            var isSuccess = HttpSpecializationService.AddSpecialization(specialization);

            if (!isSuccess)
            {
                ModelState.AddModelError("AddSpecialization", "Add specialization failed.");
                return View("AddSpecialization", specialization);
            }

            return RedirectToAction("AddRobotModel", "Robots");
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

            var isSuccess = HttpRobotService.AddRobotModel(robotModel);

            if (!isSuccess)
            {
                var specializations = HttpSpecializationService.GetAllSpecializations();
                robotModel.Specializations = specializations;

                ModelState.AddModelError("AddRobot", "Add robot model failed.");
                return View("AddRobotModel", robotModel);
            }

            return RedirectToAction("AddRobot");
        }

        [HttpPost]
        public ActionResult GetRobotsOnSpecificDate(SearchRobotModel searchRobotModel)
        {
            var robots = HttpRobotService.GetRobotsOnSpecificDateRange(searchRobotModel);
            ViewBag.IsSearchView = true;

            return PartialView("_Robots", robots);
        }
    }
}