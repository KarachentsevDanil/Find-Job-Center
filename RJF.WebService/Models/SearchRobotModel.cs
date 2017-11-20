using System;

namespace RJF.WebService.Models
{
    public class SearchRobotModel
    {
        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public int SpecializationId { get; set; }
    }
}