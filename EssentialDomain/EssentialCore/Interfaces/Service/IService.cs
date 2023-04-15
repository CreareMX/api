using AutoMapper;
using EssentialCore.Interfaces.Entities;
using EssentialCore.Interfaces.Repositories;

namespace EssentialCore.Interfaces.Service
{
    public interface IService<R, E, T, D> 
        where R : IRepository<E, T>
        where E : IBaseEntity<T>
        where T : struct
    {
        R Repository { get; }
        IMapper Mapper { get; }

        D Create(D dto, T idUser);
        void Update(D dto, T idUser);
        void Delete(T? id, T idUser);
        D GetById(T id);
        IList<D> GetAll();
    }
}
