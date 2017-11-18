using System;
using System.Collections.Generic;
using FJB.Domain.Entities.Robots;

namespace FJB.Domain.Entities.Users
{
    public class Company
    {
        public int CompanyId { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string Description { get; set; }

        public DateTime? YearOfFoundation { get; set; }

        public byte[] Photo { get; set; }

        public bool IsDeleted { get; set; }

        public ICollection<Robot> Robots { get; set; }
    }
}
