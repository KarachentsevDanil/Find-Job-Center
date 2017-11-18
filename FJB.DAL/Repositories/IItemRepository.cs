using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace FJB.DAL.Repositories
{
    public interface IItemRepository<T>
    {
        IEnumerable<T> GetItemsByExpression(Expression<Func<T, bool>> expression);

        T GetItemByExpression(Expression<Func<T, bool>> expression);
    }
}
