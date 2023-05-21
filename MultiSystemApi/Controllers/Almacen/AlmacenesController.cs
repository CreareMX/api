using AlmacenApplication.Dtos;
using AlmacenApplication.Interfaces;
using EssentialCore.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MultiSystemApi.Controllers.Almacen
{
    /// <summary>
    /// Controlador del API de Almacenes
    /// </summary>
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AlmacenesController : ControllerBase
    {
        private IAlmacenService Service { get; set; }
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="service">Servicio de Almacenes</param>
        public AlmacenesController(IAlmacenService service)
        {
            Service = service;
        }
        /// <summary>
        /// Obtiene una Almacen por medio de su ID
        /// </summary>
        /// <param name="id">Identificador único de Almacen</param>
        /// <returns>Almacen</returns>
        [HttpGet("id/{id}")]
        public AlmacenDto GetById(long id) => Service.GetById(id);
        /// <summary>
        /// Obtiene toda la lista de Almacenes
        /// </summary>
        /// <returns>Almacenes</returns>
        [HttpGet("all")]
        public List<AlmacenDto> GetAll() => Service.GetAll().ToList();
        /// <summary>
        /// Crea una nueva Almacen
        /// </summary>
        /// <param name="dto">Datos de la Almacen</param>
        /// <param name="idUser">ID del usuario que crea la Almacen</param>
        /// <returns>Almacen</returns>
        [HttpPost("{idUser}")]
        public IActionResult Create(AlmacenDto dto, long idUser)
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
        /// Actualiza una Almacen
        /// </summary>
        /// <param name="dto">Datos de la Almacen</param>
        /// <param name="idUser">ID del usuario que actualiza la Almacen</param>
        /// <returns>Success</returns>
        [HttpPut("{idUser}")]
        public IActionResult Update(AlmacenDto dto, long idUser)
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
        /// Desactiva una Almacen existente
        /// </summary>
        /// <param name="dto">Datos de la Almacen (se requiere únicamente el ID)</param>
        /// <param name="idUser">ID del usuario que desactiva la Almacen</param>
        /// <returns>success</returns>
        [HttpDelete("{idUser}")]
        public IActionResult Delete(AlmacenDto dto, long idUser)
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
