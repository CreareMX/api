using ComprasApplication.Dtos;
using ComprasApplication.Interfaces;
using EssentialCore.Entities;
using EssentialCore.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MultiSystemApi.Controllers.Compras
{
    /// <summary>
    /// Controlador del API de Ordenes de Compras
    /// </summary>
    [Authorize]
    [Route("api/Compras/[controller]")]
    [ApiController]
    public class OrdenesComprasController : ControllerBase
    {
        private IOrdenCompraService Service { get; set; }
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="service">Servicio de Ordenes de Compras</param>
        public OrdenesComprasController(IOrdenCompraService service)
        {
            Service = service;
        }
        /// <summary>
        /// Obtiene una OrdenCompra por medio de su ID
        /// </summary>
        /// <param name="id">Identificador único de Orden de Compra</param>
        /// <returns>Orden de Compra</returns>
        [HttpGet("id/{id}")]
        public OrdenCompraDto GetById(long id) => Service.GetById(id);
        /// <summary>
        /// Obtiene toda la lista de Ordenes de Compras
        /// </summary>
        /// <returns>Ordenes de Compras</returns>
        [HttpGet("all")]
        public List<OrdenCompraDto> GetAll() => Service.GetAll().ToList();
        /// <summary>
        /// Obtiene las ordenes de compra de un almacén en específico
        /// </summary>
        /// <param name="idAlmacen">Identificador único de almacén</param>
        /// <returns>Ordenes de compras</returns>
        public List<OrdenCompraDto> GetOrdenesByAlmacen(long idAlmacen) => Service.OrdenesPorAlmacen(idAlmacen).ToList();
        /// <summary>
        /// Obtiene las ordenes de compra con estatus de requisición de un almacén en específico en una sucursal en específico
        /// </summary>
        /// <param name="idAlmacen">Identificador único de almacén</param>
        /// <param name="idSucursal">Identificador único de sucursal</param>
        /// <returns>Ordenes de compras</returns>
        public List<OrdenCompraDto> GetRequiscionesByAlmacen(long idAlmacen, long idSucursal) => Service.RequisicionesPorAlmacen(idAlmacen, idSucursal).ToList();

        /// <summary>
        /// Crea una nueva Orden de Compra
        /// </summary>
        /// <param name="dto">Datos de la Orden de Compra</param>
        /// <param name="idUser">ID del usuario que crea la Orden de Compra</param>
        /// <returns>Orden de Compra</returns>
        [HttpPost("{idUser}")]
        public IActionResult Create(OrdenCompraDto dto, long idUser)
        {
            try
            {
                var entity = Service.Create(dto, idUser);
                if (entity == null)
                    return NoContent();
                return Ok(entity);
            }
            catch (Exception ex)
            {
                return BadRequest(ExceptionHelper.GetFullMessage(ex));
            }
        }
        /// <summary>
        /// Actualiza una Orden de Compra
        /// </summary>
        /// <param name="dto">Datos de la Orden de Compra</param>
        /// <param name="idUser">ID del usuario que actualiza la Orden de Compra</param>
        /// <returns>Success</returns>
        [HttpPut("{idUser}")]
        public IActionResult Update(OrdenCompraDto dto, long idUser)
        {
            try
            {
                Service.Update(dto, idUser);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ExceptionHelper.GetFullMessage(ex));
            }
        }
        /// <summary>
        /// Desactiva una Orden de Compra existente
        /// </summary>
        /// <param name="dto">Datos de la Orden de Compra (se requiere únicamente el ID)</param>
        /// <param name="idUser">ID del usuario que desactiva la Orden de Compra</param>
        /// <returns>success</returns>
        [HttpDelete("{idUser}")]
        public IActionResult Delete(OrdenCompraDto dto, long idUser)
        {
            try
            {
                Service.Delete(dto.Id, idUser);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ExceptionHelper.GetFullMessage(ex));
            }
        }
    }
}
