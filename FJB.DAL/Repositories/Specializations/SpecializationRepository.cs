using System.Collections.Generic;
using System.Linq;
using FJB.DAL.Context;
using FJB.DAL.Repositories.Specializations.Contracts;
using FJB.Domain.Entities.Specializations;

namespace FJB.DAL.Repositories.Specializations
{
    public class SpecializationRepository : ISpecializationRepository
    {
        private readonly RobotJobFinderDbContext _dbContext;

        public SpecializationRepository()
        {
            _dbContext = new RobotJobFinderDbContext();
        }

        public void AddSpecialization(Specialization specialization)
        {
            _dbContext.Specializations.Add(specialization);
            _dbContext.SaveChanges();
        }

        public List<Specialization> GetRobotSpecializations()
        {
            return _dbContext.Specializations.OrderBy(x => x.Name).ToList();
        }
    }
}
