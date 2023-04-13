using EssentialCore.Entities;
using EssentialCore.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EssentialCore.Repositories
{
    public abstract class BaseRepository<E, T> : IRepository<E, T>
        where E : BaseEntity<T>
        where T : struct
    {
        public DbContext Context { get; private set; }

        public BaseRepository(DbContext context)
        {
            Context = context;
        }

        public void ClearTracker()
        {
            foreach (var entry in Context.ChangeTracker.Entries().Where(e => e.Entity.GetType() == typeof(E)))
                entry.State = EntityState.Detached;
        }

        public E Create(E entity) => Context.Add(entity).Entity;

        public void Delete(E entity) => Context.Remove(entity);

        public IList<E> GetAll() => Context.Set<E>().ToList();

        public E GetById(T id) => Context.Set<E>().FirstOrDefault(e => e.Id.ToString() == id.ToString());

        public void SaveChanges() => Context.SaveChanges();
    }
}
