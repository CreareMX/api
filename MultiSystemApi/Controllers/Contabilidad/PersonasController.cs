using ContabilidadApplication.Dtos;
using ContabilidadApplication.Interfaces;
using EssentialCore.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MultiSystemApi.Controllers.Contabilidad
{
    /// <summary>
    /// Controlador del API de personas
    /// </summary>
    [Authorize]
    [Route("api/contabilidad/[controller]")]
    [ApiController]
    public class PersonasController : ControllerBase
    {
        private IPersonaService Service { get; set; }
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="service">Servicio de personas</param>
        public PersonasController(IPersonaService service)
        {
            Service = service;
        }
        /// <summary>
        /// Obtiene una persona por medio de su ID
        /// </summary>
        /// <param name="id">Identificador único de la persona</param>
        /// <returns>Personas</returns>
        [HttpGet("id/{id}")]
        public PersonaDto GetById(long id) => Service.GetById(id);
        /// <summary>
        /// Obtiene toda la lista de personas
        /// </summary>
        /// <returns>Personas</returns>
        [HttpGet("all")]
        public List<PersonaDto> GetAll() => Service.GetAll().ToList();
        /// <summary>
        /// Crea una nueva persona
        /// </summary>
        /// <param name="dto">Datos de la persona</param>
        /// <param name="idUser">ID del usuario que crea persona</param>
        /// <returns>Persona</returns>
        [HttpPost("{idUser}")]
        public IActionResult Create(PersonaDto dto, long idUser)
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
        /// Actualiza una persona
        /// </summary>
        /// <param name="dto">Datos de la persona</param>
        /// <param name="idUser">ID del usuario que actualiza la persona</param>
        /// <returns>Success</returns>
        [HttpPut("{idUser}")]
        public IActionResult Update(PersonaDto dto, long idUser)
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
        /// Desactiva una persona existente
        /// </summary>
        /// <param name="dto">Datos de la persona (se requiere únicamente el ID)</param>
        /// <param name="idUser">ID del usuario que desactiva la persona</param>
        /// <returns>success</returns>
        [HttpDelete("{idUser}")]
        public IActionResult Delete(PersonaDto dto, long idUser)
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
