using AlmacenApplication.Dtos;
using AutoMapper;
using CommonCore.Entities.Catalogs;

namespace AlmacenApplication.Mappers
{
    public class AlmacenProfile : Profile
    {
        public AlmacenProfile()
        {

            CreateMap<Almacen, AlmacenDto>();
            CreateMap<AlmacenDto, Almacen>()
                .ForMember(dest => dest.FechaCreacion, opt => opt.Ignore())
                .ForMember(dest => dest.FechaUltimaActualizacion, opt => opt.Ignore())
                .ForMember(dest => dest.UsuarioActualizaId, opt => opt.Ignore())
                .ForMember(dest => dest.UsuarioCreaId, opt => opt.Ignore())
                .ForMember(dest => dest.Activo, opt => opt.Ignore());
        }
    }
}
