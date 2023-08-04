using AutoMapper;
using CommonCore.Entities;
using CommonCore.Interfaces.Repositories;
using CommonCore.Interfaces.Service;

namespace CommonCore.Services
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

        protected virtual void Validaciones(D dto) {
            if (dto == null)
                throw new Exception("No se ha recibido un objeto de transferencia de datos.");
        }

        public virtual D Create(D dto, T idUser)
        {
            Validaciones(dto);

            var entity = Mapper.Map<E>(dto);
            entity.New(idUser);
            entity = Repository.Create(entity);

            Repository.SaveChanges();
            Repository.ClearTracker(true);
            entity = Repository.GetById((T)entity.Id);
            return Mapper.Map<D>(entity);
        }

        public virtual void Delete(T? id, T idUser)
        {
            if (!id.HasValue)
                throw new Exception("No se ha recibido un ID válido.");

            var entity = Repository.GetById(id.Value);
            entity.Deactivate(idUser);

            Repository.SaveChanges();
            Repository.ClearTracker(true);
        }

        public virtual IList<D> GetAll()
        {
            var result = Mapper.Map<List<D>>(Repository.GetAll());
            Repository.ClearTracker(true);
            return result;
        }

        public virtual D GetById(T id)
        {
            var result = Mapper.Map<D>(Repository.GetById(id));
            Repository.ClearTracker(true);
            return result;
        }

        public virtual void Update(D dto, T idUser)
        {
            Validaciones(dto);

            var IdProperty = typeof(D).GetProperty("Id");
            if (IdProperty != null) {
                var entity = Repository.GetById((T)IdProperty.GetValue(dto));
                Repository.ClearTracker(true);

                var dtoProperties = dto.GetType().GetProperties().ToList();
                var properties = entity.GetType().GetProperties().ToList();

                foreach (var pi in properties.Where(dp => dtoProperties.Any(ep => dp.Name.Equals(ep.Name, StringComparison.InvariantCultureIgnoreCase))))
                {
                    var sourceProperty = dtoProperties.FirstOrDefault(p => p.Name.Equals(pi.Name, StringComparison.InvariantCultureIgnoreCase));
                    if (sourceProperty == null) continue;

                    pi.SetValue(entity, sourceProperty.GetValue(dto));
                }
                entity.Update(idUser);

                Repository.Update(entity);
                Repository.SaveChanges();
            }
            Repository.ClearTracker(true);
        }
    }
}
