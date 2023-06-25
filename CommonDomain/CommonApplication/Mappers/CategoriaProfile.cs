using AutoMapper;
using CommonApplication.Dtos;
using CommonCore.Entities.Catalogs;

namespace CommonApplication.Mappers
{
    public class CategoriaProfile : Profile
    {
        public CategoriaProfile()
        {

            CreateMap<Categoria, CategoriaDto>();
            CreateMap<CategoriaDto, Categoria>()
                .ForMember(dest => dest.FechaCreacion, opt => opt.Ignore())
                .ForMember(dest => dest.FechaUltimaActualizacion, opt => opt.Ignore())
                .ForMember(dest => dest.UsuarioActualizaId, opt => opt.Ignore())
                .ForMember(dest => dest.UsuarioCreaId, opt => opt.Ignore())
                .ForMember(dest => dest.Activo, opt => opt.Ignore());
        }
    }
}
