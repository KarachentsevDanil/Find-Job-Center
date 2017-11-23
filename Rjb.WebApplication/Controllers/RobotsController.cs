using System.Runtime.InteropServices;
using System.Web.Mvc;
using FJB.Domain.Entities.Robots;
using HttpClientExtenctions.RequestHelpers;
using Rjb.WebApplication.Models;
using RJB.BLL.Models;

namespace Rjb.WebApplication.Controllers
{
    public class RobotsController : Controller
    {
        public ActionResult AddRobot()
        {
            var robotModels = RobotsRequestHelper.GetRobotsModel();
            return View(robotModels);
        }

        public ActionResult AddRobotModel()
        {
            var specializations = SpecializationsRequestHelper.GetAllSpecializations();
            return View(specializations);
        }

        public ActionResult CompanyRobots()
        {
            var robots = RobotsRequestHelper.GetRobotsByOfCompany(CurrentUser.User.UserId);
            return View(robots);
        }

        [HttpPost]
        public ActionResult AddRobot(RobotViewModel robot)
        {
            var isSuccess = RobotsRequestHelper.AddRobot(robot);

            if (!isSuccess)
            {
                ModelState.AddModelError("AddRobot", "Add robot failed.");
                return RedirectToAction("AddRobot", ModelState);
            }

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public ActionResult AddRobotModel(RobotModel robotModel)
        {
            var isSuccess = RobotsRequestHelper.AddRobotModel(robotModel);

            if (!isSuccess)
            {
                ModelState.AddModelError("AddRobot", "Add robot model failed.");
                return RedirectToAction("AddRobotModel", ModelState);
            }

            return RedirectToAction("AddRobot");
        }

        [HttpPost]
        public ActionResult GetRobotsBySpecialization(string specialization)
        {
            var robots = RobotsRequestHelper.GetRobotsBySpecialization(specialization);
            return PartialView("_Robots", robots);
        }

        [HttpPost]
        public ActionResult GetRobotsOnSpecificDate(SearchRobotModel searchRobotModel)
        {
            var robots = RobotsRequestHelper.GetRobotsOnSpecificDateRange(searchRobotModel);
            return PartialView("_Robots", robots);
        }
    }
}