using FJB.Domain.Entities.Leases;
using FJB.Domain.Entities.Users;
using System;
using System.Collections.Generic;

namespace FJB.Domain.Entities.Robots
{
    public class Robot
    {
        public int RobotId { get; set; }

        public int CompanyId { get; set; }

        public string Model { get; set; }

        public double PricePerHour { get; set; }

        public string Description { get; set; }

        public DateTime? ReleaseYear { get; set; }

        public byte[] Photo { get; set; }

        public virtual Company Company { get; set; }

        public ICollection<RobotSkill> RobotSkills { get; set; }

        public virtual ICollection<RobotFeedback> RobotFeedbacks { get; set; }

        public virtual ICollection<RobotLease> RobotLeases { get; set; }
    }
}
