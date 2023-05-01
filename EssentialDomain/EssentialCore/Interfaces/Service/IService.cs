using AutoMapper;
using EssentialCore.Interfaces.Entities;
using EssentialCore.Interfaces.Repositories;

namespace EssentialCore.Interfaces.Service
{
    /// <summary>
    /// Contrato de servicio de aplicación
    /// </summary>
    /// <typeparam name="R">Interfaz de repositorio de datos que herede de IRepository</typeparam>
    /// <typeparam name="E">Entidad de datos que herede de IBaseRepository</typeparam>
    /// <typeparam name="T">Tipo de datos del ID de la entidad</typeparam>
    /// <typeparam name="D">DTO correspondiente a la entidad</typeparam>
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
