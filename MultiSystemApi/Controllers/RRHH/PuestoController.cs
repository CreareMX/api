using EssentialCore.Shared;
using Microsoft.AspNetCore.Mvc;
using RRHHApplication.Dtos;
using RRHHApplication.Interfaces;

namespace MultiSystemApi.Controllers.RRHH
{
    /// <summary>
    /// Controlador del API de puesto
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class PuestoController : ControllerBase
    {
        private IPuestoService Service { get; set; }
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="service">Servicio de puesto</param>
        public PuestoController(IPuestoService service)
        {
            Service = service;
        }
        /// <summary>
        /// Obtiene un puesto por medio de su ID
        /// </summary>
        /// <param name="id">Identificador único del puesto</param>
        /// <returns>Puesto</returns>
        [HttpGet("id/{id}")]
        public PuestoDto GetById(long id) => Service.GetById(id);
        /// <summary>
        /// Obtiene toda la lista de puesto
        /// </summary>
        /// <returns>Puestos</returns>
        [HttpGet("all")]
        public List<PuestoDto> GetAll() => Service.GetAll().ToList();
        /// <summary>
        /// Crea un nuevo puesto
        /// </summary>
        /// <param name="dto">Datos del puesto</param>
        /// <param name="idUser">ID del usuario que crea el puesto</param>
        /// <returns>Puesto</returns>
        [HttpPost("{idUser}")]
        public IActionResult Create(PuestoDto dto, long idUser)
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
        /// Actualiza un puesto
        /// </summary>
        /// <param name="dto">Datos del puesto</param>
        /// <param name="idUser">ID del usuario que actualiza el puesto</param>
        /// <returns>Success</returns>
        [HttpPut("{idUser}")]
        public IActionResult Update(PuestoDto dto, long idUser)
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
        /// Desactiva un puesto existente
        /// </summary>
        /// <param name="dto">Datos del puesto (se requiere únicamente el ID)</param>
        /// <param name="idUser">ID del usuario que desactiva el puesto</param>
        /// <returns>success</returns>
        [HttpDelete("{idUser}")]
        public IActionResult Delete(PuestoDto dto, long idUser)
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
