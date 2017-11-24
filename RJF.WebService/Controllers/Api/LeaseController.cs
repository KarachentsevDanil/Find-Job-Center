using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FJB.Domain.Entities.Leases;
using RJB.BLL.Leases.Contracts;
using RJB.BLL.Models;

namespace RJF.WebService.Controllers.Api
{
    public class LeaseController : ApiController
    {
        private readonly ILeaseService _leaseService;

        public LeaseController(ILeaseService leaseService)
        {
            _leaseService = leaseService;
        }

        [System.Web.Mvc.HttpPost]
        public HttpResponseMessage CreateLease([FromBody] Lease lease)
        {
            try
            {
                _leaseService.AddLease(lease);
                return Request.CreateResponse(HttpStatusCode.Created);
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [System.Web.Mvc.HttpPost]
        public HttpResponseMessage CompleateLease([FromBody] LeaseViewModel leaseModel)
        {
            try
            {
                var lease = _leaseService.GetLeaseDetailById(leaseModel.LeaseId);
                lease.Feedback = leaseModel.Feedback;
                lease.Rating = leaseModel.Rating;
                lease.Status = LeaseStatus.Finished;
                _leaseService.UpdateLease(lease);

                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }
        
        public HttpResponseMessage GetLeaseDetails(int leaseId)
        {
            try
            {
                var lease = _leaseService.GetLeaseDetailById(leaseId);
                return Request.CreateResponse(HttpStatusCode.OK, lease);
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        public HttpResponseMessage GetLeaseOfClient(int clientId)
        {
            try
            {
                int totalCount;
                var lease = _leaseService.GetLeasesOfClient(clientId, out totalCount);
                var result = new CollectionResult<Lease>
                {
                    Collection = lease,
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