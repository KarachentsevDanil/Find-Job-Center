using FJB.Domain.Entities.Robots;

namespace RJF.WebService.Models
{
    public class LeaseViewModel
    {
        public int LeaseId { get; set; }

        public string Feedback { get; set; }

        public Rating Rating { get; set; }
    }
}