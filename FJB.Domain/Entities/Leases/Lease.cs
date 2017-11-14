using System;
using System.Collections.Generic;
using FJB.Domain.Entities.Robots;
using FJB.Domain.Entities.Users;

namespace FJB.Domain.Entities.Leases
{
    public class Lease
    {
        public int LeaseId { get; set; }
        
        public int ClientId { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public bool IsLeaseEnd { get; set; }

        public string Feedback { get; set; }

        public Rating Rating { get; set; }

        public LeaseStatus Status { get; set; }

        public virtual Client Client { get; set; }

        public virtual ICollection<RobotLease> RobotLeases { get; set; }
    }
}
