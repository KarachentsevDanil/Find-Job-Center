using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FJB.Domain.Entities.Leases;
using FJB.Domain.Entities.Robots;
using RJB.BLL.Leases;
using RJB.BLL.Leases.Contracts;
using RJB.BLL.Models;
using RJB.BLL.Robots;
using RJB.BLL.Robots.Contracts;
using RJF.WebService.Attributes;

namespace RJF.WebService.Controllers.Api
{
    [BasicAuthentication(true)]
    public class LeaseController : ApiController
    {
        private readonly ILeaseService _leaseService;
        private readonly IRobotService _robotService;

        public LeaseController()
        {
            _robotService = new RobotService();
            _leaseService = new LeaseService();
        }

        [HttpPost]
        public void CreateLease([FromBody] Lease lease)
        {
            _leaseService.AddLease(lease);
        }

        [HttpPost]
        public void CompleateLease([FromBody] Lease leaseModel)
        {
            var lease = _leaseService.GetLeaseDetailById(leaseModel.LeaseId);

            lease.Feedback = leaseModel.Feedback;
            lease.Rating = leaseModel.Rating;
            lease.Status = LeaseStatus.Finished;

            _leaseService.UpdateLease(lease);
        }

        [HttpPost]
        public List<Robot> GetRobotsOnSpecificDateRange([FromBody] SearchRobotModel model)
        {
            var robots = _robotService.GetAllAvailableRobots(model.StartDate, model.EndDate, model.SpecializationId);
            return robots;
        }

        public Lease GetLeaseDetails(int leaseId)
        {
            var lease = _leaseService.GetLeaseDetailById(leaseId);
            return lease;
        }

        public List<Lease> GetLeaseOfClient(int clientId)
        {
            var lease = _leaseService.GetLeasesOfClient(clientId);
            return lease;
        }
    }
}