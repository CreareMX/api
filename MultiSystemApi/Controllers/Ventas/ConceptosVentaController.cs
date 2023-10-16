using CommonCore.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VentasApplication.Dtos;
using VentasApplication.Interfaces;

namespace MultiSystemApi.Controllers.Ventas
{
    /// <summary>
    /// Controlador del API de Conceptos Ventas
    /// </summary>
    [Authorize]
    [Route("api/Venta/[controller]")]
    [ApiController]
    public class ConceptosVentaController : ControllerBase
    {
        private IConceptoVentaService Service { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="service">Servicio de Concepto Ventas</param>
        public ConceptosVentaController(IConceptoVentaService service)
        {
            Service = service;
        }

        /// <summary>
        /// Obtiene un Concepto Venta por medio de su Id
        /// </summary>
        /// <param name="id">Identificador único del Concepto Venta</param>
        /// <returns>Concepto Venta</returns>
        [HttpGet("id/{id}")]
        public ConceptoVentaDto GetById(long id) => Service.GetById(id);

        /// <summary>
        /// Obtiene toda la lista de Concepto Ventas
        /// </summary>
        /// <returns>Conceptos Ventas</returns>
        [HttpGet("all")]
        public List<ConceptoVentaDto> GetAll() => Service.GetAll().ToList();

        /// <summary>
        /// Crea un nuevo Concepto Venta
        /// </summary>
        /// <param name="dto">Datos del Concepto Venta</param>
        /// <param name="idUser">Id del usuario que crea el Concepto Venta</param>
        /// <returns>Concepto Venta</returns>
        [HttpPost("{idUser}")]
        public IActionResult Create(ConceptoVentaDto dto, long idUser)
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
        /// Actualiza un Concepto Venta
        /// </summary>
        /// <param name="dto">Datos del Concepto Venta</param>
        /// <param name="idUser">Id del usuario que actualiza el Concepto Venta</param>
        /// <returns>Success</returns>
        [HttpPut("{idUser}")]
        public IActionResult Update(ConceptoVentaDto dto, long idUser)
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
        /// Desactiva un Concepto Venta existente
        /// </summary>
        /// <param name="dto">Datos del Concepto Venta (se requiere únicamente el Id)</param>
        /// <param name="idUser">Id del usuario que desactiva el Concepto Venta</param>
        /// <returns>Success</returns>
        [HttpDelete("{idUser}")]
        public IActionResult Delete(ConceptoVentaDto dto, long idUser)
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
