using CommonCore.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RRHHApplication.Dtos;
using RRHHApplication.Interfaces;

namespace MultiSystemApi.Controllers.RRHH
{
    /// <summary>
    /// Controlador del API de Departamento
    /// </summary>
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class DepartamentoController : ControllerBase
    {
        private IDepartamentoService Service { get; set; }
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="service">Servicio de Departamento</param>
        public DepartamentoController(IDepartamentoService service)
        {
            Service = service;
        }
        /// <summary>
        /// Obtiene un Departamento por medio de su ID
        /// </summary>
        /// <param name="id">Identificador único del Departamento</param>
        /// <returns>Departamento</returns>
        [HttpGet("id/{id}")]
        public DepartamentoDto GetById(long id) => Service.GetById(id);
        /// <summary>
        /// Obtiene toda la lista de Departamento
        /// </summary>
        /// <returns>Departamentos</returns>
        [HttpGet("all")]
        public List<DepartamentoDto> GetAll() => Service.GetAll().ToList();
        /// <summary>
        /// Crea un nuevo Departamento
        /// </summary>
        /// <param name="dto">Datos del Departamento</param>
        /// <param name="idUser">ID del usuario que crea el Departamento</param>
        /// <returns>Departamento</returns>
        [HttpPost("{idUser}")]
        public IActionResult Create(DepartamentoDto dto, long idUser)
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
        /// Actualiza un Departamento
        /// </summary>
        /// <param name="dto">Datos del Departamento</param>
        /// <param name="idUser">ID del usuario que actualiza el Departamento</param>
        /// <returns>Success</returns>
        [HttpPut("{idUser}")]
        public IActionResult Update(DepartamentoDto dto, long idUser)
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
        /// Desactiva un Departamento existente
        /// </summary>
        /// <param name="dto">Datos del Departamento (se requiere únicamente el ID)</param>
        /// <param name="idUser">ID del usuario que desactiva el Departamento</param>
        /// <returns>success</returns>
        [HttpDelete("{idUser}")]
        public IActionResult Delete(DepartamentoDto dto, long idUser)
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
