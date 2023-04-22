using AutoMapper;
using RRHHApplication.Dtos;
using RRHHCore.Entities;

namespace RRHHApplication.Mappers
{
    public class ContactoProfile : Profile
    {
        public ContactoProfile()
        {

            CreateMap<Contacto, ContactoDto>();
            CreateMap<ContactoDto, Contacto>()
                .ForMember(dest => dest.FechaCreacion, opt => opt.Ignore())
                .ForMember(dest => dest.FechaUltimaActualizacion, opt => opt.Ignore())
                .ForMember(dest => dest.UsuarioActualizaId, opt => opt.Ignore())
                .ForMember(dest => dest.UsuarioCreaId, opt => opt.Ignore())
                .ForMember(dest => dest.Activo, opt => opt.Ignore());
        }
    }
}
