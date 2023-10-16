using CommonCore.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VentasApplication.Dtos;
using VentasApplication.Interfaces;

namespace MultiSystemApi.Controllers.Ventas
{
    /// <summary>
    /// Controlador del API de Impuestos Conceptos Venta
    /// </summary>
    [Authorize]
    [Route("api/Venta/[controller]")]
    [ApiController]
    public class ImpuestosConceptoVentasController : ControllerBase
    {
        private IImpuestosConceptoVentaService Service { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="service">Servicio de Impuestos Conceptos Venta</param>
        public ImpuestosConceptoVentasController(IImpuestosConceptoVentaService service)
        {
            Service = service;
        }

        /// <summary>
        /// Obtiene un Impuesto Concepto Venta por medio de su Id
        /// </summary>
        /// <param name="id">Identificador único del Impuesto Concepto Venta</param>
        /// <returns>Venta</returns>
        [HttpGet("id/{id}")]
        public ImpuestosConceptoVentaDto GetById(long id) => Service.GetById(id);

        /// <summary>
        /// Obtiene toda la lista de Impuesto Concepto Venta
        /// </summary>
        /// <returns>Impuesto Concepto Venta</returns>
        [HttpGet("all")]
        public List<ImpuestosConceptoVentaDto> GetAll() => Service.GetAll().ToList();

        /// <summary>
        /// Crea un nuevo Impuesto Concepto Venta
        /// </summary>
        /// <param name="dto">Datos del Impuesto Concepto Venta</param>
        /// <param name="idUser">Id del usuario que crea el Impuesto Concepto Venta</param>
        /// <returns>Impuesto Concepto Venta</returns>
        [HttpPost("{idUser}")]
        public IActionResult Create(ImpuestosConceptoVentaDto dto, long idUser)
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
        /// Actualiza un Impuesto Concepto Venta
        /// </summary>
        /// <param name="dto">Datos del Impuesto Concepto Venta</param>
        /// <param name="idUser">Id del usuario que actualiza el Impuesto Concepto Venta</param>
        /// <returns>Success</returns>
        [HttpPut("{idUser}")]
        public IActionResult Update(ImpuestosConceptoVentaDto dto, long idUser)
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
        /// Desactiva un Impuesto Concepto Venta existente
        /// </summary>
        /// <param name="dto">Datos del Impuesto Concepto Venta (se requiere únicamente el Id)</param>
        /// <param name="idUser">Id del usuario que desactiva el Impuesto Concepto Venta</param>
        /// <returns>Success</returns>
        [HttpDelete("{idUser}")]
        public IActionResult Delete(ImpuestosConceptoVentaDto dto, long idUser)
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
