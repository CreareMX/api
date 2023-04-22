using AutoMapper;
using ContabilidadApplication.Interfaces;
using EssentialCore.Services;
using RRHHApplication.Dtos;
using RRHHApplication.Interfaces;
using RRHHCore.Entities;
using RRHHCore.Interfaces.Repositories;

namespace RRHHApplication.Services
{
    public class PuestoService : BaseService<IPuestoRepository, Puesto, long, PuestoDto>, IPuestoService
    {
        private readonly IPersonaService personaService;

        public PuestoService(IPuestoRepository repository, IPersonaService personaService, IMapper mapper) : base(repository, mapper)
        {
            this.personaService = personaService;
        }

        public override PuestoDto Create(PuestoDto dto, long idUser)
        {
            return base.Create(dto, idUser);
        }
    }
}
