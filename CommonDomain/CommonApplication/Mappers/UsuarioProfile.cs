using AutoMapper;
using CommonApplication.Dtos;
using CommonCore.Entities;

namespace CommonApplication.Mappers
{
    public class UsuarioProfile : Profile
    {
        public UsuarioProfile()
        {

            CreateMap<Usuario, UsuarioDto>();
            CreateMap<UsuarioDto, Usuario>()
                .ForMember(dest => dest.CreationDate, opt => opt.Ignore())
                .ForMember(dest => dest.LastUpdateDate, opt => opt.Ignore())
                .ForMember(dest => dest.LastUpdateUser, opt => opt.Ignore())
                .ForMember(dest => dest.CreationUser, opt => opt.Ignore())
                .ForMember(dest => dest.IsActive, opt => opt.Ignore());
        }
    }
}
