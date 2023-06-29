using ComprasApplication.Dtos;
using ComprasApplication.Interfaces;
using EssentialCore.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MultiSystemApi.Controllers.Compras
{
    /// <summary>
    /// Controlador del API de Detalles de Ordenes de Compras
    /// </summary>
    [Authorize]
    [Route("api/Compras/[controller]")]
    [ApiController]
    public class DetallesOrdenesComprasController : ControllerBase
    {
        private IDetalleOrdenCompraService Service { get; set; }
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="service">Servicio de Detalles de Ordenes de Compras</param>
        public DetallesOrdenesComprasController(IDetalleOrdenCompraService service)
        {
            Service = service;
        }
        /// <summary>
        /// Obtiene una Detalle de Orden de Compra por medio de su ID
        /// </summary>
        /// <param name="id">Identificador único de Detalle de Orden de Compra</param>
        /// <returns>Detalle de Orden de Compra</returns>
        [HttpGet("id/{id}")]
        public DetalleOrdenCompraDto GetById(long id) => Service.GetById(id);
        /// <summary>
        /// Obtiene toda la lista de Detalles de Ordenes de Compras
        /// </summary>
        /// <returns>Detalles de Ordenes de Compras</returns>
        [HttpGet("all")]
        public List<DetalleOrdenCompraDto> GetAll() => Service.GetAll().ToList();
        /// <summary>
        /// Obtiene toda la lista de Detalles de Ordenes de Compras
        /// <param name="idOrdenCompra">Identificador de la orden de compra</param>
        /// </summary>
        /// <returns>Detalles de Ordenes de Compras</returns>
        [HttpGet("ordencompra/{idOrdenCompra}")]
        public List<DetalleOrdenCompraDto> GetByOrdenCompra(long idOrdenCompra) => Service.GetByOrdenCompra(idOrdenCompra).ToList();
        /// <summary>
        /// Crea una nueva Detalle de Orden de Compra
        /// </summary>
        /// <param name="dto">Datos de la Detalle de Orden de Compra</param>
        /// <param name="idUser">ID del usuario que crea la Detalle de Orden de Compra</param>
        /// <returns>Detalle de Orden de Compra</returns>
        [HttpPost("{idUser}")]
        public IActionResult Create(DetalleOrdenCompraDto dto, long idUser)
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
        /// Actualiza una Detalle de Orden de Compra
        /// </summary>
        /// <param name="dto">Datos de la Detalle de Orden de Compra</param>
        /// <param name="idUser">ID del usuario que actualiza la Detalle de Orden de Compra</param>
        /// <returns>Success</returns>
        [HttpPut("{idUser}")]
        public IActionResult Update(DetalleOrdenCompraDto dto, long idUser)
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
        /// Desactiva una Detalle de Orden de Compra existente
        /// </summary>
        /// <param name="dto">Datos de la Detalle de Orden de Compra (se requiere únicamente el ID)</param>
        /// <param name="idUser">ID del usuario que desactiva la Detalle de Orden de Compra</param>
        /// <returns>success</returns>
        [HttpDelete("{idUser}")]
        public IActionResult Delete(DetalleOrdenCompraDto dto, long idUser)
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
