using CommonCore.Interfaces.Criterias;
using CommonCore.Interfaces.Entities;
using Microsoft.EntityFrameworkCore;

namespace CommonCore.Interfaces.Repositories
{
    public interface IRepository<E, T> 
        where E : IBaseEntity<T>
        where T : struct
    {
        DbContext Context { get; }

        E Create(E entity);
        void Update(E entity);
        void Delete(E entity);
        
        E GetById(T id);
        IList<E> GetAll();

        E GetByCriteria(IBaseCriteria<E, T> criteria);
        IList<E> GetListByCriteria(IBaseCriteria<E, T> criteria);

        void SaveChanges();
        void ClearTracker(bool fullClear = false);
    }
}
