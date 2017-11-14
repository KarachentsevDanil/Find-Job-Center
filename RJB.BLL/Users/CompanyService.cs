using FJB.DAL.UnitOfWork.Contracts;
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
    }
}
