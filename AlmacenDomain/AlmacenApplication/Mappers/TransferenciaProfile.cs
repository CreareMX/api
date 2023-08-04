using AutoMapper;
using CommonCore.Entities.Warehouse;
using AlmacenApplication.Dtos;

namespace AlmacenApplication.Mappers
{
    public class TransferenciaProfile : Profile
    {
        public TransferenciaProfile()
        {

            CreateMap<Transferencia, TransferenciaDto>();
            CreateMap<TransferenciaDto, Transferencia>()
                .ForMember(dest => dest.FechaCreacion, opt => opt.Ignore())
                .ForMember(dest => dest.FechaUltimaActualizacion, opt => opt.Ignore())
                .ForMember(dest => dest.UsuarioActualizaId, opt => opt.Ignore())
                .ForMember(dest => dest.UsuarioCreaId, opt => opt.Ignore())
                .ForMember(dest => dest.Activo, opt => opt.Ignore());
        }
    }
}
