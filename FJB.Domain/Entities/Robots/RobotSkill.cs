using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using FJB.Domain.Entities.Specializations;

namespace FJB.Domain.Entities.Robots
{
    public class RobotSkill
    {
        [Key]
        [Column(Order = 0)]
        public int RobotId { get; set; }

        [Key]
        [Column(Order = 1)]
        public int SubSpecializationId { get; set; }

        public Robot Robot { get; set; }

        public SubSpecialization SubSpecialization { get; set; }
    }
}
