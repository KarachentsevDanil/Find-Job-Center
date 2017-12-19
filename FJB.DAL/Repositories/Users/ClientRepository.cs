using System.Data.Entity.Migrations;
using System.Linq;
using FJB.DAL.Context;
using FJB.DAL.Repositories.Users.Contracts;
using FJB.Domain.Entities.Users;

namespace FJB.DAL.Repositories.Users
{
    public class ClientRepository : IClientRepository
    {
        private readonly RobotJobFinderDbContext _dbContext;

        public ClientRepository()
        {
            _dbContext = new RobotJobFinderDbContext();
        }

        public void UpdateClient(Client client)
        {
            _dbContext.Clients.AddOrUpdate(client);
            _dbContext.SaveChanges();
        }

        public void AddClient(Client client)
        {
            _dbContext.Clients.Add(client);
            _dbContext.SaveChanges();
        }

        public Client GetClientByUsername(string username)
        {
            return _dbContext.Clients.FirstOrDefault(x => x.Username == username || x.FullName == username);
        }

        public bool IsClientExist(string clientUsername)
        {
            return _dbContext.Clients.Any(x => x.Username == clientUsername || x.FullName == clientUsername);
        }
    }
}
