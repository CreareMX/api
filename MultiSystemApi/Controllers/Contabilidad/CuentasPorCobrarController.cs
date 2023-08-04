using ContabilidadApplication.Dtos;
using ContabilidadApplication.Interfaces;
using CommonCore.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MultiSystemApi.Controllers.Contabilidad
{
    /// <summary>
    /// Controlador del API de cuentas por cobrar
    /// </summary>
    [Authorize]
    [Route("api/contabilidad/[controller]")]
    [ApiController]
    public class CuentasPorCobrarController : ControllerBase
    {
        private ICuentaPorCobrarService Service { get; set; }
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="service">Servicio de cuentas por cobrar</param>
        public CuentasPorCobrarController(ICuentaPorCobrarService service)
        {
            Service = service;
        }
        /// <summary>
        /// Obtiene una cuenta por cobrar por medio de su ID
        /// </summary>
        /// <param name="id">Identificador único de la cuenta por cobrar</param>
        /// <returns>Cuenta por cobrar</returns>
        [HttpGet("id/{id}")]
        public CuentaPorCobrarDto GetById(long id) => Service.GetById(id);
        /// <summary>
        /// Obtiene toda la lista de cuentas por cobrar
        /// </summary>
        /// <returns>Cuentas por cobrar</returns>
        [HttpGet("all")]
        public List<CuentaPorCobrarDto> GetAll() => Service.GetAll().ToList();
        /// <summary>
        /// Crea una nueva cuenta por cobrar
        /// </summary>
        /// <param name="dto">Datos de la cuenta por cobrar</param>
        /// <param name="idUser">ID del usuario que crea la cuenta por cobrar</param>
        /// <returns>Cuenta por cobrar</returns>
        [HttpPost("{idUser}")]
        public IActionResult Create(CuentaPorCobrarDto dto, long idUser)
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
        /// Actualiza una cuenta por cobrar
        /// </summary>
        /// <param name="dto">Datos de la cuenta por cobrar</param>
        /// <param name="idUser">ID del usuario que actualiza la cuenta por cobrar</param>
        /// <returns>Success</returns>
        [HttpPut("{idUser}")]
        public IActionResult Update(CuentaPorCobrarDto dto, long idUser)
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
        /// Desactiva una cuenta por cobrar existente
        /// </summary>
        /// <param name="dto">Datos de la cuenta por cobrar (se requiere únicamente el ID)</param>
        /// <param name="idUser">ID del usuario que desactiva la cuenta por cobrar</param>
        /// <returns>success</returns>
        [HttpDelete("{idUser}")]
        public IActionResult Delete(CuentaPorCobrarDto dto, long idUser)
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
