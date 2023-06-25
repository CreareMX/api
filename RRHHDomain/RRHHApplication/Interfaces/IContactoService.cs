using CommonCore.Entities.Rrhh;
using EssentialCore.Interfaces.Service;
using RRHHApplication.Dtos;
using RRHHCore.Interfaces.Repositories;

namespace RRHHApplication.Interfaces
{
    public interface IContactoService : IService<IContactoRepository, Contacto, long, ContactoDto>
    {
    }
}
