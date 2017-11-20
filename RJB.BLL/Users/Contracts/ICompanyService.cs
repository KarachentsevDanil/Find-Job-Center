using FJB.Domain.Entities.Users;

namespace RJB.BLL.Users.Contracts
{
    public interface ICompanyService
    {
        void AddCompany(Company company);

        void UpdateCompany(Company company);

        bool IsCompanyExist(Company company);
        
        Company GetCompanyByNameOrEmail(string name);
    }
}
