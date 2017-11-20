using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using FJB.DAL.Context;
using FJB.DAL.Repositories.Users.Contracts;
using FJB.Domain.Entities.Users;

namespace FJB.DAL.Repositories.Users
{
    public class CompanyRepository : RjbRepository<Company>, ICompanyRepository
    {
        private RjbDbContext _dbContext;

        public CompanyRepository(RjbDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Company> GetItemsByExpression(Expression<Func<Company, bool>> expression)
        {
            return _dbContext.Companies.Where(expression).AsEnumerable();
        }

        public Company GetItemByExpression(Expression<Func<Company, bool>> expression)
        {
            return _dbContext.Companies.FirstOrDefault(expression);
        }
    }
}
