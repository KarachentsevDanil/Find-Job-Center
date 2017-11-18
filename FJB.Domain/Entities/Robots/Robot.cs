using FJB.Domain.Entities.Leases;
using FJB.Domain.Entities.Users;
using System.Collections.Generic;

namespace FJB.Domain.Entities.Robots
{
    public class Robot
    {
        public Robot()
        {
            
        }

        public Robot(Robot robot)
        {
            RobotModelId = robot.RobotModelId;
            CompanyId = robot.CompanyId;
            PricePerHour = robot.PricePerHour;
        }

        public int RobotId { get; set; }

        public int CompanyId { get; set; }

        public int RobotModelId { get; set; }

        public double PricePerHour { get; set; }

        public bool IsDeleted { get; set; }

        public virtual Company Company { get; set; }

        public virtual RobotModel RobotModel { get; set; }

        public virtual ICollection<RobotLease> RobotLeases { get; set; }
    }
}
