using AutoMapper;
using ComprasApplication.Dtos;
using ComprasCore.Entites;

namespace ComprasApplication.Mappers
{
    public class OrdenCompraProfile : Profile
    {
        public OrdenCompraProfile()
        {
            CreateMap<OrdenCompra, OrdenCompraDto>();
            CreateMap<OrdenCompraDto, OrdenCompra>()
                .ForMember(dest => dest.FechaCreacion, opt => opt.Ignore())
                .ForMember(dest => dest.FechaUltimaActualizacion, opt => opt.Ignore())
                .ForMember(dest => dest.UsuarioActualizaId, opt => opt.Ignore())
                .ForMember(dest => dest.UsuarioCreaId, opt => opt.Ignore())
                .ForMember(dest => dest.Activo, opt => opt.Ignore());
        }
    }
}
