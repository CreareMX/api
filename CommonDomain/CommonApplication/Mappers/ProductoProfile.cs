using AutoMapper;
using CommonApplication.Dtos;
using CommonCore.Entities;

namespace CommonApplication.Mappers
{
    public class ProductoProfile : Profile
    {
        public ProductoProfile()
        {

            CreateMap<Producto, ProductoDto>();
            CreateMap<ProductoDto, Producto>()
                .ForMember(dest => dest.FechaCreacion, opt => opt.Ignore())
                .ForMember(dest => dest.FechaUltimaActualizacion, opt => opt.Ignore())
                .ForMember(dest => dest.UsuarioActualizaId, opt => opt.Ignore())
                .ForMember(dest => dest.UsuarioCreaId, opt => opt.Ignore())
                .ForMember(dest => dest.Activo, opt => opt.Ignore());
        }
    }
}
