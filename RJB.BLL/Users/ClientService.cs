using FJB.DAL.UnitOfWork.Contracts;
using FJB.Domain.Entities.Users;
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

        public void AddClient(Client client)
        {
            _unitOfWork.Clients.Add(client);
            _unitOfWork.Commit();
        }

        public void UpdateClient(Client client)
        {
            _unitOfWork.Clients.Update(client);
            _unitOfWork.Commit();
        }
    }
}
