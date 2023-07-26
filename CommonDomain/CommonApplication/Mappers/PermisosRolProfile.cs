using AutoMapper;
using CommonApplication.dtos;
using CommonCore.Entities;

namespace CommonApplication.Mappers
{
    public class PermisosRolProfile : Profile
    {
        public PermisosRolProfile()
        {

            CreateMap<PermisosRol, PermisosRolDto>();
            CreateMap<PermisosRolDto, PermisosRol>()
                .ForMember(dest => dest.FechaCreacion, opt => opt.Ignore())
                .ForMember(dest => dest.FechaUltimaActualizacion, opt => opt.Ignore())
                .ForMember(dest => dest.UsuarioActualizaId, opt => opt.Ignore())
                .ForMember(dest => dest.UsuarioCreaId, opt => opt.Ignore())
                .ForMember(dest => dest.Activo, opt => opt.Ignore());
        }
    }
}
