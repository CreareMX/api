using AlmacenApplication.Dtos;
using AlmacenApplication.Interfaces;
using AlmacenCore.Entities;
using AlmacenCore.Interfaces.Repositories;
using AutoMapper;
using CommonCore.Interfaces.Repositories;
using EssentialCore.Services;

namespace AlmacenApplication.Services
{
    internal class SalidaAlmacenService : BaseService<ISalidaAlmacenRepository, SalidaAlmacen, long, SalidaAlmacenDto>, ISalidaAlmacenService
    {
        private readonly IProductoRepository productoRepository;
        private readonly IAlmacenRepository almacenRepository;
        private readonly IUnidadRepository unidadRepository;

        public SalidaAlmacenService(ISalidaAlmacenRepository repository, IProductoRepository productoRepository,
            IAlmacenRepository almacenRepository, IUnidadRepository unidadRepository, IMapper mapper) : base(repository, mapper)
        {
            this.productoRepository = productoRepository;
            this.almacenRepository = almacenRepository;
            this.unidadRepository = unidadRepository;
        }

        public override SalidaAlmacenDto Create(SalidaAlmacenDto dto, long idUser)
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
