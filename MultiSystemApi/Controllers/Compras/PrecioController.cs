using CommonApplication.Dtos;
using CommonApplication.Interfaces;
using ComprasApplication.Dtos;
using CommonCore.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MultiSystemApi.Controllers.Compras
{
    /// <summary>
    /// Controlador del API de Precios
    /// </summary>
    [Authorize]
    [Route("api/compras/[controller]")]
    [ApiController]
    public class PreciosController : ControllerBase
    {
        private IPrecioService Service { get; set; }
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="service">Servicio de Precios</param>
        public PreciosController(IPrecioService service)
        {
            Service = service;
        }
        /// <summary>
        /// Obtiene una Precio por medio de su ID
        /// </summary>
        /// <param name="id">Identificador único de Precio</param>
        /// <returns>Precio</returns>
        [HttpGet("id/{id}")]
        public PrecioDto GetById(long id) => Service.GetById(id);
        /// <summary>
        /// Obtiene toda la lista de Precios
        /// </summary>
        /// <returns>Precios</returns>
        [HttpGet("all")]
        public List<PrecioDto> GetAll() => Service.GetAll().ToList();
        /// <summary>
        /// Crea una nueva Precio
        /// </summary>
        /// <param name="dto">Datos de la Precio</param>
        /// <param name="idUser">ID del usuario que crea la Precio</param>
        /// <returns>Precio</returns>
        [HttpPost("{idUser}")]
        public IActionResult Create(PrecioDto dto, long idUser)
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
        /// Actualiza una Precio
        /// </summary>
        /// <param name="dto">Datos de la Precio</param>
        /// <param name="idUser">ID del usuario que actualiza la Precio</param>
        /// <returns>Success</returns>
        [HttpPut("{idUser}")]
        public IActionResult Update(PrecioDto dto, long idUser)
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
        /// Desactiva una Precio existente
        /// </summary>
        /// <param name="dto">Datos de la Precio (se requiere únicamente el ID)</param>
        /// <param name="idUser">ID del usuario que desactiva la Precio</param>
        /// <returns>success</returns>
        [HttpDelete("{idUser}")]
        public IActionResult Delete(PrecioDto dto, long idUser)
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
