using AutoMapper;
using CommonCore.Entities.Rrhh;
using ContabilidadApplication.Interfaces;
using CommonCore.Services;
using RRHHApplication.Dtos;
using RRHHApplication.Interfaces;
using RRHHCore.Interfaces.Repositories;

namespace RRHHApplication.Services
{
    public class DatosEmpleadoService : BaseService<IDatosEmpleadoRepository, DatosEmpleado, long, DatosEmpleadoDto>, IDatosEmpleadoService
    {
        private readonly IPersonaService personaService;

        public DatosEmpleadoService(IDatosEmpleadoRepository repository, IPersonaService personaService, IMapper mapper) : base(repository, mapper)
        {
            this.personaService = personaService;
        }

        public override DatosEmpleadoDto Create(DatosEmpleadoDto dto, long idUser)
        {
            var persona = this.personaService.GetById(dto.IdEmpleado) ?? throw new Exception("No se ha selecionado un empleado para capturar sus datos.");
            dto.IdEmpleado = persona.Id.Value;



            return base.Create(dto, idUser);
        }
    }
}
