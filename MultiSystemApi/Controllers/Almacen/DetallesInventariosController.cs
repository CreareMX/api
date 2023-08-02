using AlmacenApplication.Dtos.Inventario;
using CommonCore.Shared;
using DetalleInventarioApplication.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MultiSystemApi.Controllers.Almacen
{
    /// <summary>
    /// Controlador del API de DetallesInventarios
    /// </summary>
    [Authorize]
    [Route("api/Almacen/[controller]")]
    [ApiController]
    public class DetallesInventariosController : ControllerBase
    {
        private IDetalleInventarioService Service { get; set; }
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="service">Servicio de DetallesInventarios</param>
        public DetallesInventariosController(IDetalleInventarioService service)
        {
            Service = service;
        }
        /// <summary>
        /// Obtiene una DetalleInventario por medio de su ID
        /// </summary>
        /// <param name="id">Identificador único de DetalleInventario</param>
        /// <returns>DetalleInventario</returns>
        [HttpGet("id/{id}")]
        public DetalleInventarioDto GetById(long id) => Service.GetById(id);
        /// <summary>
        /// Obtiene toda la lista de DetallesInventarios
        /// </summary>
        /// <returns>DetallesInventarios</returns>
        [HttpGet("all")]
        public List<DetalleInventarioDto> GetAll() => Service.GetAll().ToList();
        /// <summary>
        /// Crea una nueva DetalleInventario
        /// </summary>
        /// <param name="dto">Datos de la DetalleInventario</param>
        /// <param name="idUser">ID del usuario que crea la DetalleInventario</param>
        /// <returns>DetalleInventario</returns>
        [HttpPost("{idUser}")]
        public IActionResult Create(DetalleInventarioDto dto, long idUser)
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
        /// Actualiza una DetalleInventario
        /// </summary>
        /// <param name="dto">Datos de la DetalleInventario</param>
        /// <param name="idUser">ID del usuario que actualiza la DetalleInventario</param>
        /// <returns>Success</returns>
        [HttpPut("{idUser}")]
        public IActionResult Update(DetalleInventarioDto dto, long idUser)
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
        /// Desactiva una DetalleInventario existente
        /// </summary>
        /// <param name="dto">Datos de la DetalleInventario (se requiere únicamente el ID)</param>
        /// <param name="idUser">ID del usuario que desactiva la DetalleInventario</param>
        /// <returns>success</returns>
        [HttpDelete("{idUser}")]
        public IActionResult Delete(DetalleInventarioDto dto, long idUser)
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
