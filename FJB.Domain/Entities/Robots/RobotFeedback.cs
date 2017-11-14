using System;
using System.Collections.Generic;
using FJB.Domain.Entities.Users;

namespace FJB.Domain.Entities.Robots
{
    public class RobotFeedback
    {
        public int RobotFeedbackId { get; set; }

        public int RobotId { get; set; }

        public int ClientId { get; set; }

        public Rating Rate { get; set; }

        public string Comment { get; set; }

        public DateTime CreatedOn { get; set; }

        public virtual Robot Robot { get; set; }

        public virtual Client Client { get; set; }
    }
}
