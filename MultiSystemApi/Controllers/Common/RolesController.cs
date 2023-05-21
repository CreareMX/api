using EssentialApplication.dtos;
using EssentialApplication.Interfaces;
using EssentialCore.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MultiSystemApi.Controllers.Common
{
    /// <summary>
    /// Controlador del API de roles
    /// </summary>
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private IRolService Service { get; set; }
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="service">Servicio de roles</param>
        public RolesController(IRolService service)
        {
            Service = service;
        }
        /// <summary>
        /// Obtiene un rol por medio de su ID
        /// </summary>
        /// <param name="id">Identificador único del rol</param>
        /// <returns>Roles</returns>
        [HttpGet("id/{id}")]
        public RolDto GetById(long id) => Service.GetById(id);
        /// <summary>
        /// Obtiene toda la lista de roles
        /// </summary>
        /// <returns>Roles</returns>
        [HttpGet("all")]
        public List<RolDto> GetAll() => Service.GetAll().ToList();
        /// <summary>
        /// Crea un nuevo rol
        /// </summary>
        /// <param name="dto">Datos del rol</param>
        /// <param name="idUser">ID del usuario que crea el rol</param>
        /// <returns>Rol</returns>
        [HttpPost("{idUser}")]
        public IActionResult Create(RolDto dto, long idUser)
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
        /// Actualiza un rol
        /// </summary>
        /// <param name="dto">Datos del rol</param>
        /// <param name="idUser">ID del usuario que actualiza el rol</param>
        /// <returns>Success</returns>
        [HttpPut("{idUser}")]
        public IActionResult Update(RolDto dto, long idUser)
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
        /// Desactiva un rol existente
        /// </summary>
        /// <param name="dto">Datos del rol (se requiere únicamente el ID)</param>
        /// <param name="idUser">ID del usuario que desactiva el rol</param>
        /// <returns>success</returns>
        [HttpDelete("{idUser}")]
        public IActionResult Delete(RolDto dto, long idUser)
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
