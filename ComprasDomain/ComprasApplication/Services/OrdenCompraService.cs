using AutoMapper;
using CommonApplication.Interfaces;
using CommonCore.Entities.Purchases;
using CommonCore.Interfaces.Criterias.Purchases;
using CommonCore.Interfaces.Repositories.Purchases;
using CommonCore.Services;
using ComprasApplication.Dtos;
using ComprasApplication.Interfaces;
using ContabilidadApplication.Interfaces;

namespace ComprasApplication.Services
{
    public class OrdenCompraService : BaseService<IOrdenCompraRepository, OrdenCompra, long, OrdenCompraDto>, IOrdenCompraService
    {
        readonly IPersonaService personaService;
        readonly IEstadoService estadoService;
        readonly ISucursalService sucursalService;
        readonly IOrdenCompraCriteria ordenCompraCriteria;

        public OrdenCompraService(IOrdenCompraRepository repository, IOrdenCompraCriteria ordenCompraCriteria,
            IPersonaService personaService, IEstadoService estadoService,
            ISucursalService sucursalService, IMapper mapper) : base(repository, mapper)
        {
            this.personaService = personaService;
            this.estadoService = estadoService;
            this.sucursalService = sucursalService;
            this.ordenCompraCriteria = ordenCompraCriteria;
        }

        public void UpdateStatus(long idOrdenCompra, long idEstado, long idUsuarioCancela)
        {
            var ordenCompra = Repository.GetById(idOrdenCompra);
            if (!ordenCompra.Activo)
                throw new Exception($"La orden de compra {idOrdenCompra} actualmente se encuentra cancelada.");

            var estado = estadoService.GetById(idEstado) ?? throw new Exception("El estado seleccionado no existe.");

            ordenCompra.IdEstado = estado.Id.Value;
            ordenCompra.Update(idUsuarioCancela);
            Repository.SaveChanges();
        }

        public override OrdenCompraDto Create(OrdenCompraDto dto, long idUser)
        {
            ValidaOrdenCompra(dto);

            var estados = estadoService.GetAll();
            var estadoPendientePago = estados.SingleOrDefault(e => e.Nombre.Equals("req_pendiente", StringComparison.InvariantCultureIgnoreCase)) ??
                throw new Exception("No se ha dado de alta el estado 'REQUISICION PENDIENTE' (req_pendiente) comuniquese con su administrador del sistema.");
            dto.IdEstado = estadoPendientePago.Id.Value;

            return base.Create(dto, idUser);
        }

        public override void Update(OrdenCompraDto dto, long idUser)
        {
            ValidaOrdenCompra(dto);
            var ordenCompra = Repository.GetById(dto.Id.Value) ?? throw new Exception($"La orden de compra con ID {dto.Id} no ha sido localizada o bien ya no esta activa");

            Repository.ClearTracker(true);

            ordenCompra.IdAlmacen = dto.IdAlmacen;
            ordenCompra.IdCliente = dto.IdCliente;
            ordenCompra.IdEmpleadoAutoriza = dto.IdEmpleadoAutoriza;
            ordenCompra.IdEstado = dto.IdEstado;
            ordenCompra.IdSucursal = dto.IdSucursal;
            ordenCompra.Fecha = dto.Fecha;
            ordenCompra.FechaCompromiso = dto.FechaCompromiso;
            ordenCompra.FechaEnvio = dto.FechaEnvio;
            ordenCompra.FechaAutorizacion = dto.FechaAutorizacion;
            ordenCompra.FormaEnvio = dto.FormaEnvio;
            ordenCompra.Comentarios = dto.Comentarios;

            ordenCompra.Update(idUser);

            Repository.Update(ordenCompra);
            Repository.SaveChanges();
            Repository.ClearTracker(true);
        }

        public IList<OrdenCompraDto> OrdenesPorAlmacen(long idAlmacen)
        {
            var estados = estadoService.PorSeccion("ORDENES DE COMPRA");
            var estadoAutorizado = estados.SingleOrDefault(e => e.Nombre.Equals("autorizado", StringComparison.InvariantCultureIgnoreCase)) ??
                throw new Exception("No existe un estado AUTORIZADO para la sección ORDENES DE COMPRA.");

            var results = Repository.GetListByCriteria(ordenCompraCriteria.PorAlmacen(idAlmacen)).Where(oc => oc.IdEstado == estadoAutorizado.Id).ToList();
            if (results == null || results.Count == 0)
                return null;

            return Mapper.Map<List<OrdenCompraDto>>(results);
        }

        public IList<OrdenCompraDto> RequisicionesPorSucursal(long idSucursal)
        {
            var estados = estadoService.PorSeccion("ORDENES DE COMPRA");
            var estadoRequisicion = estados.SingleOrDefault(e => e.Nombre.Equals("requisicion", StringComparison.InvariantCultureIgnoreCase)) ??
                throw new Exception("No existe un estado REQUISICION para la sección ORDENES DE COMPRA.");

            var results = Repository.GetListByCriteria(ordenCompraCriteria.PorAlmacen(idSucursal)).Where(oc => oc.IdEstado == estadoRequisicion.Id).ToList();
            if (results == null || results.Count == 0)
                return null;

            return Mapper.Map<List<OrdenCompraDto>>(results);
        }

        private void ValidaOrdenCompra(OrdenCompraDto dto)
        {
            var cliente = this.personaService.GetById(dto.IdCliente) ?? throw new Exception("El cliente indicado no existe.");
            if (!cliente.TipoPersona.Nombre.Equals("proveedor", StringComparison.InvariantCultureIgnoreCase))
                throw new Exception("No se ha seleccionado un tipo de cliente válido (PROVEEDOR).");
            dto.IdCliente = cliente.Id.Value;

            var empleado = this.personaService.GetById(dto.IdEmpleadoCrea) ?? throw new Exception("El empleado indicado no existe.");
            if (!empleado.TipoPersona.Nombre.Equals("empleado", StringComparison.InvariantCultureIgnoreCase))
                throw new Exception("No se ha seleccionado un empleado válido.");
            dto.IdEmpleadoCrea = empleado.Id.Value;

            var sucursal = this.sucursalService.GetById(dto.IdSucursal.Value) ?? throw new Exception("La sucursal indicada no existe.");
            dto.IdSucursal = sucursal.Id.Value;
        }
    }
}
