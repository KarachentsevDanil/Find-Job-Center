using System;
using System.Linq.Expressions;

namespace FJB.Domain.Entities.Params
{
    public class FilterParams<T> where T : class
    {
        public Expression<Func<T, bool>> Expression { get; set; }
        public int PageSize { get; set; } = 25;
        public int PageNumber { get; set; } = 1;

        public FilterParams()
        {
            
        }

        public FilterParams(Expression<Func<T, bool>> expression)
        {
            Expression = expression;
        }
    }
}
