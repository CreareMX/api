﻿using AlmacenApplication.Dtos;
using AutoMapper;
using CommonCore.Entities.Catalogs;

namespace AlmacenApplication.Mappers
{
    public class ConceptoProfile : Profile
    {
        public ConceptoProfile()
        {

            CreateMap<Concepto, ConceptoDto>();
            CreateMap<ConceptoDto, Concepto>()
                .ForMember(dest => dest.FechaCreacion, opt => opt.Ignore())
                .ForMember(dest => dest.FechaUltimaActualizacion, opt => opt.Ignore())
                .ForMember(dest => dest.UsuarioActualizaId, opt => opt.Ignore())
                .ForMember(dest => dest.UsuarioCreaId, opt => opt.Ignore())
                .ForMember(dest => dest.Activo, opt => opt.Ignore());
        }
    }
}