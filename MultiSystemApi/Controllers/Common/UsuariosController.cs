using CommonApplication.dtos;
using CommonApplication.Interfaces;
using CommonCore.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MultiSystemApi.Controllers.Common
{
    /// <summary>
    /// Controlador de usuarios
    /// </summary>
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private IUsuarioService Service { get; set; }
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="service">Servicio de usuarios</param>
        public UsuariosController(IUsuarioService service)
        {
            Service = service;
        }
        /// <summary>
        /// Obtiene un usuario por su ID
        /// </summary>
        /// <param name="id">Identificador de usuario</param>
        /// <returns>Usuario</returns>
        [HttpGet("id/{id}")]
        public UsuarioDto GetById(long id) => Service.GetById(id);
        /// <summary>
        /// Obtiene todo el listado de usuarios
        /// </summary>
        /// <returns>Lista de usuarios</returns>
        [HttpGet("all")]
        public List<UsuarioDto> GetAll() => Service.GetAll().ToList();
        /// <summary>
        /// Crea un nuevo usuario
        /// </summary>
        /// <param name="dto">Datos de usuario</param>
        /// <param name="idUser">ID de usuario que está creando el registro</param>
        /// <returns>Usuario creado</returns>
        [HttpPost("{idUser}")]
        public IActionResult Create(UsuarioDto dto, long idUser)
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
        /// Actualiza un usuario existente
        /// </summary>
        /// <param name="dto">Datos de usuario</param>
        /// <param name="idUser">ID de usuario que está modificando el registro</param>
        /// <returns></returns>
        [HttpPut("{idUser}")]
        public IActionResult Update(UsuarioDto dto, long idUser)
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
        /// Desactiva un usuario existente
        /// </summary>
        /// <param name="dto">Datos de usuario</param>
        /// <param name="idUser">ID de usuario que está desactivando el registro</param>
        /// <returns></returns>
        [HttpDelete("{idUser}")]
        public IActionResult Delete(UsuarioDto dto, long idUser)
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
