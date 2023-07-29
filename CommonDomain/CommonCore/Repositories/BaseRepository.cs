using CommonCore.Entities;
using CommonCore.Interfaces.Criterias;
using CommonCore.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CommonCore.Repositories
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

        public void ClearTracker(bool fullClear = false)
        {
            var entries = (fullClear ? Context.ChangeTracker.Entries() : Context.ChangeTracker.Entries().Where(e => e.Entity.GetType() == typeof(E))).ToList();
            foreach (var entry in entries.Where(e => e.State != EntityState.Detached && e.State != EntityState.Unchanged))
                entry.State = EntityState.Detached;
        }

        public virtual E Create(E entity) => Context.Add(entity).Entity;
        public virtual void Update(E entity) => Context.Update(entity);
        public virtual void Delete(E entity) => Context.Remove(entity);

        public virtual IList<E> GetAll()
        {
            var result = Context.Set<E>().AsNoTracking().Where(e => e.Activo).ToList();
            ClearTracker(true);
            return result;
        }

        public virtual E GetById(T id)
        {
            var result = Context.Set<E>().AsNoTracking().FirstOrDefault(e => e.Id.ToString() == id.ToString() && e.Activo);
            ClearTracker(true);
            return result;
        }

        public void SaveChanges()
        {
            Context.SaveChanges();
            ClearTracker(true);
        }

        public virtual E GetByCriteria(IBaseCriteria<E, T> criteria)
        {
            var result = Context.Set<E>().AsNoTracking().FirstOrDefault(criteria.GetExpression());
            ClearTracker(true);
            return result;
        }

        public virtual IList<E> GetListByCriteria(IBaseCriteria<E, T> criteria)
        {
            var result = Context.Set<E>().AsNoTracking().Where(criteria.GetExpression()).ToList();
            ClearTracker(true);
            return result;
        }
    }
}
