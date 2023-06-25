using AlmacenApplication.Dtos;
using AlmacenApplication.Interfaces;
using AutoMapper;
using CommonCore.Entities.Warehouse;
using CommonCore.Interfaces.Repositories.Catalogs;
using CommonCore.Interfaces.Repositories.Warehouse;
using ComprasCore.Interfaces.Repositories;
using EssentialCore.Services;

namespace AlmacenApplication.Services
{
    internal class EntradaAlmacenService : BaseService<IEntradaAlmacenRepository, EntradaAlmacen, long, EntradaAlmacenDto>, IEntradaAlmacenService
    {
        private readonly IProductoRepository productoRepository;
        private readonly IAlmacenRepository almacenRepository;
        private readonly IUnidadRepository unidadRepository;

        public EntradaAlmacenService(IEntradaAlmacenRepository repository, IProductoRepository productoRepository,
            IAlmacenRepository almacenRepository, IUnidadRepository unidadRepository, IMapper mapper) : base(repository, mapper)
        {
            this.productoRepository = productoRepository;
            this.almacenRepository = almacenRepository;
            this.unidadRepository = unidadRepository;
        }

        public override EntradaAlmacenDto Create(EntradaAlmacenDto dto, long idUser)
        {
            var producto = this.productoRepository.GetById(dto.IdProducto) ?? throw new Exception("No se ha selecionado un producto.");
            dto.IdProducto = producto.Id.Value;

            var almacen = this.almacenRepository.GetById(dto.IdAlmacen) ?? throw new Exception("No se ha selecionado un almancén.");
            dto.IdAlmacen = almacen.Id.Value;

            var unidad = this.unidadRepository.GetById(dto.IdUnidad) ?? throw new Exception("No se ha selecionado una unidad de carga.");
            dto.IdUnidad = unidad.Id.Value;

            return base.Create(dto, idUser);
        }
    }
}
