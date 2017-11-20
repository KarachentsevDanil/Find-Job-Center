using FJB.Domain.Entities.Users;

namespace RJB.BLL.Users.Contracts
{
    public interface IClientService
    {
        void AddClient(Client client);

        void UpdateClient(Client client);

        bool IsClientExist(Client client);

        bool IsPasswordCorrect(Client client);
    }
}
