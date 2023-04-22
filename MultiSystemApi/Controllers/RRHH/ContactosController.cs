using EssentialCore.Shared;
using Microsoft.AspNetCore.Mvc;
using RRHHApplication.Dtos;
using RRHHApplication.Interfaces;

namespace MultiSystemApi.Controllers.RRHH
{
    /// <summary>
    /// Controlador del API de contactos
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ContactosController : ControllerBase
    {
        private IContactoService Service { get; set; }
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="service">Servicio de contactos</param>
        public ContactosController(IContactoService service)
        {
            Service = service;
        }
        /// <summary>
        /// Obtiene un contacto por medio de su ID
        /// </summary>
        /// <param name="id">Identificador único del contacto</param>
        /// <returns>Contactos</returns>
        [HttpGet("id/{id}")]
        public ContactoDto GetById(long id) => Service.GetById(id);
        /// <summary>
        /// Obtiene toda la lista de contactos
        /// </summary>
        /// <returns>Contactos</returns>
        [HttpGet("all")]
        public List<ContactoDto> GetAll() => Service.GetAll().ToList();
        /// <summary>
        /// Crea un nuevo contacto
        /// </summary>
        /// <param name="dto">Datos del contacto</param>
        /// <param name="idUser">ID del usuario que crea el contacto</param>
        /// <returns>Contacto</returns>
        [HttpPost("{idUser}")]
        public IActionResult Create(ContactoDto dto, long idUser)
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
        /// Actualiza un contacto
        /// </summary>
        /// <param name="dto">Datos del contacto</param>
        /// <param name="idUser">ID del usuario que actualiza el contacto</param>
        /// <returns>Success</returns>
        [HttpPut("{idUser}")]
        public IActionResult Update(ContactoDto dto, long idUser)
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
        /// Desactiva un contacto existente
        /// </summary>
        /// <param name="dto">Datos del contacto (se requiere únicamente el ID)</param>
        /// <param name="idUser">ID del usuario que desactiva el contacto</param>
        /// <returns>success</returns>
        [HttpDelete("{idUser}")]
        public IActionResult Delete(ContactoDto dto, long idUser)
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
