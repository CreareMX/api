using CommonApplication.Dtos;
using CommonApplication.Interfaces;
using Microsoft.AspNetCore.Mvc;
using EssentialCore.Shared;
using Microsoft.AspNetCore.Authorization;

namespace MultiSystemApi.Controllers.Common
{
    /// <summary>
    /// Controlador del API de tipos Precios
    /// </summary>
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TiposPreciosController : ControllerBase
    {
        private ITipoPrecioService Service { get; set; }
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="service">Servicio de tipos Precios</param>
        public TiposPreciosController(ITipoPrecioService service)
        {
            Service = service;
        }
        /// <summary>
        /// Obtiene un tipo de Precio por medio de su ID
        /// </summary>
        /// <param name="id">Identificador único del tipo de Precio</param>
        /// <returns>Tipo de Precio</returns>
        [HttpGet("id/{id}")]
        public TipoPrecioDto GetById(long id) => Service.GetById(id);
        /// <summary>
        /// Obtiene toda la lista de tipos Precios
        /// </summary>
        /// <returns>Tipos de Precios</returns>
        [HttpGet("all")]
        public List<TipoPrecioDto> GetAll() => Service.GetAll().ToList();
        /// <summary>
        /// Crea un nuevo tipo de Precio
        /// </summary>
        /// <param name="dto">Datos del tipo de Precio</param>
        /// <param name="idUser">ID del usuario que crea el tipo de Precio</param>
        /// <returns>Tipo de Precio</returns>
        [HttpPost("{idUser}")]
        public IActionResult Create(TipoPrecioDto dto, long idUser)
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
        /// Actualiza un tipo de Precio
        /// </summary>
        /// <param name="dto">Datos del tipo de Precio</param>
        /// <param name="idUser">ID del usuario que actualiza el tipo de Precio</param>
        /// <returns>Success</returns>
        [HttpPut("{idUser}")]
        public IActionResult Update(TipoPrecioDto dto, long idUser)
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
        /// Desactiva un tipo de Precio existente
        /// </summary>
        /// <param name="dto">Datos del tipo de Precio (se requiere únicamente el ID)</param>
        /// <param name="idUser">ID del usuario que desactiva el tipo de Precio</param>
        /// <returns>success</returns>
        [HttpDelete("{idUser}")]
        public IActionResult Delete(TipoPrecioDto dto, long idUser)
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
