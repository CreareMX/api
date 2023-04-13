using EssentialCore.Interfaces.Entities;
using Microsoft.EntityFrameworkCore;

namespace EssentialCore.Interfaces.Repositories
{
    public interface IRepository<E, T> 
        where E : IBaseEntity<T>
        where T : struct
    {
        DbContext Context { get; }

        E Create(E entity);
        void Delete(E entity);
        E GetById(T id);
        IList<E> GetAll();


        void SaveChanges();
        void ClearTracker();
    }
}
