using System;
using System.Collections.Generic;
using FJB.Domain.Entities.Robots;
using FJB.Domain.Entities.Users;
using Newtonsoft.Json;

namespace FJB.Domain.Entities.Leases
{
    [JsonObject(IsReference = true)]
    public class Lease
    {
        public int LeaseId { get; set; }
        
        public int ClientId { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string Feedback { get; set; }

        public Rating? Rating { get; set; }

        public LeaseStatus Status { get; set; }

        public bool IsDeleted { get; set; }

        public virtual Client Client { get; set; }

        public virtual ICollection<RobotLease> RobotLeases { get; set; }
    }
}
