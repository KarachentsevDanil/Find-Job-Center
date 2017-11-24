using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using FJB.DAL.Context;
using FJB.DAL.Repositories.Users.Contracts;
using FJB.Domain.Entities.Params;
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

        public IEnumerable<Client> GetItemsByExpression(FilterParams<Client> filterParams)
        {
            return _dbContext.Clients.Where(filterParams.Expression).AsEnumerable();
        }

        public IEnumerable<Client> GetItemsByExpression(FilterParams<Client> filterParams, out int totalCount)
        {
            var clients = _dbContext.Clients.Where(filterParams.Expression);
            totalCount = clients.Count();

            return clients
                .Skip(filterParams.PageSize * (filterParams.PageNumber - 1))
                .Take(filterParams.PageSize)
                .AsEnumerable();
        }

        public Client GetItemByExpression(Expression<Func<Client, bool>> expression)
        {
            return _dbContext.Clients.FirstOrDefault(expression);
        }
    }
}
