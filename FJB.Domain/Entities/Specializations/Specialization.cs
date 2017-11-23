using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using FJB.Domain.Entities.Robots;

namespace FJB.Domain.Entities.Specializations
{
    public class Specialization
    {
        public int SpecializationId { get; set; }

        [Required]
        public string Name { get; set; }

        public int? ParentSpecializationId { get; set; }

        public virtual Specialization ParentSpecialization { get; set; }

        public ICollection<Specialization> SubSpecializations { get; set; }
        
        public virtual ICollection<RobotModelSpecialization> RobotModels { get; set; }
    }
}
