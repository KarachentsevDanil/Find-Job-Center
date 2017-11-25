using System;
using System.Collections.Generic;
using FJB.Domain.Entities.Robots;
using FJB.Domain.Entities.Specializations;

namespace RJB.BLL.Models
{
    public class LeaseViewModel
    {
        public int LeaseId { get; set; }

        public int SpecializationId { get; set; }

        public int CountRobots { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string Feedback { get; set; }

        public Rating Rating { get; set; }

        public IEnumerable<Specialization> Specializations { get; set; }
    }
}