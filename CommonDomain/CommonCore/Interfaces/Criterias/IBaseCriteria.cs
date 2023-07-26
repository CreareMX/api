using CommonCore.Interfaces.Entities;
using System.Linq.Expressions;

namespace CommonCore.Interfaces.Criterias
{
    public interface IBaseCriteria<E, T>
        where E : IBaseEntity<T>
        where T : struct
    {
        Expression<Func<E, bool>> GetExpression();
        void PorId(T id);
    }
}