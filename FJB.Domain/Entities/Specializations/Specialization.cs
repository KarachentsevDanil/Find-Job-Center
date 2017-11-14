using System.Collections.Generic;

namespace FJB.Domain.Entities.Specializations
{
    public class Specialization
    {
        public int SpecializationId { get; set; }

        public string Name { get; set; }

        public ICollection<SubSpecialization> SubSpecializations { get; set; }
    }
}
