using FJB.DAL.Repositories.Users;
using FJB.DAL.Repositories.Users.Contracts;
using FJB.Domain.Entities.Users;
using RJB.BLL.Users.Contracts;

namespace RJB.BLL.Users
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository _companyRepository;

        public CompanyService()
        {
            _companyRepository = new CompanyRepository();
        }

        public void AddCompany(Company company)
        {
            _companyRepository.AddCompany(company);
        }

        public void UpdateCompany(Company company)
        {
            _companyRepository.UpdateCompany(company);
        }

        public bool IsCompanyExist(Company company)
        {
            return _companyRepository.IsCompanyExist(company);
        }

        public Company GetCompanyByNameOrEmail(string name)
        {
            return _companyRepository.GetCompanyByNameOrEmail(name);
        }
    }
}
