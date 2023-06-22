using EssentialCore.Entities;
using EssentialCore.Interfaces.Criterias;
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

        public void ClearTracker(bool fullClear = false)
        {
            var entries = (fullClear ? Context.ChangeTracker.Entries() : Context.ChangeTracker.Entries().Where(e => e.Entity.GetType() == typeof(E))).ToList();
            foreach (var entry in entries.Where(e => e.State != EntityState.Detached && e.State != EntityState.Unchanged))
                entry.State = EntityState.Detached;
        }

        public virtual E Create(E entity) => Context.Add(entity).Entity;
        public virtual void Update(E entity) => Context.Update(entity);
        public virtual void Delete(E entity) => Context.Remove(entity);

        public virtual IList<E> GetAll() => Context.Set<E>().Where(e => e.Activo).ToList();

        public virtual E GetById(T id) => Context.Set<E>().FirstOrDefault(e => e.Id.ToString() == id.ToString() && e.Activo);

        public void SaveChanges() => Context.SaveChanges();

        public E GetByCriteria(IBaseCriteria<E, T> criteria) => Context.Set<E>().FirstOrDefault(criteria.GetExpression());

        public IList<E> GetListByCriteria(IBaseCriteria<E, T> criteria) => Context.Set<E>().Where(criteria.GetExpression()).ToList();
    }
}
