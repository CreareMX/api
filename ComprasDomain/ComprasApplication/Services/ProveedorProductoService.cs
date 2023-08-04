using AutoMapper;
using CommonCore.Entities.Purchases;
using CommonCore.Interfaces.Criterias.Purchases;
using CommonCore.Interfaces.Repositories.Purchases;
using ComprasApplication.Dtos;
using ComprasApplication.Interfaces;
using CommonCore.Services;

namespace ComprasApplication.Services
{
    public class ProveedorProductoService : BaseService<IProveedorProductoRepository, ProveedorProducto, long, ProveedorProductoDto>, IProveedorProductoService
    {
        private readonly IProveedorProductoCriteria _proveedorProductoCriteria;
        public ProveedorProductoService(IProveedorProductoRepository repository, IMapper mapper, IProveedorProductoCriteria proveedorProductoCriteria) : base(repository, mapper)
        {
            _proveedorProductoCriteria = proveedorProductoCriteria;
        }

        public IList<ProveedorProductoDto> GetByProducto(long idProducto)
        {
            if (idProducto <= 0)
                throw new Exception("El id de producto debe ser un número entero mayor a cero.");

            var entities = Repository.GetListByCriteria(_proveedorProductoCriteria.PorProducto(idProducto));
            if (entities == null || entities.Count == 0)
                return null;

            return Mapper.Map<List<ProveedorProductoDto>>(entities);
        }

        public IList<ProveedorProductoDto> GetByProveedor(long idProveedor)
        {
            if (idProveedor <= 0)
                throw new Exception("El id de proveedor debe ser un número entero mayor a cero.");

            var entities = Repository.GetListByCriteria(_proveedorProductoCriteria.PorProveedor(idProveedor));
            if (entities == null || entities.Count == 0)
                return null;

            return Mapper.Map<List<ProveedorProductoDto>>(entities);
        }
    }
}
