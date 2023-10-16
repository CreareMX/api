using CommonCore.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VentasApplication.Dtos;
using VentasApplication.Interfaces;

namespace MultiSystemApi.Controllers.Ventas
{
    /// <summary>
    /// Controlador del API de Ventas
    /// </summary>
    [Authorize]
    [Route("api/Venta/[controller]")]
    [ApiController]
    public class VentasController : ControllerBase
    {
        private IVentaService Service { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="service">Servicio de Ventas</param>
        public VentasController(IVentaService service)
        {
            Service = service;
        }

        /// <summary>
        /// Obtiene una Venta por medio de su Id
        /// </summary>
        /// <param name="id">Identificador único de Venta</param>
        /// <returns>Venta</returns>
        [HttpGet("id/{id}")]
        public VentaDto GetById(long id) => Service.GetById(id);

        /// <summary>
        /// Obtiene toda la lista de Ventas
        /// </summary>
        /// <returns>Ventas</returns>
        [HttpGet("all")]
        public List<VentaDto> GetAll() => Service.GetAll().ToList();

        /// <summary>
        /// Crea una nueva Venta
        /// </summary>
        /// <param name="dto">Datos de la Venta</param>
        /// <param name="idUser">Id del usuario que crea la Venta</param>
        /// <returns>Venta</returns>
        [HttpPost("{idUser}")]
        public IActionResult Create(VentaDto dto, long idUser)
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
        /// Actualiza una Venta
        /// </summary>
        /// <param name="dto">Datos de la Venta</param>
        /// <param name="idUser">Id del usuario que actualiza la Venta</param>
        /// <returns>Success</returns>
        [HttpPut("{idUser}")]
        public IActionResult Update(VentaDto dto, long idUser)
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
        /// Desactiva una Venta existente
        /// </summary>
        /// <param name="dto">Datos de la Venta (se requiere únicamente el Id)</param>
        /// <param name="idUser">Id del usuario que desactiva la Venta</param>
        /// <returns>Success</returns>
        [HttpDelete("{idUser}")]
        public IActionResult Delete(VentaDto dto, long idUser)
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
