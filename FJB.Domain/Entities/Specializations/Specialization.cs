using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using FJB.Domain.Entities.Robots;
using Newtonsoft.Json;

namespace FJB.Domain.Entities.Specializations
{
    [JsonObject(IsReference = true)]
    public class Specialization
    {
        public int SpecializationId { get; set; }

        [Required]
        public string Name { get; set; }

        public int? ParentSpecializationId { get; set; }

        public virtual Specialization ParentSpecialization { get; set; }

        public ICollection<Specialization> SubSpecializations { get; set; }
    }
}
