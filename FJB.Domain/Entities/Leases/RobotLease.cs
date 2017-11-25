using FJB.Domain.Entities.Robots;
using Newtonsoft.Json;

namespace FJB.Domain.Entities.Leases
{
    [JsonObject(IsReference = true)]
    public class RobotLease
    {
        public int RobotLeaseId { get; set; }

        public int RobotId { get; set; }

        public int LeaseId { get; set; }

        public virtual Robot Robot { get; set; }

        public virtual Lease Lease { get; set; }
    }
}
