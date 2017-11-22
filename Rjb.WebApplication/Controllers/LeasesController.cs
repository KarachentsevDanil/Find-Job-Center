using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FJB.Domain.Entities.Leases;
using FJB.Domain.Entities.Robots;
using HttpClientExtenctions.RequestHelpers;
using Rjb.WebApplication.Models;
using RJB.BLL.Models;

namespace Rjb.WebApplication.Controllers
{
    public class LeasesController : Controller
    {
        public ActionResult AddLease()
        {
            return View();
        }

        public ActionResult EditLease()
        {
            return View();
        }

        public ActionResult MyLeases()
        {
            var customerLease = LeasesRequestHelper.GetLeaseOfClient(CurrentUser.User.UserId);
            return View("Leases", customerLease);
        }

        public ActionResult LeaseDetails(int leaseId)
        {
            var customerLease = LeasesRequestHelper.GetLeaseDetails(leaseId);
            return View(customerLease);
        }

        [HttpPost]
        public ActionResult AddLease(Lease lease)
        {
            var isSuccess = LeasesRequestHelper.CreateLease(lease);

            if (!isSuccess)
            {
                ModelState.AddModelError("AddLease", "Add lease failed.");
                return RedirectToAction("AddLease", ModelState);
            }

            return RedirectToAction("MyLeases");
        }

        [HttpPost]
        public ActionResult CompleateLease(LeaseViewModel lease)
        {
            var isSuccess = LeasesRequestHelper.CompleateLease(lease);

            if (!isSuccess)
            {
                ModelState.AddModelError("AddLease", "Add lease failed.");
                return RedirectToAction("EditLease", ModelState);
            }

            return RedirectToAction("MyLeases");
        }
    }
}