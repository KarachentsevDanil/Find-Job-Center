using System;
using System.Collections.Generic;
using FJB.Domain.Entities.Leases;

namespace FJB.Domain.Entities.Users
{
    public class Client
    {
        public int ClientId { get; set; }

        public string FullName { get; set; }

        public DateTime? DateOfBirthday  { get; set; }

        public byte[] Photo { get; set; }

        public bool IsDeleted { get; set; }

        public ICollection<Lease> Leases { get; set; }
    }
}
