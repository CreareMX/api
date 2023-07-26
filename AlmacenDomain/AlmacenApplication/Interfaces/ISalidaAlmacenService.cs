using AlmacenApplication.Dtos;
using CommonCore.Entities.Warehouse;
using CommonCore.Interfaces.Repositories.Warehouse;
using CommonCore.Interfaces.Service;

namespace AlmacenApplication.Interfaces
{
    public interface ISalidaAlmacenService : IService<ISalidaAlmacenRepository, SalidaAlmacen, long, SalidaAlmacenDto>
    {
        void ActualizaEstado(long idEntrada, long idEstado, long idUsuario);
        List<SalidaAlmacenDto> PorAlmacen(long idAlmacen);
    }
}
