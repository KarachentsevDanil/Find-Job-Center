using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using FJB.Domain.Entities.Robots;

namespace RJB.BLL.Models
{
    public class RobotViewModel : Robot
    {
        [Required]
        public int Count { get; set; }

        public IEnumerable<RobotModel> RobotModels { get; set; }
    }
}
