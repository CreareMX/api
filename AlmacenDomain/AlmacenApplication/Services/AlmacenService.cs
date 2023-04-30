using AlmacenApplication.Dtos;
using AlmacenApplication.Interfaces;
using AlmacenCore.Entities;
using AlmacenCore.Interfaces.Repositories;
using AutoMapper;
using EssentialCore.Services;

namespace AlmacenApplication.Services
{
    internal class AlmacenService : BaseService<IAlmacenRepository, Almacen, long, AlmacenDto>, IAlmacenService
    {
        private readonly ITipoAlmacenRepository tipoAlmacenRepository;
        public AlmacenService(IAlmacenRepository repository, ITipoAlmacenRepository tipoAlmacenRepository, IMapper mapper) : base(repository, mapper)
        {
            this.tipoAlmacenRepository = tipoAlmacenRepository;
        }

        public override AlmacenDto Create(AlmacenDto dto, long idUser)
        {
            var tipoAlmacen = this.tipoAlmacenRepository.GetById(dto.IdTipoAlmacen) ?? throw new Exception("No se ha selecionado un tipo de almancén.");
            dto.IdTipoAlmacen = tipoAlmacen.Id.Value;

            return base.Create(dto, idUser);
        }
    }
}
