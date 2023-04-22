using CommonApplication.Dtos;
using CommonApplication.Interfaces;
using Microsoft.AspNetCore.Mvc;
using EssentialCore.Shared;

namespace MultiSystemApi.Controllers
{
    /// <summary>
    /// Controlador del API de estados
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class EstadosController : ControllerBase
    {
        private IEstadoService Service { get; set; }
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="service">Servicio de estados</param>
        public EstadosController(IEstadoService service)
        {
            Service = service;
        }
        /// <summary>
        /// Obtiene un estado por medio de su ID
        /// </summary>
        /// <param name="id">Identificador único del estado</param>
        /// <returns>Estados</returns>
        [HttpGet("id/{id}")]
        public EstadoDto GetById(long id) => Service.GetById(id);
        /// <summary>
        /// Obtiene toda la lista de estados
        /// </summary>
        /// <returns>Estados</returns>
        [HttpGet("all")]
        public List<EstadoDto> GetAll() => Service.GetAll().ToList();
        /// <summary>
        /// Crea un nuevo estado
        /// </summary>
        /// <param name="dto">Datos del estado</param>
        /// <param name="idUser">ID del usuario que crea el estado</param>
        /// <returns>Estado</returns>
        [HttpPost("{idUser}")]
        public IActionResult Create(EstadoDto dto, long idUser)
        {
            try
            {
                var entity = Service.Create(dto, idUser);
                if (entity == null)
                    return NoContent();
                return Ok(entity);
            }
            catch(Exception ex)
            {
                return BadRequest(ExceptionHelper.GetFullMessage(ex));
            }
        }
        /// <summary>
        /// Actualiza un estado
        /// </summary>
        /// <param name="dto">Datos del estado</param>
        /// <param name="idUser">ID del usuario que actualiza el estado</param>
        /// <returns>Success</returns>
        [HttpPut("{idUser}")]
        public IActionResult Update(EstadoDto dto, long idUser)
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
        /// Desactiva un estado existente
        /// </summary>
        /// <param name="dto">Datos del estado (se requiere únicamente el ID)</param>
        /// <param name="idUser">ID del usuario que desactiva el estado</param>
        /// <returns>success</returns>
        [HttpDelete("{idUser}")]
        public IActionResult Delete(EstadoDto dto, long idUser)
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
