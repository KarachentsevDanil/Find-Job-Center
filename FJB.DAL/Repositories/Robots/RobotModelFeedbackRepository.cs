using FJB.DAL.Context;
using FJB.DAL.Repositories.Robots.Contracts;
using FJB.Domain.Entities.Robots;

namespace FJB.DAL.Repositories.Robots
{
    public class RobotModelFeedbackRepository : RjbRepository<RobotModelFeedback>, IRobotModelFeedbackRepository
    {
        private RjbDbContext _dbContext;

        public RobotModelFeedbackRepository(RjbDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
