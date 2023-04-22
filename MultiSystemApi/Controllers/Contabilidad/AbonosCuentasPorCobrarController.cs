using ContabilidadApplication.Dtos;
using ContabilidadApplication.Interfaces;
using EssentialCore.Shared;
using Microsoft.AspNetCore.Mvc;

namespace MultiSystemApi.Controllers.Contabilidad
{
    /// <summary>
    /// Controlador del API de abonos a cuentas por cobrar
    /// </summary>
    [Route("api/contabilidad/[controller]")]
    [ApiController]
    public class AbonosCuentasPorCobrarController : ControllerBase
    {
        private IAbonoCuentaPorCobrarService Service { get; set; }
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="service">Servicio de abonos a cuentas por cobrar</param>
        public AbonosCuentasPorCobrarController(IAbonoCuentaPorCobrarService service)
        {
            Service = service;
        }
        /// <summary>
        /// Obtiene un abono a cuenta por cobrar por medio de su ID
        /// </summary>
        /// <param name="id">Identificador único de abono a cuenta por cobrar</param>
        /// <returns>Abono a cuenta por cobrar</returns>
        [HttpGet("id/{id}")]
        public AbonoCuentaPorCobrarDto GetById(long id) => Service.GetById(id);
        /// <summary>
        /// Obtiene toda la lista de abonos a cuentas por cobrar
        /// </summary>
        /// <returns>Abonos a cuentas por cobrar</returns>
        [HttpGet("all")]
        public List<AbonoCuentaPorCobrarDto> GetAll() => Service.GetAll().ToList();
        /// <summary>
        /// Crea un nuevo abono a cuenta por cobrar
        /// </summary>
        /// <param name="dto">Datos del abono a cuenta por cobrar</param>
        /// <param name="idUser">ID del usuario que crea el abono a cuenta por cobrar</param>
        /// <returns>Abono a cuenta por cobrar</returns>
        [HttpPost("{idUser}")]
        public IActionResult Create(AbonoCuentaPorCobrarDto dto, long idUser)
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
        /// Actualiza un abono a cuenta por cobrar
        /// </summary>
        /// <param name="dto">Datos del abono a cuenta por cobrar</param>
        /// <param name="idUser">ID del usuario que actualiza el abono a cuenta por cobrar</param>
        /// <returns>Success</returns>
        [HttpPut("{idUser}")]
        public IActionResult Update(AbonoCuentaPorCobrarDto dto, long idUser)
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
        /// Desactiva un abono a cuenta por cobrar existente
        /// </summary>
        /// <param name="dto">Datos del abono a cuenta por cobrar (se requiere únicamente el ID)</param>
        /// <param name="idUser">ID del usuario que desactiva el abono a cuenta por cobrar</param>
        /// <returns>success</returns>
        [HttpDelete("{idUser}")]
        public IActionResult Delete(AbonoCuentaPorCobrarDto dto, long idUser)
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
