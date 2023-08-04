using AlmacenApplication.Dtos.Inventario;
using AlmacenApplication.Interfaces;
using AutoMapper;
using CommonApplication.Interfaces;
using CommonCore.Entities.Warehouse;
using CommonCore.Interfaces.Repositories.Warehouse;
using CommonCore.Services;
using DetalleInventarioApplication.Interfaces;
using InventarioApplication.Interfaces;

namespace DetalleInventarioApplication.Services
{
    internal class DetalleInventarioService : BaseService<IDetalleInventarioRepository, DetalleInventario, long, DetalleInventarioDto>, IDetalleInventarioService
    {
        readonly IProductoService _productoService;
        readonly IUnidadService _unidadService;
        readonly IUsuarioService _usuarioService;
        readonly IRolService _rolService;
        readonly IInventarioService _inventarioService;
        public DetalleInventarioService(IDetalleInventarioRepository repository, IProductoService productoService, IUnidadService unidadService, IMapper mapper, 
            IUsuarioService usuarioService, IRolService rolService, IInventarioService inventarioService) : base(repository, mapper)
        {
            _productoService = productoService;
            _unidadService = unidadService;
            _usuarioService = usuarioService;
            _rolService = rolService;
            _inventarioService = inventarioService;
        }

        public override void Update(DetalleInventarioDto dto, long idUser) 
        {
            ValidaPermiso(idUser);
            base.Update(dto, idUser);
        }

        public override void Delete(long? id, long idUser)
        {
            ValidaPermiso(idUser);
            base.Delete(id, idUser);
        }

        private void ValidaPermiso(long idUser)
        {
            var usuario = _usuarioService.GetById(idUser);
            var rol = _rolService.GetById(usuario.RolId);
            if (!rol.Nombre.Equals("administrador", StringComparison.InvariantCultureIgnoreCase))
                throw new Exception("La accion de actualizacion no está permitida, requiere de un permiso administrativo.");
        }

        protected override void Validaciones(DetalleInventarioDto dto)
        {
            var inventario = _inventarioService.GetById(dto.IdInventario) ?? throw new Exception($"No existe el inventario ID: {dto.IdInventario}");
            if (inventario.FechaFin.HasValue)
                throw new Exception("No se pueden agregar detalles a inventarios cerrados.");

            var producto = _productoService.GetById(dto.IdProducto) ?? throw new Exception($"No existe un producto con ID: {dto.IdProducto}.");
            dto.IdProducto = producto.Id.Value;

            var unidad = _unidadService.GetById(dto.IdUnidad) ?? throw new Exception($"No existe una unidad con ID: {dto.IdUnidad}");
            dto.IdUnidad = unidad.Id.Value;

            if (dto.Cantidad < 0)
                throw new Exception("No se puede capturar una cantidad negativa.");

            if (dto.Fecha > DateTime.Now)
                throw new Exception("No se puede capturar un registro con una fecha mayor a la vigente.");
        }
    }
}
