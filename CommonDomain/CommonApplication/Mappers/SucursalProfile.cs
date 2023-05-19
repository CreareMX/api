using AutoMapper;
using CommonApplication.Dtos;
using CommonCore.Entities;

namespace CommonApplication.Mappers
{
    public class SucursalProfile : Profile
    {
        public SucursalProfile()
        {

            CreateMap<Sucursal, SucursalDto>();
            CreateMap<SucursalDto, Sucursal>()
                .ForMember(dest => dest.FechaCreacion, opt => opt.Ignore())
                .ForMember(dest => dest.FechaUltimaActualizacion, opt => opt.Ignore())
                .ForMember(dest => dest.UsuarioActualizaId, opt => opt.Ignore())
                .ForMember(dest => dest.UsuarioCreaId, opt => opt.Ignore())
                .ForMember(dest => dest.Activo, opt => opt.Ignore());
        }
    }
}
