using AlmacenApplication.Dtos;
using AlmacenApplication.Interfaces;
using AutoMapper;
using CommonCore.Entities.Catalogs;
using CommonCore.Interfaces.Repositories.Catalogs;
using EssentialCore.Services;

namespace AlmacenApplication.Services
{
    internal class AlmacenService : BaseService<IAlmacenRepository, Almacen, long, AlmacenDto>, IAlmacenService
    {
        private readonly ITipoAlmacenService tipoAlmacenService;
        public AlmacenService(IAlmacenRepository repository, ITipoAlmacenService tipoAlmacenService, IMapper mapper) : base(repository, mapper)
        {
            this.tipoAlmacenService = tipoAlmacenService;
        }

        public override AlmacenDto Create(AlmacenDto dto, long idUser)
        {
            var tipoAlmacen = this.tipoAlmacenService.GetById(dto.IdTipoAlmacen) ?? throw new Exception("No se ha selecionado un tipo de almancén.");
            dto.IdTipoAlmacen = tipoAlmacen.Id.Value;

            return base.Create(dto, idUser);
        }

        public override void Update(AlmacenDto dto, long idUser)
        {
            var almacen = this.Repository.GetById(dto.Id.Value) ?? throw new Exception($"No se ha encontrado el almacen con ID {dto.Id}.");
            var tipoAlmacen = tipoAlmacenService.GetById(dto.IdTipoAlmacen) ?? throw new Exception($"No se encotrado un tipo de almacen con ID {dto.IdTipoAlmacen}.");
            this.Repository.ClearTracker(true);

            almacen.IdTipoAlmacen = tipoAlmacen.Id.Value;
            almacen.Nombre = dto.Nombre;
            almacen.Codigo = dto.Codigo;
            almacen.Descripcion = dto.Descripcion;
            almacen.Update(idUser);

            this.Repository.Update(almacen);
            this.Repository.SaveChanges();
            this.Repository.ClearTracker(true);
        }
    }
}
