﻿using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using FJB.Domain.Entities.Leases;
using HttpClientExtenctions.RequestHelpers;
using Rjb.WebApplication.Models;
using RJB.BLL.Models;
using WebGrease.Css.Extensions;

namespace Rjb.WebApplication.Controllers
{

    [AllowAnonymous]
    public class LeasesController : Controller
    {
        public ActionResult AddLease()
        {
            var specializations = SpecializationsRequestHelper.GetAllSpecializations();
            var leaseModel = new LeaseViewModel
            {
                Specializations = specializations
            };

            return View(leaseModel);
        }

        public ActionResult EditLease()
        {
            return View();
        }

        public ActionResult MyLeases()
        {
            var customerLease = LeasesRequestHelper.GetLeaseOfClient(CurrentUser.User.UserId);
            customerLease.Collection.ForEach(x =>
            {
                var rentDays = (x.EndDate - x.StartDate).Days;
                x.TotalPrice = rentDays * (int)x.RobotLeases.Sum(r => r.Robot.PricePerDay);
            });

            return View("ClientLeases", customerLease.Collection);
        }

        public ActionResult LeaseDetails(int leaseId)
        {
            var customerLease = LeasesRequestHelper.GetLeaseDetails(leaseId);
            var rentDays = (customerLease.EndDate - customerLease.StartDate).Days;
            customerLease.TotalPrice = rentDays * (int)customerLease.RobotLeases.Sum(r => r.Robot.PricePerDay);

            return View(customerLease);
        }

        [HttpPost]
        public ActionResult AddLease(LeaseViewModel leaseModel)
        {
            var searchRobotsModel = new SearchRobotModel
            {
                SpecializationId = leaseModel.SpecializationId,
                StartDate = leaseModel.StartDate,
                EndDate = leaseModel.EndDate
            };

            var availableRobots = RobotsRequestHelper.GetRobotsOnSpecificDateRange(searchRobotsModel)
                .Take(leaseModel.CountRobots)
                .ToList();

            var lease = new Lease
            {
                ClientId = CurrentUser.User.UserId,
                StartDate = leaseModel.StartDate,
                EndDate = leaseModel.EndDate,
                RobotLeases = new List<RobotLease>(leaseModel.CountRobots)
            };

            availableRobots.ForEach(x => lease.RobotLeases.Add(new RobotLease
            {
                RobotId = x.RobotId
            }));

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