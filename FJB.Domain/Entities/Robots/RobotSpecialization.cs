using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using FJB.Domain.Entities.Specializations;

namespace FJB.Domain.Entities.Robots
{
    public class RobotModelSpecialization
    {
        [Key]
        [Column(Order = 0)]
        public int RobotModelId { get; set; }

        [Key]
        [Column(Order = 1)]
        public int SpecializationId { get; set; }

        public SkillLevel SkillLevel { get; set; }

        public RobotModel RobotModel { get; set; }

        public Specialization Specialization { get; set; }
    }
}
