using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace FJB.Domain.Entities.Robots
{
    [JsonObject(IsReference = true)]
    public class RobotModel
    {
        public int RobotModelId { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime? ReleaseYear { get; set; }

        public byte[] Photo { get; set; }
        
        public virtual ICollection<Robot> Robots { get; set; }

        public virtual ICollection<RobotModelSpecialization> RobotModelSpecializations { get; set; }

        public virtual ICollection<RobotModelFeedback> RobotModelFeedbacks { get; set; }
    }
}
