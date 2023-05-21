using EssentialCore.Interfaces.Entities;
using System.Linq.Expressions;

namespace EssentialCore.Interfaces.Criterias
{
    public interface IBaseCriteria<E, T>
        where E : IBaseEntity<T>
        where T : struct
    {
        Expression<Func<E, bool>> GetExpression();
        void PorId(T id);
    }
}