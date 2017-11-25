using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using FJB.Domain.Entities.Robots;
using Newtonsoft.Json;

namespace FJB.Domain.Entities.Users
{
    [JsonObject(IsReference = true)]
    public class Company
    {
        public int CompanyId { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Name { get; set; }

        public string Address { get; set; }

        public string Description { get; set; }

        public DateTime? YearOfFoundation { get; set; }

        public byte[] Photo { get; set; }

        public bool IsDeleted { get; set; }

        public ICollection<Robot> Robots { get; set; }
    }
}
