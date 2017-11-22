using System.Linq;
using FJB.DAL.UnitOfWork.Contracts;
using FJB.Domain.Entities.Users;
using RJB.BLL.Users.Contracts;

namespace RJB.BLL.Users
{
    public class CompanyService : ICompanyService
    {
        private readonly IRjbUnitOfWorkBase _unitOfWork;

        public CompanyService(IRjbUnitOfWorkBase unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void AddCompany(Company company)
        {
            _unitOfWork.Companies.Add(company);
            _unitOfWork.Commit();
        }

        public void UpdateCompany(Company company)
        {
            _unitOfWork.Companies.Update(company);
            _unitOfWork.Commit();
        }

        public bool IsCompanyExist(Company company)
        {
            return _unitOfWork.Companies.GetAll().Any(x => x.Email == company.Email || x.Name == company.Name);
        }

        public Company GetCompanyByNameOrEmail(string name)
        {
            return _unitOfWork.Companies.GetItemByExpression(x => x.Email == name);
        }
    }
}
