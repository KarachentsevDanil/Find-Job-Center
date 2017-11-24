using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using FJB.DAL.Context;
using FJB.DAL.Repositories.Users.Contracts;
using FJB.Domain.Entities.Users;

namespace FJB.DAL.Repositories.Users
{
    public class ClientRepository : RjbRepository<Client>, IClientRepository
    {
        private RjbDbContext _dbContext;

        public ClientRepository(RjbDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Client> GetItemsByExpression(Expression<Func<Client, bool>> expression)
        {
            return _dbContext.Clients.Where(expression).AsEnumerable();
        }

        public Client GetItemByExpression(Expression<Func<Client, bool>> expression)
        {
            return _dbContext.Clients.FirstOrDefault(expression);
        }
    }
}
