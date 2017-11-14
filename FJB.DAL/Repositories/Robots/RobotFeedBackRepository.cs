using FJB.DAL.Context;
using FJB.DAL.Repositories.Robots.Contracts;
using FJB.Domain.Entities.Robots;

namespace FJB.DAL.Repositories.Robots
{
    public class RobotFeedBackRepository : RjbRepository<RobotFeedback>, IRobotFeedbackRepository
    {
        private RjbDbContext _dbContext;

        public RobotFeedBackRepository(RjbDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
