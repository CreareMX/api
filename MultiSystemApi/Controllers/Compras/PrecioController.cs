using EssentialCore.Shared;
using Microsoft.AspNetCore.Mvc;
using VentasApplication.Dtos;
using VentasApplication.Interfaces;

namespace MultiSystemApi.Controllers.Compras
{
    /// <summary>
    /// Controlador del API de Costos
    /// </summary>
    [Route("api/Ventas/[controller]")]
    [ApiController]
    public class CostosController : ControllerBase
    {
        private ICostoService Service { get; set; }
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="service">Servicio de Costos</param>
        public CostosController(ICostoService service)
        {
            Service = service;
        }
        /// <summary>
        /// Obtiene una Costo por medio de su ID
        /// </summary>
        /// <param name="id">Identificador único de Costo</param>
        /// <returns>Costo</returns>
        [HttpGet("id/{id}")]
        public CostoDto GetById(long id) => Service.GetById(id);
        /// <summary>
        /// Obtiene toda la lista de Costos
        /// </summary>
        /// <returns>Costos</returns>
        [HttpGet("all")]
        public List<CostoDto> GetAll() => Service.GetAll().ToList();
        /// <summary>
        /// Crea una nueva Costo
        /// </summary>
        /// <param name="dto">Datos de la Costo</param>
        /// <param name="idUser">ID del usuario que crea la Costo</param>
        /// <returns>Costo</returns>
        [HttpPost("{idUser}")]
        public IActionResult Create(CostoDto dto, long idUser)
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
        /// Actualiza una Costo
        /// </summary>
        /// <param name="dto">Datos de la Costo</param>
        /// <param name="idUser">ID del usuario que actualiza la Costo</param>
        /// <returns>Success</returns>
        [HttpPut("{idUser}")]
        public IActionResult Update(CostoDto dto, long idUser)
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
        /// Desactiva una Costo existente
        /// </summary>
        /// <param name="dto">Datos de la Costo (se requiere únicamente el ID)</param>
        /// <param name="idUser">ID del usuario que desactiva la Costo</param>
        /// <returns>success</returns>
        [HttpDelete("{idUser}")]
        public IActionResult Delete(CostoDto dto, long idUser)
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
