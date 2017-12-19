using FJB.Domain.Entities.Leases;
using FJB.Domain.Entities.Users;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace FJB.Domain.Entities.Robots
{
    [JsonObject(IsReference = true)]
    public class Robot
    {
        public Robot()
        {
            
        }

        public Robot(Robot robot)
        {
            RobotModelId = robot.RobotModelId;
            CompanyId = robot.CompanyId;
            PricePerDay = robot.PricePerDay;
        }

        public int RobotId { get; set; }

        public int CompanyId { get; set; }

        public int RobotModelId { get; set; }

        [Required]
        public double PricePerDay { get; set; }

        public bool IsDeleted { get; set; }

        public bool? IsOnWork { get; set; }

        public virtual Company Company { get; set; }

        public virtual RobotModel RobotModel { get; set; }

        public virtual ICollection<RobotLease> RobotLeases { get; set; }
    }
}
