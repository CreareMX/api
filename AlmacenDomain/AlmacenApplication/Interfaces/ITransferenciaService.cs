using AlmacenApplication.Dtos;
using CommonCore.Entities.Warehouse;
using CommonCore.Interfaces.Repositories.Warehouse;
using CommonCore.Interfaces.Service;

namespace AlmacenApplication.Interfaces
{
    public interface ITransferenciaService : IService<ITransferenciaRepository, Transferencia, long, TransferenciaDto>
    {
    }
}
