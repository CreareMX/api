using AlmacenApplication.Dtos;
using AlmacenApplication.Interfaces;
using CommonCore.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MultiSystemApi.Controllers.Almacen
{
    /// <summary>
    /// Controlador del API de tipos de almacen
    /// </summary>
    [Authorize]
    [Route("api/Almacen/[controller]")]
    [ApiController]
    public class TiposAlmacenController : ControllerBase
    {
        private ITipoAlmacenService Service { get; set; }
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="service">Servicio de tipos de almacen</param>
        public TiposAlmacenController(ITipoAlmacenService service)
        {
            Service = service;
        }
        /// <summary>
        /// Obtiene una Tipo de Almacen por medio de su ID
        /// </summary>
        /// <param name="id">Identificador único de tipo de almacen</param>
        /// <returns>tipo de almacen</returns>
        [HttpGet("id/{id}")]
        public TipoAlmacenDto GetById(long id) => Service.GetById(id);
        /// <summary>
        /// Obtiene toda la lista de tipos de almacen
        /// </summary>
        /// <returns>tipos de almacen</returns>
        [HttpGet("all")]
        public List<TipoAlmacenDto> GetAll() => Service.GetAll().ToList();
        /// <summary>
        /// Crea una nueva tipo de almacen
        /// </summary>
        /// <param name="dto">Datos de la tipo de almacen</param>
        /// <param name="idUser">ID del usuario que crea la tipo de almacen</param>
        /// <returns>tipo de almacen</returns>
        [HttpPost("{idUser}")]
        public IActionResult Create(TipoAlmacenDto dto, long idUser)
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
        /// Actualiza una tipo de almacen
        /// </summary>
        /// <param name="dto">Datos de la tipo de almacen</param>
        /// <param name="idUser">ID del usuario que actualiza la tipo de almacen</param>
        /// <returns>Success</returns>
        [HttpPut("{idUser}")]
        public IActionResult Update(TipoAlmacenDto dto, long idUser)
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
        /// Desactiva una tipo de almacen existente
        /// </summary>
        /// <param name="dto">Datos de la tipo de almacen (se requiere únicamente el ID)</param>
        /// <param name="idUser">ID del usuario que desactiva la tipo de almacen</param>
        /// <returns>success</returns>
        [HttpDelete("{idUser}")]
        public IActionResult Delete(TipoAlmacenDto dto, long idUser)
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
