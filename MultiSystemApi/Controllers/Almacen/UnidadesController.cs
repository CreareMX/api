using AlmacenApplication.Dtos;
using AlmacenApplication.Interfaces;
using EssentialCore.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MultiSystemApi.Controllers.Almacen
{
    /// <summary>
    /// Controlador del API de Unidades
    /// </summary>
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UnidadesController : ControllerBase
    {
        private IUnidadService Service { get; set; }
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="service">Servicio de Unidades</param>
        public UnidadesController(IUnidadService service)
        {
            Service = service;
        }
        /// <summary>
        /// Obtiene una Unidad por medio de su ID
        /// </summary>
        /// <param name="id">Identificador único de Unidad</param>
        /// <returns>Unidad</returns>
        [HttpGet("id/{id}")]
        public UnidadDto GetById(long id) => Service.GetById(id);
        /// <summary>
        /// Obtiene toda la lista de Unidades
        /// </summary>
        /// <returns>Unidades</returns>
        [HttpGet("all")]
        public List<UnidadDto> GetAll() => Service.GetAll().ToList();
        /// <summary>
        /// Crea una nueva Unidad
        /// </summary>
        /// <param name="dto">Datos de la Unidad</param>
        /// <param name="idUser">ID del usuario que crea la Unidad</param>
        /// <returns>Unidad</returns>
        [HttpPost("{idUser}")]
        public IActionResult Create(UnidadDto dto, long idUser)
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
        /// Actualiza una Unidad
        /// </summary>
        /// <param name="dto">Datos de la Unidad</param>
        /// <param name="idUser">ID del usuario que actualiza la Unidad</param>
        /// <returns>Success</returns>
        [HttpPut("{idUser}")]
        public IActionResult Update(UnidadDto dto, long idUser)
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
        /// Desactiva una Unidad existente
        /// </summary>
        /// <param name="dto">Datos de la Unidad (se requiere únicamente el ID)</param>
        /// <param name="idUser">ID del usuario que desactiva la Unidad</param>
        /// <returns>success</returns>
        [HttpDelete("{idUser}")]
        public IActionResult Delete(UnidadDto dto, long idUser)
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
