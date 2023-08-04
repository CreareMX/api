using CommonApplication.dtos;
using CommonApplication.Interfaces;
using CommonCore.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MultiSystemApi.Controllers.Common
{
    /// <summary>
    /// Controlador del API de permisos
    /// </summary>
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PermisosController : ControllerBase
    {
        private IPermisoService Service { get; set; }
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="service">Servicio de permisos</param>
        public PermisosController(IPermisoService service)
        {
            Service = service;
        }
        /// <summary>
        /// Obtiene un permiso por medio de su ID
        /// </summary>
        /// <param name="id">Identificador único del permiso</param>
        /// <returns>Permisos</returns>
        [HttpGet("id/{id}")]
        public PermisoDto GetById(long id) => Service.GetById(id);
        /// <summary>
        /// Obtiene toda la lista de permisos
        /// </summary>
        /// <returns>Permisos</returns>
        [HttpGet("all")]
        public List<PermisoDto> GetAll() => Service.GetAll().ToList();
        /// <summary>
        /// Crea un nuevo permiso
        /// </summary>
        /// <param name="dto">Datos del permiso</param>
        /// <param name="idUser">ID del usuario que crea el permiso</param>
        /// <returns>Permiso</returns>   
        [HttpPost("{idUser}")]
        public IActionResult Create(PermisoDto dto, long idUser)
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
        /// Actualiza un permiso
        /// </summary>
        /// <param name="dto">Datos del permiso</param>
        /// <param name="idUser">ID del usuario que actualiza el permiso</param>
        /// <returns>Success</returns>
        [HttpPut("{idUser}")]
        public IActionResult Update(PermisoDto dto, long idUser)
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
        /// Desactiva un permiso existente
        /// </summary>
        /// <param name="dto">Datos del permiso (se requiere únicamente el ID)</param>
        /// <param name="idUser">ID del usuario que desactiva el permiso</param>
        /// <returns>success</returns>
        [HttpDelete("{idUser}")]
        public IActionResult Delete(PermisoDto dto, long idUser)
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
