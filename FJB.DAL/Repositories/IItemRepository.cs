using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using FJB.Domain.Entities.Params;

namespace FJB.DAL.Repositories
{
    public interface IItemRepository<T> where T : class
    {
        IEnumerable<T> GetItemsByExpression(FilterParams<T> filterParams);

        IEnumerable<T> GetItemsByExpression(FilterParams<T> filterParams, out int totalCount);

        T GetItemByExpression(Expression<Func<T, bool>> expression);
    }
}
