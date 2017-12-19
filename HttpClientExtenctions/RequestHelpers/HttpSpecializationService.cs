using System;
using System.Collections.Generic;
using System.Linq;
using FJB.Domain.Entities.Specializations;
using HttpClientExtenctions.Helpers;

namespace HttpClientExtenctions.RequestHelpers
{
    public static class HttpSpecializationService
    {
        public static bool AddSpecialization(Specialization specialization)
        {
            try
            {
                HttpClientHelper.PostData(specialization, string.Concat(Constants.SpecializationUrl, "AddSpecialization"));
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static IEnumerable<Specialization> GetAllSpecializations()
        {
            var specializations = HttpClientHelper.GetResult<List<Specialization>>(string.Concat(Constants.SpecializationUrl, "GetAllSpecializations"));
            return specializations;
        }
    }
}
