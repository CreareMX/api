using AutoMapper;
using CommonApplication.Interfaces;
using ContabilidadApplication.Dtos;
using ContabilidadApplication.Interfaces;
using ContabilidadCore.Entities;
using ContabilidadCore.Interfaces.Reporitories;
using EssentialCore.Services;

namespace ContabilidadApplication.Services
{
    public class PersonaService : BaseService<IPersonaRepository, Persona, long, PersonaDto>, IPersonaService
    {
        private readonly ITipoPersonaService tipoPersonaService;
        private readonly IDatosFiscalesService datosFiscalesService;

        public PersonaService(IPersonaRepository repository, ITipoPersonaService tipoPersonaService, 
            IDatosFiscalesService datosFiscalesService, IMapper mapper) : base(repository, mapper)
        {
            this.tipoPersonaService = tipoPersonaService;
            this.datosFiscalesService = datosFiscalesService;
        }

        public override PersonaDto Create(PersonaDto dto, long idUser)
        {
            var tipoPersona = this.tipoPersonaService.GetById(dto.idTipoPersona) ?? throw new Exception("No se ha selecionado un tipo de persona válido.");

            if (tipoPersona.EsPersonaMoral && dto.DatosFiscales == null)
                throw new Exception("Una persona moral debe tener datos fiscales");

            if (dto.DatosFiscales != null && !dto.DatosFiscales.Id.HasValue)
                dto.DatosFiscales = this.datosFiscalesService.Create(dto.DatosFiscales, idUser);

            dto.idDatosFiscales = dto.DatosFiscales?.Id;
            dto.DatosFiscales = null;

            return base.Create(dto, idUser);
        }
    }
}
