using AlmacenApplication.Dtos;
using AlmacenApplication.Interfaces;
using AutoMapper;
using CommonApplication.Interfaces;
using CommonCore.Entities.Catalogs;
using CommonCore.Interfaces.Repositories.Catalogs;
using CommonCore.Services;

namespace AlmacenApplication.Services
{
    internal class AlmacenService : BaseService<IAlmacenRepository, Almacen, long, AlmacenDto>, IAlmacenService
    {
        private readonly ITipoAlmacenService tipoAlmacenService;
        private readonly ISucursalService sucursalService;
        public AlmacenService(IAlmacenRepository repository, ISucursalService sucursalService, ITipoAlmacenService tipoAlmacenService, IMapper mapper) : base(repository, mapper)
        {
            this.tipoAlmacenService = tipoAlmacenService;
            this.sucursalService = sucursalService;
        }

        public override AlmacenDto Create(AlmacenDto dto, long idUser)
        {
            var tipoAlmacen = this.tipoAlmacenService.GetById(dto.IdTipoAlmacen) ?? throw new Exception("No se ha selecionado un tipo de almancén.");
            dto.IdTipoAlmacen = tipoAlmacen.Id.Value;

            return base.Create(dto, idUser);
        }

        public override void Update(AlmacenDto dto, long idUser)
        {
            Validaciones(dto);
            var almacen = this.Repository.GetById(dto.Id.Value) ?? throw new Exception($"No se ha encontrado el almacen con ID {dto.Id}.");

            almacen.Nombre = dto.Nombre;
            almacen.Codigo = dto.Codigo;
            almacen.Descripcion = dto.Descripcion;
            almacen.Update(idUser);

            this.Repository.Update(almacen);
            this.Repository.SaveChanges();
            this.Repository.ClearTracker(true);
        }

        protected override void Validaciones(AlmacenDto dto)
        {
            var tipoAlmacen = tipoAlmacenService.GetById(dto.IdTipoAlmacen) ?? throw new Exception($"No se encotrado un tipo de almacen con ID {dto.IdTipoAlmacen}.");
            dto.IdTipoAlmacen = tipoAlmacen.Id.Value;
            var sucursal = sucursalService.GetById(dto.IdSucursal) ?? throw new Exception($"No se encotrado una sucursal con ID {dto.IdTipoAlmacen}.");
            dto.IdSucursal = sucursal.Id.Value;

            this.Repository.ClearTracker(true);
        }
    }
}
