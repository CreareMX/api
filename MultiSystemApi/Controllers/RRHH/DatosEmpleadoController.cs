using CommonCore.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RRHHApplication.Dtos;
using RRHHApplication.Interfaces;

namespace MultiSystemApi.Controllers.RRHH
{
    /// <summary>
    /// Controlador del API de Datos de EmpleadoCrea
    /// </summary>
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class DatosEmpleadoController : ControllerBase
    {
        private IDatosEmpleadoService Service { get; set; }
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="service">Servicio de Datos de EmpleadoCrea</param>
        public DatosEmpleadoController(IDatosEmpleadoService service)
        {
            Service = service;
        }
        /// <summary>
        /// Obtiene un DatosEmpleado por medio de su ID
        /// </summary>
        /// <param name="id">Identificador único del Datos de EmpleadoCrea</param>
        /// <returns>Datos de EmpleadoCrea</returns>
        [HttpGet("id/{id}")]
        public DatosEmpleadoDto GetById(long id) => Service.GetById(id);
        /// <summary>
        /// Obtiene toda la lista de Datos de EmpleadoCrea
        /// </summary>
        /// <returns>Datos de Empleados</returns>
        [HttpGet("all")]
        public List<DatosEmpleadoDto> GetAll() => Service.GetAll().ToList();
        /// <summary>
        /// Crea un nuevo DatosEmpleado
        /// </summary>
        /// <param name="dto">Datos del DatosEmpleado</param>
        /// <param name="idUser">ID del usuario que crea el Datos de EmpleadoCrea</param>
        /// <returns>Datos de EmpleadoCrea</returns>
        [HttpPost("{idUser}")]
        public IActionResult Create(DatosEmpleadoDto dto, long idUser)
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
        /// Actualiza un DatosEmpleado
        /// </summary>
        /// <param name="dto">Datos del Datos de EmpleadoCrea</param>
        /// <param name="idUser">ID del usuario que actualiza el Datos de EmpleadoCrea</param>
        /// <returns>Success</returns>
        [HttpPut("{idUser}")]
        public IActionResult Update(DatosEmpleadoDto dto, long idUser)
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
        /// Desactiva un DatosEmpleado existente
        /// </summary>
        /// <param name="dto">Datos del Datos de EmpleadoCrea (se requiere únicamente el ID)</param>
        /// <param name="idUser">ID del usuario que desactiva el Datos de EmpleadoCrea</param>
        /// <returns>success</returns>
        [HttpDelete("{idUser}")]
        public IActionResult Delete(DatosEmpleadoDto dto, long idUser)
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
