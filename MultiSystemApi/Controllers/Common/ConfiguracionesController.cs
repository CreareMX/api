using CommonApplication.Dtos;
using CommonApplication.Interfaces;
using Microsoft.AspNetCore.Mvc;
using CommonCore.Shared;
using Microsoft.AspNetCore.Authorization;

namespace MultiSystemApi.Controllers.Common
{
    /// <summary>
    /// Controlador del API de Configuraciones
    /// </summary>
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ConfiguracionesController : ControllerBase
    {
        private IConfiguracionService Service { get; set; }
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="service">Servicio de Configuraciones</param>
        public ConfiguracionesController(IConfiguracionService service)
        {
            Service = service;
        }
        /// <summary>
        /// Obtiene un Configuracion por medio de su ID
        /// </summary>
        /// <param name="id">Identificador único del Configuracion</param>
        /// <returns>Configuraciones</returns>
        [HttpGet("id/{id}")]
        public ConfiguracionDto GetById(long id) => Service.GetById(id);
        /// <summary>
        /// Obtiene un Configuracion por medio de su nombre
        /// </summary>
        /// <param name="nombre">Nombre de la Configuracion</param>
        /// <returns>Configuraciones</returns>
        [HttpGet("nombre/{id}")]
        public ConfiguracionDto GetByNombre(string nombre) => Service.PorNombre(nombre);
        /// <summary>
        /// Obtiene toda la lista de Configuraciones
        /// </summary>
        /// <returns>Configuraciones</returns>
        [HttpGet("all")]
        public List<ConfiguracionDto> GetAll() => Service.GetAll().ToList();
        /// <summary>
        /// Crea un nuevo Configuracion
        /// </summary>
        /// <param name="dto">Datos del Configuracion</param>
        /// <param name="idUser">ID del usuario que crea el Configuracion</param>
        /// <returns>Configuracion</returns>
        [HttpPost("{idUser}")]
        public IActionResult Create(ConfiguracionDto dto, long idUser)
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
        /// Actualiza un Configuracion
        /// </summary>
        /// <param name="dto">Datos del Configuracion</param>
        /// <param name="idUser">ID del usuario que actualiza el Configuracion</param>
        /// <returns>Success</returns>
        [HttpPut("{idUser}")]
        public IActionResult Update(ConfiguracionDto dto, long idUser)
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
        /// Desactiva un Configuracion existente
        /// </summary>
        /// <param name="dto">Datos del Configuracion (se requiere únicamente el ID)</param>
        /// <param name="idUser">ID del usuario que desactiva el Configuracion</param>
        /// <returns>success</returns>
        [HttpDelete("{idUser}")]
        public IActionResult Delete(ConfiguracionDto dto, long idUser)
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
