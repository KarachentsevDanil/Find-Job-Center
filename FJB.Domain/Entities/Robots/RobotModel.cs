using System;
using System.Collections.Generic;

namespace FJB.Domain.Entities.Robots
{
    public class RobotModel
    {
        public int RobotModelId { get; set; }

        public string Description { get; set; }

        public DateTime? ReleaseYear { get; set; }

        public byte[] Photo { get; set; }

        public ICollection<Robot> Robots { get; set; }

        public ICollection<RobotModelSpecialization> RobotModelSpecializations { get; set; }

        public virtual ICollection<RobotModelFeedback> RobotModelFeedbacks { get; set; }
    }
}
