using AlmacenApplication.Dtos;
using CommonCore.Entities.Warehouse;
using CommonCore.Interfaces.Repositories.Warehouse;
using CommonCore.Interfaces.Service;

namespace AlmacenApplication.Interfaces
{
    public interface IEntradaAlmacenService : IService<IEntradaAlmacenRepository, EntradaAlmacen, long, EntradaAlmacenDto>
    {
        void ActualizaEstado(long idEntrada, long idEstado, long idUsuario);
        List<EntradaAlmacenDto> PorAlmacen(long idAlmacen);
    }
}
