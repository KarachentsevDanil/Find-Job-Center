using FJB.DAL.Context;
using FJB.DAL.Repositories.Robots.Contracts;
using FJB.Domain.Entities.Robots;

namespace FJB.DAL.Repositories.Robots
{
    public class RobotRepository: RjbRepository<Robot> , IRobotRepository
    {
        private RjbDbContext _dbContext;

        public RobotRepository(RjbDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
