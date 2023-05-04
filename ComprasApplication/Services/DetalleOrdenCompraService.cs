using AutoMapper;
using CommonApplication.Interfaces;
using ComprasApplication.Dtos;
using ComprasApplication.Interfaces;
using ComprasCore.Entites;
using ComprasCore.Interfaces.Repositories;
using EssentialCore.Services;

namespace ComprasApplication.Services
{
    public class DetalleOrdenCompraService : BaseService<IDetalleOrdenCompraRepository, DetalleOrdenCompra, long, DetalleOrdenCompraDto>, IDetalleOrdenCompraService
    {
        readonly IOrdenCompraService ordenCompraService;
        readonly IProductoService productoService;
        public DetalleOrdenCompraService(IDetalleOrdenCompraRepository repository, IOrdenCompraService ordenCompraService,
            IProductoService productoService, IMapper mapper) : base(repository, mapper)
        {
            this.ordenCompraService = ordenCompraService;
            this.productoService = productoService;
        }

        public override DetalleOrdenCompraDto Create(DetalleOrdenCompraDto dto, long idUser)
        {
            var ordenCompra = this.ordenCompraService.GetById(dto.IdOrdenCompra) ?? throw new Exception("No se ha seleccionado una orden de compra válida.");
            dto.IdOrdenCompra = ordenCompra.Id.Value;

            var producto = this.productoService.GetById(dto.IdProducto) ?? throw new Exception("No se ha seleccionado un producto válido.");
            dto.IdProducto = producto.Id.Value;

            return base.Create(dto, idUser);
        }
    }
}
