using AlmacenApplication.Dtos;
using AlmacenApplication.Interfaces;
using CommonCore.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MultiSystemApi.Controllers.Almacen
{
    /// <summary>
    /// Controlador del API de gastos generales fijos
    /// </summary>
    [Authorize]
    [Route("api/Almacen/[controller]")]
    [ApiController]
    public class GastoGeneralFijoController : ControllerBase
    {
        private IGastoGeneralFijoService Service { get; set; }
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="service">Servicio de gastos generales fijos</param>
        public GastoGeneralFijoController(IGastoGeneralFijoService service)
        {
            Service = service;
        }
        /// <summary>
        /// Obtiene los gastos fijos que se deben hacer con una priodicidad quincenal.
        /// </summary>
        /// <returns>Listado de gastos generales fijos</returns>
        [HttpGet("quincenales")]
        public IActionResult Quinceales()
        {
            var result = Service.Quincenales();
            if (result == null)
                return NoContent();
            return Ok(result);
        }
        /// <summary>
        /// Obtiene los gastos fijos que se deben hacer con una priodicidad mensual.
        /// </summary>
        /// <returns>Listado de gastos generales fijos</returns>
        [HttpGet("mensuales")]
        public IActionResult Mensuales()
        {
            var result = Service.Mensuales();
            if (result == null)
                return NoContent();
            return Ok(result);
        }
        /// <summary>
        /// Obtiene los gastos fijos que se deben hacer con una priodicidad anual.
        /// </summary>
        /// <returns>Listado de gastos generales fijos</returns>
        [HttpGet("anuales")]
        public IActionResult Anuales()
        {
            var result = Service.Anuales();
            if (result == null)
                return NoContent();
            return Ok(result);
        }
        /// <summary>
        /// Crea un nuevo gasto general fijo
        /// </summary>
        /// <param name="dto">Datos del gasto general fijo</param>
        /// <param name="idUser">ID del usuario que crea el gasto general fijo</param>
        /// <returns>gasto general fijo</returns>
        [HttpPost("{idUser}")]
        public IActionResult Create(GastoGeneralFijoDto dto, long idUser)
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
        /// Actualiza un gasto general fijo
        /// </summary>
        /// <param name="dto">Datos del gasto general fijo</param>
        /// <param name="idUser">ID del usuario que actualiza el gasto general fijo</param>
        /// <returns>Success</returns>
        [HttpPut("{idUser}")]
        public IActionResult Update(GastoGeneralFijoDto dto, long idUser)
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
        /// Desactiva un gasto general fijo existente
        /// </summary>
        /// <param name="dto">Datos del gasto general fijo (se requiere únicamente el ID)</param>
        /// <param name="idUser">ID del usuario que desactiva el gasto general fijo</param>
        /// <returns>success</returns>
        [HttpDelete("{idUser}")]
        public IActionResult Delete(GastoGeneralFijoDto dto, long idUser)
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
