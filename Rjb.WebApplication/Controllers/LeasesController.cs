using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using FJB.Domain.Entities.Leases;
using HttpClientExtenctions.RequestHelpers;
using Rjb.WebApplication.Attributes;
using Rjb.WebApplication.Models;
using RJB.BLL.Models;
using WebGrease.Css.Extensions;

namespace Rjb.WebApplication.Controllers
{
    [Authorization]
    public class LeasesController : Controller
    {
        public ActionResult AddLease()
        {
            var specializations = HttpSpecializationService.GetAllSpecializations();
            var leaseModel = new LeaseViewModel
            {
                Specializations = specializations
            };

            return View(leaseModel);
        }

        public ActionResult EditLease(int leaseId)
        {
            var lease = HttpLeaseService.GetLeaseDetails(leaseId);
            return View(lease);
        }

        public ActionResult MyLeases()
        {
            var customerLease = HttpLeaseService.GetLeaseOfClient(CurrentUser.User.UserId);

            return View("ClientLeases", customerLease);
        }

        public ActionResult LeaseDetails(int leaseId)
        {
            var customerLease = HttpLeaseService.GetLeaseDetails(leaseId);
            var rentDays = (customerLease.EndDate - customerLease.StartDate).Days;
            customerLease.TotalPrice = rentDays * (int)customerLease.RobotLeases.Sum(r => r.Robot.PricePerDay);

            return View(customerLease);
        }

        [HttpPost]
        public ActionResult AddLease(LeaseViewModel leaseModel)
        {
            var lease = new Lease
            {
                ClientId = CurrentUser.User.UserId,
                StartDate = leaseModel.StartDate,
                EndDate = leaseModel.EndDate,
                RobotLeases = new List<RobotLease>(leaseModel.RobotIds.Length)
            };
            
            leaseModel.RobotIds.ForEach(x => lease.RobotLeases.Add(new RobotLease
            {
                RobotId = x
            }));

            var isSuccess = HttpLeaseService.CreateLease(lease);

            if (!isSuccess)
            {
                ModelState.AddModelError("AddLease", "Add lease failed.");
                var specializations = HttpSpecializationService.GetAllSpecializations();
                leaseModel.Specializations = specializations;

                return View("AddLease", leaseModel);
            }

            return Json(string.Empty);
        }

        [HttpPost]
        public ActionResult CompleateLease(Lease lease)
        {
            var isSuccess = HttpLeaseService.CompleateLease(lease);

            if (!isSuccess)
            {
                ModelState.AddModelError("AddLease", "Add lease failed.");
                return View("EditLease", lease);
            }

            return RedirectToAction("MyLeases");
        }
    }
}