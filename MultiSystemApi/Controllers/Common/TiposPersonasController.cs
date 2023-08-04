using CommonApplication.Dtos;
using CommonApplication.Interfaces;
using Microsoft.AspNetCore.Mvc;
using CommonCore.Shared;
using Microsoft.AspNetCore.Authorization;

namespace MultiSystemApi.Controllers.Common
{
    /// <summary>
    /// Controlador del API de tipos personas
    /// </summary>
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TiposPersonasController : ControllerBase
    {
        private ITipoPersonaService Service { get; set; }
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="service">Servicio de tipos personas</param>
        public TiposPersonasController(ITipoPersonaService service)
        {
            Service = service;
        }
        /// <summary>
        /// Obtiene un tipo de persona por medio de su ID
        /// </summary>
        /// <param name="id">Identificador único del tipo de persona</param>
        /// <returns>Tipo de persona</returns>
        [HttpGet("id/{id}")]
        public TipoPersonaDto GetById(long id) => Service.GetById(id);
        /// <summary>
        /// Obtiene toda la lista de tipos personas
        /// </summary>
        /// <returns>Tipos de personas</returns>
        [HttpGet("all")]
        public List<TipoPersonaDto> GetAll() => Service.GetAll().ToList();
        /// <summary>
        /// Crea un nuevo tipo de persona
        /// </summary>
        /// <param name="dto">Datos del tipo de persona</param>
        /// <param name="idUser">ID del usuario que crea el tipo de persona</param>
        /// <returns>Tipo de persona</returns>
        [HttpPost("{idUser}")]
        public IActionResult Create(TipoPersonaDto dto, long idUser)
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
        /// Actualiza un tipo de persona
        /// </summary>
        /// <param name="dto">Datos del tipo de persona</param>
        /// <param name="idUser">ID del usuario que actualiza el tipo de persona</param>
        /// <returns>Success</returns>
        [HttpPut("{idUser}")]
        public IActionResult Update(TipoPersonaDto dto, long idUser)
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
        /// Desactiva un tipo de persona existente
        /// </summary>
        /// <param name="dto">Datos del tipo de persona (se requiere únicamente el ID)</param>
        /// <param name="idUser">ID del usuario que desactiva el tipo de persona</param>
        /// <returns>success</returns>
        [HttpDelete("{idUser}")]
        public IActionResult Delete(TipoPersonaDto dto, long idUser)
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
