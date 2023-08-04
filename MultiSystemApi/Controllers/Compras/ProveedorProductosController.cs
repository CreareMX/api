using ComprasApplication.Dtos;
using ComprasApplication.Interfaces;
using CommonCore.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MultiSystemApi.Controllers.Compras
{
    /// <summary>
    /// Controlador del API de ProveedorProductos
    /// </summary>
    [Authorize]
    [Route("api/Compras/[controller]")]
    [ApiController]
    public class ProveedorProductosController : ControllerBase
    {
        private IProveedorProductoService Service { get; set; }
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="service">Servicio de ProveedorProductos</param>
        public ProveedorProductosController(IProveedorProductoService service)
        {
            Service = service;
        }
        /// <summary>
        /// Obtiene una ProveedorProducto por medio de su ID
        /// </summary>
        /// <param name="id">Identificador único de ProveedorProducto</param>
        /// <returns>ProveedorProducto</returns>
        [HttpGet("id/{id}")]
        public ProveedorProductoDto GetById(long id) => Service.GetById(id);
        /// <summary>
        /// Obtiene toda la lista de ProveedorProductos
        /// </summary>
        /// <returns>ProveedorProductos</returns>
        [HttpGet("all")]
        public List<ProveedorProductoDto> GetAll() => Service.GetAll().ToList();
        /// <summary>
        /// Obtiene toda la lista de ProveedorProductos filtrados por producto
        /// </summary>
        /// <param name="idProducto">Identificador único de producto</param>
        /// <returns>ProveedorProductos</returns>
        [HttpGet("porproducto/{idProducto}")]
        public List<ProveedorProductoDto> GetByProducto(long idProducto) => Service.GetByProducto(idProducto).ToList();
        /// <summary>
        /// Obtiene toda la lista de ProveedorProductos filtrados por proveedor
        /// </summary>
        /// <param name="idProveedor">Identificador único de proveedor</param>
        /// <returns>ProveedorProductos</returns>
        [HttpGet("porproveedor/{idProveedor}")]
        public List<ProveedorProductoDto> GetByProveedor(long idProveedor) => Service.GetByProveedor(idProveedor).ToList();
        /// <summary>
        /// Crea una nueva ProveedorProducto
        /// </summary>
        /// <param name="dto">Datos de la ProveedorProducto</param>
        /// <param name="idUser">ID del usuario que crea la ProveedorProducto</param>
        /// <returns>ProveedorProducto</returns>
        [HttpPost("{idUser}")]
        public IActionResult Create(ProveedorProductoDto dto, long idUser)
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
        /// Actualiza una ProveedorProducto
        /// </summary>
        /// <param name="dto">Datos de la ProveedorProducto</param>
        /// <param name="idUser">ID del usuario que actualiza la ProveedorProducto</param>
        /// <returns>Success</returns>
        [HttpPut("{idUser}")]
        public IActionResult Update(ProveedorProductoDto dto, long idUser)
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
        /// Desactiva una ProveedorProducto existente
        /// </summary>
        /// <param name="dto">Datos de la ProveedorProducto (se requiere únicamente el ID)</param>
        /// <param name="idUser">ID del usuario que desactiva la ProveedorProducto</param>
        /// <returns>success</returns>
        [HttpDelete("{idUser}")]
        public IActionResult Delete(ProveedorProductoDto dto, long idUser)
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
