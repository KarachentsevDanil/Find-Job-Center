using FJB.Domain.Entities.Users;

namespace FJB.DAL.Repositories.Users.Contracts
{
    public interface ICompanyRepository
    {
        void AddCompany(Company company);
        Company GetCompanyByNameOrEmail(string name);
        bool IsCompanyExist(Company company);
        void UpdateCompany(Company company);
    }
}
