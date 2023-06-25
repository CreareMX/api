using AutoMapper;
using CommonApplication.Interfaces;
using CommonCore.Entities.Purchases;
using CommonCore.Interfaces.Criterias.Purchases;
using CommonCore.Interfaces.Repositories.Purchases;
using ComprasApplication.Dtos;
using ComprasApplication.Interfaces;
using ContabilidadApplication.Interfaces;
using EssentialCore.Services;

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

        public void Autorizar(long idOrdenCompra, long idUsuarioAutoriza)
        {
            var ordenCompra = Repository.GetById(idOrdenCompra);
            if (!ordenCompra.Activo)
                throw new Exception($"La orden de compra {idOrdenCompra} actualmente se encuentra cancelada.");

            var estados = estadoService.PorSeccion("ORDENES DE COMPRA");
            var estadoAutorizado = estados.SingleOrDefault(e => e.Nombre.Equals("autorizado", StringComparison.InvariantCultureIgnoreCase)) ?? 
                throw new Exception("No esiste un estado AUTORIZADO para la sección ORDENES DE COMPRA.");

            ordenCompra.IdEstado = estadoAutorizado.Id.Value;
            ordenCompra.Update(idUsuarioAutoriza);
            Repository.SaveChanges();
        }

        public void Cancelar(long idOrdenCompra, long idUsuarioCancela)
        {
            var ordenCompra = Repository.GetById(idOrdenCompra);
            if (!ordenCompra.Activo)
                throw new Exception($"La orden de compra {idOrdenCompra} actualmente se encuentra cancelada.");

            var estados = estadoService.PorSeccion("ORDENES DE COMPRA");
            var estadoAutorizado = estados.SingleOrDefault(e => e.Nombre.Equals("cancelado", StringComparison.InvariantCultureIgnoreCase)) ??
                throw new Exception("No esiste un estado CANCELADO para la sección ORDENES DE COMPRA.");

            ordenCompra.IdEstado = estadoAutorizado.Id.Value;
            ordenCompra.Update(idUsuarioCancela);
            Repository.SaveChanges();
        }

        public override OrdenCompraDto Create(OrdenCompraDto dto, long idUser)
        {
            var cliente = this.personaService.GetById(dto.IdCliente) ?? throw new Exception("El cliente indicado no existe.");
            if (!cliente.TipoPersona.Nombre.Equals("proveedor", StringComparison.InvariantCultureIgnoreCase))
                throw new Exception("No se ha seleccionado un tipo de cliente válido (PROVEEDOR).");
            dto.IdCliente = cliente.Id.Value;

            var empleado = this.personaService.GetById(dto.IdEmpleadoCrea) ?? throw new Exception("El empleado indicado no existe.");
            if (!empleado.TipoPersona.Nombre.Equals("empleado", StringComparison.InvariantCultureIgnoreCase))
                throw new Exception("No se ha seleccionado un empleado válido.");
            dto.IdEmpleadoCrea = empleado.Id.Value;

            var sucursal = this.sucursalService.GetById(dto.IdSucursal) ?? throw new Exception("La sucursal indicada no existe.");
            dto.IdSucursal = sucursal.Id.Value;

            var estados = estadoService.GetAll();
            var estadoPendientePago = estados.SingleOrDefault(e => e.Nombre.Equals("requisicion", StringComparison.InvariantCultureIgnoreCase)) ?? throw new Exception("No se ha dado de alta el estado 'REQUISICION' comuniquese con su administrador del sistema.");
            dto.IdEstado = estadoPendientePago.Id.Value;

            return base.Create(dto, idUser);
        }

        public IList<OrdenCompraDto> OrdenesPorAlmacen(long idAlmacen)
        {
            var estados = estadoService.PorSeccion("ORDENES DE COMPRA");
            var estadoAutorizado = estados.SingleOrDefault(e => e.Nombre.Equals("autorizado", StringComparison.InvariantCultureIgnoreCase)) ??
                throw new Exception("No esiste un estado AUTORIZADO para la sección ORDENES DE COMPRA.");

            var results = Repository.GetListByCriteria(ordenCompraCriteria.PorAlmacen(idAlmacen)).Where(oc => oc.IdEstado == estadoAutorizado.Id).ToList();
            if (results == null || results.Count == 0)
                return null;

            return Mapper.Map<List<OrdenCompraDto>>(results);
        }

        public IList<OrdenCompraDto> RequisicionesPorSucursal(long idSucursal)
        {
            var estados = estadoService.PorSeccion("ORDENES DE COMPRA");
            var estadoRequisicion = estados.SingleOrDefault(e => e.Nombre.Equals("requisicion", StringComparison.InvariantCultureIgnoreCase)) ??
                throw new Exception("No esiste un estado REQUISICION para la sección ORDENES DE COMPRA.");

            var results = Repository.GetListByCriteria(ordenCompraCriteria.PorAlmacen(idSucursal)).Where(oc => oc.IdEstado == estadoRequisicion.Id).ToList();
            if (results == null || results.Count == 0)
                return null;

            return Mapper.Map<List<OrdenCompraDto>>(results);
        }
    }
}
