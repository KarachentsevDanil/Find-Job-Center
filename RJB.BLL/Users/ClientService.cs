using FJB.DAL.Repositories.Users;
using FJB.DAL.Repositories.Users.Contracts;
using FJB.Domain.Entities.Users;
using RJB.BLL.Users.Contracts;

namespace RJB.BLL.Users
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _clientRepository;

        public ClientService()
        {
            _clientRepository = new ClientRepository();
        }

        public void AddClient(Client client)
        {
            _clientRepository.AddClient(client);
        }

        public void UpdateClient(Client client)
        {
            _clientRepository.UpdateClient(client);
        }

        public bool IsClientExist(Client client)
        {
            return _clientRepository.IsClientExist(client.Username);
        }

        public Client GetClientByUsername(string username)
        {
            return _clientRepository.GetClientByUsername(username);
        }
    }
}
