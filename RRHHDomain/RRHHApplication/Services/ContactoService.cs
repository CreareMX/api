using AutoMapper;
using CommonCore.Entities.Rrhh;
using ContabilidadApplication.Interfaces;
using EssentialCore.Services;
using RRHHApplication.Dtos;
using RRHHApplication.Interfaces;
using RRHHCore.Interfaces.Repositories;

namespace RRHHApplication.Services
{
    public class ContactoService : BaseService<IContactoRepository, Contacto, long, ContactoDto>, IContactoService
    {
        private readonly IPersonaService personaService;

        public ContactoService(IContactoRepository repository, IPersonaService personaService, IMapper mapper) : base(repository, mapper)
        {
            this.personaService = personaService;
        }

        public override ContactoDto Create(ContactoDto dto, long idUser)
        {
            var persona = this.personaService.GetById(dto.IdPersona) ?? throw new Exception("No se ha selecionado una persona para asignarle el contacto.");
            dto.IdPersona = persona.Id.Value;

            return base.Create(dto, idUser);
        }
    }
}
