using AutoMapper;
using CommonApplication.Interfaces;
using ComprasApplication.Dtos;
using ComprasApplication.Interfaces;
using ComprasCore.Entites;
using ComprasCore.Interfaces.Repositories;
using ContabilidadApplication.Interfaces;
using EssentialCore.Services;

namespace ComprasApplication.Services
{
    public class OrdenCompraService : BaseService<IOrdenCompraRepository, OrdenCompra, long, OrdenCompraDto>, IOrdenCompraService
    {
        readonly IPersonaService personaService;
        readonly IEstadoService estadoService;
        readonly ISucursalService sucursalService;

        public OrdenCompraService(IOrdenCompraRepository repository,
            IPersonaService personaService, IEstadoService estadoService, 
            ISucursalService sucursalService, IMapper mapper) : base(repository, mapper)
        {
            this.personaService = personaService;
            this.estadoService = estadoService;
            this.sucursalService = sucursalService;
        }

        public override OrdenCompraDto Create(OrdenCompraDto dto, long idUser)
        {
            var cliente = this.personaService.GetById(dto.IdCliente) ?? throw new Exception("El cliente indicado no existe.");
            if (!cliente.TipoPersona.Nombre.Equals("cliente", StringComparison.InvariantCultureIgnoreCase))
                throw new Exception("No se ha seleccionado un cliente válido.");
            dto.IdCliente = cliente.Id.Value;

            var empleado = this.personaService.GetById(dto.IdEmpleado) ?? throw new Exception("El empleado indicado no existe.");
            if (!empleado.TipoPersona.Nombre.Equals("empleado", StringComparison.InvariantCultureIgnoreCase))
                throw new Exception("No se ha seleccionado un cliente válido.");
            dto.IdEmpleado = empleado.Id.Value;

            var sucursal = this.sucursalService.GetById(dto.IdSucursal) ?? throw new Exception("La sucursal indicada no existe.");
            dto.IdSucursal = sucursal.Id.Value;

            var estados = estadoService.GetAll();
            var estadoPendientePago = estados.SingleOrDefault(e => e.Nombre.Equals("requisicion", StringComparison.InvariantCultureIgnoreCase));
            if (estadoPendientePago == null)
                throw new Exception("No se ha dado de alta el estado 'REQUISICION' comuniquese con su administrador del sistema.");
            dto.IdEstado = estadoPendientePago.Id.Value;

            return base.Create(dto, idUser);
        }
    }
}
