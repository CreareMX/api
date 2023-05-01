using AutoMapper;
using CommonCore.Interfaces.Repositories;
using EssentialCore.Services;
using VentasApplication.Dtos;
using VentasApplication.Interfaces;
using VentasCore.Entities;
using VentasCore.Interfaces.Repositories;

namespace VentasApplication.Services
{
    public class PrecioService : BaseService<IPrecioRepository, Precio, long, PrecioDto>, IPrecioService
    {
        private readonly IProductoRepository productoRepository;
        public PrecioService(IPrecioRepository repository, IProductoRepository productoRepository, IMapper mapper) : base(repository, mapper)
        {
            this.productoRepository = productoRepository;
        }

        public override PrecioDto Create(PrecioDto dto, long idUser)
        {
            var producto = this.productoRepository.GetById(dto.IdProducto) ?? throw new Exception("No se ha selecionado un producto para la asignación del precio.");
            dto.IdProducto = producto.Id.Value;

            return base.Create(dto, idUser);
        }
    }
}
