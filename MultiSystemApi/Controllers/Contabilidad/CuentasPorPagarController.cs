using ContabilidadApplication.Dtos;
using ContabilidadApplication.Interfaces;
using EssentialCore.Shared;
using Microsoft.AspNetCore.Mvc;

namespace MultiSystemApi.Controllers.Contabilidad
{
    /// <summary>
    /// Controlador del API de cuentas por pagar
    /// </summary>
    [Route("api/contabilidad/[controller]")]
    [ApiController]
    public class CuentasPorPagarController : ControllerBase
    {
        private ICuentaPorPagarService Service { get; set; }
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="service">Servicio de cuentas por pagar</param>
        public CuentasPorPagarController(ICuentaPorPagarService service)
        {
            Service = service;
        }
        /// <summary>
        /// Obtiene una cuenta por pagar por medio de su ID
        /// </summary>
        /// <param name="id">Identificador único de la cuenta por pagar</param>
        /// <returns>Cuenta por pagar</returns>
        [HttpGet("id/{id}")]
        public CuentaPorPagarDto GetById(long id) => Service.GetById(id);
        /// <summary>
        /// Obtiene toda la lista de cuentas por pagar
        /// </summary>
        /// <returns>Cuentas por pagar</returns>
        [HttpGet("all")]
        public List<CuentaPorPagarDto> GetAll() => Service.GetAll().ToList();
        /// <summary>
        /// Crea una nueva cuenta por pagar
        /// </summary>
        /// <param name="dto">Datos de la cuenta por pagar</param>
        /// <param name="idUser">ID del usuario que crea la cuenta por pagar</param>
        /// <returns>Cuenta por pagar</returns>
        [HttpPost("{idUser}")]
        public IActionResult Create(CuentaPorPagarDto dto, long idUser)
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
        /// Actualiza una cuenta por pagar
        /// </summary>
        /// <param name="dto">Datos de la cuenta por pagar</param>
        /// <param name="idUser">ID del usuario que actualiza la cuenta por pagar</param>
        /// <returns>Success</returns>
        [HttpPut("{idUser}")]
        public IActionResult Update(CuentaPorPagarDto dto, long idUser)
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
        /// Desactiva una cuenta por pagar existente
        /// </summary>
        /// <param name="dto">Datos de la cuenta por pagar (se requiere únicamente el ID)</param>
        /// <param name="idUser">ID del usuario que desactiva la cuenta por pagar</param>
        /// <returns>success</returns>
        [HttpDelete("{idUser}")]
        public IActionResult Delete(CuentaPorPagarDto dto, long idUser)
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
