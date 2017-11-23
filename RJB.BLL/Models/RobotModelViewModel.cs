using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using FJB.Domain.Entities.Robots;
using FJB.Domain.Entities.Specializations;

namespace RJB.BLL.Models
{
    public class RobotModelViewModel : RobotModel
    {
        [Required]
        public int SpecializationId { get; set; }

        public IEnumerable<Specialization> Specializations { get; set; }
    }
}
