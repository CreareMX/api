using AutoMapper;
using CommonApplication.Interfaces;
using CommonCore.Entities.Catalogs;
using CommonCore.Interfaces.Repositories.Catalogs;
using ContabilidadApplication.Dtos;
using ContabilidadApplication.Interfaces;
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
            var tipoPersona = this.tipoPersonaService.GetById(dto.IdTipoPersona) ?? throw new Exception("No se ha selecionado un tipo de persona válido.");

            if (tipoPersona.EsPersonaMoral && dto.DatosFiscales == null)
                throw new Exception("Una persona moral debe tener datos fiscales");

            var entity = Mapper.Map<Persona>(dto);

            if (dto.DatosFiscales != null && (!dto.DatosFiscales.Id.HasValue || dto.DatosFiscales.Id.Value == 0))
                entity.DatosFiscales.New(idUser);

            entity.New(idUser);
            entity = Repository.Create(entity);

            Repository.SaveChanges();
            Repository.ClearTracker();
            return Mapper.Map<PersonaDto>(entity);
        }

        public override void Update(PersonaDto dto, long idUser)
        {
            var tipoPersona = this.tipoPersonaService.GetById(dto.IdTipoPersona) ?? throw new Exception("No se ha selecionado un tipo de persona válido.");
            var persona = this.Repository.GetById(dto.Id.Value) ?? throw new Exception("No se ha selecionado el registro de la personas que desea actualizar.");
            Repository.ClearTracker(true);

            if (tipoPersona.EsPersonaMoral && dto.DatosFiscales == null)
                throw new Exception("Una persona moral debe tener datos fiscales");

            persona.Email = dto.Email;
            persona.IdDatosFiscales = dto.IdDatosFiscales;
            persona.IdTipoPersona = dto.IdTipoPersona;
            persona.Nombre = dto.Nombre;
            persona.SitioWeb = dto.SitioWeb;
            persona.Telefono = dto.Telefono;
                        
            persona.Update(idUser);
            persona.DatosFiscales?.Update(idUser);

            Repository.Update(persona);
            Repository.SaveChanges();
            Repository.ClearTracker(true);
        }
    }
}
