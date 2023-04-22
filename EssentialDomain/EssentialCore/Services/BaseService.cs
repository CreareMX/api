using AutoMapper;
using EssentialCore.Entities;
using EssentialCore.Interfaces.Repositories;
using EssentialCore.Interfaces.Service;

namespace EssentialCore.Services
{
    public abstract class BaseService<R, E, T, D> : IService<R, E, T, D>
        where R : IRepository<E, T>
        where E : BaseEntity<T>
        where T : struct
    {
        public R Repository { get; private set; }
        public IMapper Mapper { get; private set; }
        public BaseService(R repository, IMapper mapper)
        {
            Repository = repository;
            Mapper = mapper;
        }

        public virtual D Create(D dto, T idUser)
        {
            var entity = Mapper.Map<E>(dto);
            entity.New(idUser);
            entity = Repository.Create(entity);

            Repository.SaveChanges();
            Repository.ClearTracker();
            return Mapper.Map<D>(entity);
        }

        public virtual void Delete(T? id, T idUser)
        {
            if (!id.HasValue)
                throw new Exception("No se ha recibido un ID válido.");

            var entity = Repository.GetById(id.Value);
            entity.Deactivate(idUser);

            Repository.SaveChanges();
            Repository.ClearTracker();
        }

        public virtual IList<D> GetAll()
        {
            var result = Mapper.Map<List<D>>(Repository.GetAll());
            Repository.ClearTracker();
            return result;
        }

        public virtual D GetById(T id)
        {
            var result = Mapper.Map<D>(Repository.GetById(id));
            Repository.ClearTracker();
            return result;
        }

        public virtual void Update(D dto, T idUser)
        {
            var IdProperty = typeof(D).GetProperty("Id");
            if (IdProperty != null) {
                var entity = Repository.GetById((T)IdProperty.GetValue(dto));
                Mapper.Map(dto, entity);
                entity.Update(idUser);

                Repository.SaveChanges();
                Repository.ClearTracker();
            }
        }
    }
}
