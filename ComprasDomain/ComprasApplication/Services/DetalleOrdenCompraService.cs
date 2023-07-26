using AutoMapper;
using CommonApplication.Interfaces;
using CommonCore.Entities.Purchases;
using CommonCore.Interfaces.Criterias.Purchases;
using CommonCore.Interfaces.Repositories.Purchases;
using ComprasApplication.Dtos;
using ComprasApplication.Interfaces;
using CommonCore.Services;

namespace ComprasApplication.Services
{
    public class DetalleOrdenCompraService : BaseService<IDetalleOrdenCompraRepository, DetalleOrdenCompra, long, DetalleOrdenCompraDto>, IDetalleOrdenCompraService
    {
        readonly IOrdenCompraService ordenCompraService;
        readonly IProductoService productoService;
        readonly IDetalleOrdenCompraCriteria detalleOrdenCompraCriteria;

        public DetalleOrdenCompraService(IDetalleOrdenCompraRepository repository, IOrdenCompraService ordenCompraService,
            IProductoService productoService, IMapper mapper, IDetalleOrdenCompraCriteria detalleOrdenCompraCriteria) : base(repository, mapper)
        {
            this.ordenCompraService = ordenCompraService;
            this.productoService = productoService;
            this.detalleOrdenCompraCriteria = detalleOrdenCompraCriteria;
        }

        public override DetalleOrdenCompraDto Create(DetalleOrdenCompraDto dto, long idUser)
        {
            var ordenCompra = this.ordenCompraService.GetById(dto.IdOrdenCompra) ?? throw new Exception("No se ha seleccionado una orden de compra válida.");
            dto.IdOrdenCompra = ordenCompra.Id.Value;

            var producto = this.productoService.GetById(dto.IdProducto) ?? throw new Exception("No se ha seleccionado un producto válido.");
            dto.IdProducto = producto.Id.Value;

            return base.Create(dto, idUser);
        }

        public List<DetalleOrdenCompraDto> GetByOrdenCompra(long idOrdenCompra)
        {
            if (idOrdenCompra <= 0)
                throw new Exception("El identificador de la orden de compra debe ser un número entero mayor a cero.");

            var entities = this.Repository.GetListByCriteria(detalleOrdenCompraCriteria.PorOrdenCompra(idOrdenCompra));
            return Mapper.Map<List<DetalleOrdenCompraDto>>(entities);
        }
    }
}
