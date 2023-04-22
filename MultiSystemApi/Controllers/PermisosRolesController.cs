using EssentialApplication.dtos;
using EssentialApplication.Interfaces;
using EssentialCore.Shared;
using Microsoft.AspNetCore.Mvc;

namespace MultiSystemApi.Controllers
{
    /// <summary>
    /// Controlador del API de Permiso de rols
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class PermisosRolesController : ControllerBase
    {
        private IPermisosRolService Service { get; set; }
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="service">Servicio de Permiso de rols</param>
        public PermisosRolesController(IPermisosRolService service)
        {
            Service = service;
        }
        /// <summary>
        /// Obtiene un Permiso de rol por medio de su ID
        /// </summary>
        /// <param name="id">Identificador único del Permiso de rol</param>
        /// <returns>Permisos de roles</returns>
        [HttpGet("id/{id}")]
        public PermisosRolDto GetById(long id) => Service.GetById(id);
        /// <summary>
        /// Obtiene toda la lista de Permiso de rols
        /// </summary>
        /// <returns>Permisos de roles</returns>
        [HttpGet("all")]
        public List<PermisosRolDto> GetAll() => Service.GetAll().ToList();
        /// <summary>
        /// Crea un nuevo Permiso de rol
        /// </summary>
        /// <param name="dto">Datos del Permiso de rol</param>
        /// <param name="idUser">ID del usuario que crea el Permiso de rol</param>
        /// <returns>Permiso de rol</returns>   
        [HttpPost("{idUser}")]
        public IActionResult Create(PermisosRolDto dto, long idUser)
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
        /// Actualiza un Permiso de rol
        /// </summary>
        /// <param name="dto">Datos del Permiso de rol</param>
        /// <param name="idUser">ID del usuario que actualiza el Permiso de rol</param>
        /// <returns>Success</returns>
        [HttpPut("{idUser}")]
        public IActionResult Update(PermisosRolDto dto, long idUser)
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
        /// Desactiva un Permiso de rol existente
        /// </summary>
        /// <param name="dto">Datos del Permiso de rol (se requiere únicamente el ID)</param>
        /// <param name="idUser">ID del usuario que desactiva el Permiso de rol</param>
        /// <returns>success</returns>
        [HttpDelete("{idUser}")]
        public IActionResult Delete(PermisosRolDto dto, long idUser)
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
