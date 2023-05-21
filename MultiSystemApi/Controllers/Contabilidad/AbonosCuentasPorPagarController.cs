using ContabilidadApplication.Dtos;
using ContabilidadApplication.Interfaces;
using EssentialCore.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MultiSystemApi.Controllers.Contabilidad
{
    /// <summary>
    /// Controlador del API de abonos a cuentas por pagar
    /// </summary>
    [Authorize]
    [Route("api/contabilidad/[controller]")]
    [ApiController]
    public class AbonosCuentasPorPagarController : ControllerBase
    {
        private IAbonoCuentaPorPagarService Service { get; set; }
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="service">Servicio de abonos a cuentas por pagar</param>
        public AbonosCuentasPorPagarController(IAbonoCuentaPorPagarService service)
        {
            Service = service;
        }
        /// <summary>
        /// Obtiene un abono a cuenta por pagar por medio de su ID
        /// </summary>
        /// <param name="id">Identificador único de abono a cuenta por pagar</param>
        /// <returns>Abono a cuenta por pagar</returns>
        [HttpGet("id/{id}")]
        public AbonoCuentaPorPagarDto GetById(long id) => Service.GetById(id);
        /// <summary>
        /// Obtiene toda la lista de abonos a cuentas por pagar
        /// </summary>
        /// <returns>Abonos a cuentas por pagar</returns>
        [HttpGet("all")]
        public List<AbonoCuentaPorPagarDto> GetAll() => Service.GetAll().ToList();
        /// <summary>
        /// Crea un nuevo abono a cuenta por pagar
        /// </summary>
        /// <param name="dto">Datos del abono a cuenta por pagar</param>
        /// <param name="idUser">ID del usuario que crea el abono a cuenta por pagar</param>
        /// <returns>Abono a cuenta por pagar</returns>
        [HttpPost("{idUser}")]
        public IActionResult Create(AbonoCuentaPorPagarDto dto, long idUser)
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
        /// Actualiza un abono a cuenta por pagar
        /// </summary>
        /// <param name="dto">Datos del abono a cuenta por pagar</param>
        /// <param name="idUser">ID del usuario que actualiza el abono a cuenta por pagar</param>
        /// <returns>Success</returns>
        [HttpPut("{idUser}")]
        public IActionResult Update(AbonoCuentaPorPagarDto dto, long idUser)
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
        /// Desactiva un abono a cuenta por pagar existente
        /// </summary>
        /// <param name="dto">Datos del abono a cuenta por pagar (se requiere únicamente el ID)</param>
        /// <param name="idUser">ID del usuario que desactiva el abono a cuenta por pagar</param>
        /// <returns>success</returns>
        [HttpDelete("{idUser}")]
        public IActionResult Delete(AbonoCuentaPorPagarDto dto, long idUser)
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
