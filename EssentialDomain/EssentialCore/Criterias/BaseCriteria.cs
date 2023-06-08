using EssentialCore.Interfaces.Criterias;
using EssentialCore.Interfaces.Entities;
using System.Linq.Expressions;

namespace EssentialCore.Criterias
{
    public abstract class BaseCriteria<E, T> : IBaseCriteria<E, T> where E : IBaseEntity<T>
        where T : struct
    {
        protected Expression<Func<E, bool>> _expression;

        public void PorId(T id)
        {
            _expression = x => x.Id.ToString() == id.ToString();
        }

        public Expression<Func<E, bool>> GetExpression() => _expression;
    }
}
