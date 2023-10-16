using CommonCore.Entities.Sales;
using CommonCore.Interfaces.Repositories.Sales;
using CommonCore.Interfaces.Service;
using VentasApplication.Dtos;

namespace VentasApplication.Interfaces
{
    public interface IVentaService : IService<IVentaRepository, Venta, long, VentaDto>
    {
    }
}
