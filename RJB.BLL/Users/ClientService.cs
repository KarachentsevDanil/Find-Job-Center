using FJB.DAL.UnitOfWork.Contracts;
using RJB.BLL.Users.Contracts;

namespace RJB.BLL.Users
{
    public class ClientService : IClientService
    {
        private readonly IRjbUnitOfWorkBase _unitOfWork;

        public ClientService(IRjbUnitOfWorkBase unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
    }
}
