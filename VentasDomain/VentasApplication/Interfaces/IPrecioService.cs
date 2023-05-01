using EssentialCore.Interfaces.Service;
using VentasApplication.Dtos;
using VentasCore.Entities;
using VentasCore.Interfaces.Repositories;

namespace VentasApplication.Interfaces
{
    public interface IPrecioService : IService<IPrecioRepository, Precio,long, PrecioDto>
    {
    }
}
