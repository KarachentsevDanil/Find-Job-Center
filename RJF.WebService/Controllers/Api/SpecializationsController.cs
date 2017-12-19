using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FJB.Domain.Entities.Specializations;
using RJB.BLL.Specializations;
using RJB.BLL.Specializations.Contracts;

namespace RJF.WebService.Controllers.Api
{
    public class SpecializationsController : ApiController
    {
        private readonly ISpecializationService _specializationService;

        public SpecializationsController()
        {
            _specializationService = new SpecializationService();
        }

        [HttpPost]
        public void AddSpecialization([FromBody] Specialization specialization)
        {
            _specializationService.AddSpecialization(specialization.Name);
        }

        public List<Specialization> GetAllSpecializations()
        {
            var specializations = _specializationService.GetRobotSpecializations();
            return specializations;
        }
    }
}