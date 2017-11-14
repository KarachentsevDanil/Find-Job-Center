using System.Collections.Generic;
using FJB.Domain.Entities.Robots;

namespace FJB.Domain.Entities.Specializations
{
    public class SubSpecialization
    {
        public int SubSpecializationId { get; set; }

        public int SpecializationId { get; set; }

        public string Name { get; set; }

        public SkillLevel SkillLevel { get; set; }

        public virtual Specialization Specialization { get; set; }

        public virtual ICollection<RobotSkill> Robots { get; set; }
    }
}
