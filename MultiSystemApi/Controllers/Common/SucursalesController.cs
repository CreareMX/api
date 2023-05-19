using CommonApplication.Dtos;
using CommonApplication.Interfaces;
using Microsoft.AspNetCore.Mvc;
using EssentialCore.Shared;

namespace MultiSystemApi.Controllers.Common
{
    /// <summary>
    /// Controlador del API de Sucursales
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class SucursalesController : ControllerBase
    {
        private ISucursalService Service { get; set; }
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="service">Servicio de Sucursales</param>
        public SucursalesController(ISucursalService service)
        {
            Service = service;
        }
        /// <summary>
        /// Obtiene un Sucursal por medio de su ID
        /// </summary>
        /// <param name="id">Identificador único del Sucursal</param>
        /// <returns>Sucursales</returns>
        [HttpGet("id/{id}")]
        public SucursalDto GetById(long id) => Service.GetById(id);
        /// <summary>
        /// Obtiene toda la lista de Sucursales
        /// </summary>
        /// <returns>Sucursales</returns>
        [HttpGet("all")]
        public List<SucursalDto> GetAll() => Service.GetAll().ToList();
        /// <summary>
        /// Crea un nuevo Sucursal
        /// </summary>
        /// <param name="dto">Datos del Sucursal</param>
        /// <param name="idUser">ID del usuario que crea el Sucursal</param>
        /// <returns>Sucursal</returns>
        [HttpPost("{idUser}")]
        public IActionResult Create(SucursalDto dto, long idUser)
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
        /// Actualiza un Sucursal
        /// </summary>
        /// <param name="dto">Datos del Sucursal</param>
        /// <param name="idUser">ID del usuario que actualiza el Sucursal</param>
        /// <returns>Success</returns>
        [HttpPut("{idUser}")]
        public IActionResult Update(SucursalDto dto, long idUser)
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
        /// Desactiva un Sucursal existente
        /// </summary>
        /// <param name="dto">Datos del Sucursal (se requiere únicamente el ID)</param>
        /// <param name="idUser">ID del usuario que desactiva el Sucursal</param>
        /// <returns>success</returns>
        [HttpDelete("{idUser}")]
        public IActionResult Delete(SucursalDto dto, long idUser)
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
