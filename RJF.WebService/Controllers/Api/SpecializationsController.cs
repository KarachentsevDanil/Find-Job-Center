using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FJB.Domain.Entities.Specializations;
using RJB.BLL.Specializations.Contracts;

namespace RJF.WebService.Controllers.Api
{
    public class SpecializationsController : ApiController
    {
        private readonly ISpecializationService _specializationService;

        public SpecializationsController(ISpecializationService specializationService)
        {
            _specializationService = specializationService;
        }

        [HttpPost]
        public HttpResponseMessage AddSpecialization([FromBody] Specialization specialization)
        {
            try
            {
                if (specialization.ParentSpecializationId.HasValue)
                {
                    _specializationService.AddSubSpecialization(specialization.ParentSpecializationId.Value, specialization.Name);
                }
                else
                {
                    _specializationService.AddSpecialization(specialization.Name);
                }

                return Request.CreateResponse(HttpStatusCode.Created);
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        public HttpResponseMessage GetAllSpecializations()
        {
            try
            {
                var specializations = _specializationService.GetRootSpecializations();
                return Request.CreateResponse(HttpStatusCode.OK, specializations);
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        public HttpResponseMessage GetSubSpecializations(int parentId)
        {
            try
            {
                var specializations = _specializationService.GetChildSpecializationsByParentId(parentId);
                return Request.CreateResponse(HttpStatusCode.OK, specializations);
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        public HttpResponseMessage GetSpecializations(string name)
        {
            try
            {
                var specializations = _specializationService.GetSpecializationsByName(name);
                return Request.CreateResponse(HttpStatusCode.OK, specializations);
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }
    }
}