using CommonApplication.Dtos;
using CommonApplication.Interfaces;
using Microsoft.AspNetCore.Mvc;
using EssentialCore.Shared;

namespace MultiSystemApi.Controllers.Common
{
    /// <summary>
    /// Controlador del API de Secciones
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class SeccionesController : ControllerBase
    {
        private ISeccionService Service { get; set; }
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="service">Servicio de Secciones</param>
        public SeccionesController(ISeccionService service)
        {
            Service = service;
        }
        /// <summary>
        /// Obtiene un Seccion por medio de su ID
        /// </summary>
        /// <param name="id">Identificador único del Seccion</param>
        /// <returns>Secciones</returns>
        [HttpGet("id/{id}")]
        public SeccionDto GetById(long id) => Service.GetById(id);
        /// <summary>
        /// Obtiene toda la lista de Secciones
        /// </summary>
        /// <returns>Secciones</returns>
        [HttpGet("all")]
        public List<SeccionDto> GetAll() => Service.GetAll().ToList();
        /// <summary>
        /// Crea un nuevo Seccion
        /// </summary>
        /// <param name="dto">Datos del Seccion</param>
        /// <param name="idUser">ID del usuario que crea el Seccion</param>
        /// <returns>Seccion</returns>
        [HttpPost("{idUser}")]
        public IActionResult Create(SeccionDto dto, long idUser)
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
        /// Actualiza un Seccion
        /// </summary>
        /// <param name="dto">Datos del Seccion</param>
        /// <param name="idUser">ID del usuario que actualiza el Seccion</param>
        /// <returns>Success</returns>
        [HttpPut("{idUser}")]
        public IActionResult Update(SeccionDto dto, long idUser)
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
        /// Desactiva un Seccion existente
        /// </summary>
        /// <param name="dto">Datos del Seccion (se requiere únicamente el ID)</param>
        /// <param name="idUser">ID del usuario que desactiva el Seccion</param>
        /// <returns>success</returns>
        [HttpDelete("{idUser}")]
        public IActionResult Delete(SeccionDto dto, long idUser)
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
