using AutoMapper;
using CommonCore.Entities.Purchases;
using ComprasApplication.Dtos;

namespace ComprasApplication.Mappers
{
    public class CostoProfile : Profile
    {
        public CostoProfile()
        {
            CreateMap<Costo, CostoDto>();
            CreateMap<CostoDto, Costo>()
                .ForMember(dest => dest.FechaCreacion, opt => opt.Ignore())
                .ForMember(dest => dest.FechaUltimaActualizacion, opt => opt.Ignore())
                .ForMember(dest => dest.UsuarioActualizaId, opt => opt.Ignore())
                .ForMember(dest => dest.UsuarioCreaId, opt => opt.Ignore())
                .ForMember(dest => dest.Activo, opt => opt.Ignore());
        }
    }
}
