using System.Data.Entity.Migrations;
using System.Linq;
using FJB.DAL.Context;
using FJB.DAL.Repositories.Users.Contracts;
using FJB.Domain.Entities.Users;

namespace FJB.DAL.Repositories.Users
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly RobotJobFinderDbContext _dbContext;

        public CompanyRepository()
        {
            _dbContext = new RobotJobFinderDbContext();
        }

        public void AddCompany(Company company)
        {
            _dbContext.Companies.Add(company);
            _dbContext.SaveChanges();
        }

        public Company GetCompanyByNameOrEmail(string name)
        {
          return  _dbContext.Companies.FirstOrDefault(x => x.Name == name || x.Email == name);
        }

        public bool IsCompanyExist(Company company)
        {
            return _dbContext.Companies.Any(x => x.Email == company.Email);
        }

        public void UpdateCompany(Company company)
        {
            _dbContext.Companies.AddOrUpdate(company);
            _dbContext.SaveChanges();
        }
    }
}
