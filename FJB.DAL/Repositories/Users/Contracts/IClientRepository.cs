using FJB.Domain.Entities.Users;

namespace FJB.DAL.Repositories.Users.Contracts
{
    public interface IClientRepository
    {
        void UpdateClient(Client client);
        void AddClient(Client client);
        Client GetClientByUsername(string username);
        bool IsClientExist(string clientUsername);
    }
}
