using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using FJB.Domain.Entities.Leases;

namespace FJB.Domain.Entities.Users
{
    public class Client
    {
        public int ClientId { get; set; }

        [Required]
        public string FullName { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
        
        public Role Role { get; set; }

        public DateTime? DateOfBirthday  { get; set; }

        public byte[] Photo { get; set; }

        public bool IsDeleted { get; set; }

        public ICollection<Lease> Leases { get; set; }
    }
}
