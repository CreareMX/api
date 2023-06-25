using AutoMapper;
using CommonCore.Entities.Rrhh;
using ContabilidadApplication.Interfaces;
using EssentialCore.Services;
using RRHHApplication.Dtos;
using RRHHApplication.Interfaces;
using RRHHCore.Interfaces.Repositories;

namespace RRHHApplication.Services
{
    public class DepartamentoService : BaseService<IDepartamentoRepository, Departamento, long, DepartamentoDto>, IDepartamentoService
    {
        private readonly IPersonaService personaService;

        public DepartamentoService(IDepartamentoRepository repository, IPersonaService personaService, IMapper mapper) : base(repository, mapper)
        {
            this.personaService = personaService;
        }

        public override DepartamentoDto Create(DepartamentoDto dto, long idUser)
        {
            return base.Create(dto, idUser);
        }
    }
}
