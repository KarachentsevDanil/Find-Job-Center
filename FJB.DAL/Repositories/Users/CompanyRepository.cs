using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using FJB.DAL.Context;
using FJB.DAL.Repositories.Users.Contracts;
using FJB.Domain.Entities.Params;
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

        public IEnumerable<Company> GetItemsByExpression(FilterParams<Company> filterParams)
        {
            return _dbContext.Companies.Where(filterParams.Expression).AsEnumerable();
        }

        public IEnumerable<Company> GetItemsByExpression(FilterParams<Company> filterParams, out int totalCount)
        {
            var companies = _dbContext.Companies.Where(filterParams.Expression);
            totalCount = companies.Count();

            return companies
                .OrderByDescending(x => x.CompanyId)
                .Skip(filterParams.PageSize * (filterParams.PageNumber - 1))
                .Take(filterParams.PageSize)
                .ToList();
        }

        public Company GetItemByExpression(Expression<Func<Company, bool>> expression)
        {
            return _dbContext.Companies.FirstOrDefault(expression);
        }
    }
}
