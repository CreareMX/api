using AlmacenApplication.Dtos;
using AlmacenApplication.Dtos.Inventario;
using CommonCore.Shared;
using InventarioApplication.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MultiSystemApi.Controllers.Almacen
{
    /// <summary>
    /// Controlador del API de Inventario
    /// </summary>
    [Authorize]
    [Route("api/Almacen/[controller]")]
    [ApiController]
    public class InventariosController : ControllerBase
    {
        private IInventarioService Service { get; set; }
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="service">Servicio de Inventario</param>
        public InventariosController(IInventarioService service)
        {
            Service = service;
        }
        /// <summary>
        /// Obtiene el kardex de un almacen hasta la fecha indicada
        /// </summary>
        /// <param name="fecha">Fecha final del kardex</param>
        /// <param name="idAlmacen">Identificador unico de almacén</param>
        /// <returns>Kardex</returns>
        [HttpGet("kardex/{fecha}/{idAlmacen}")]
        public IActionResult ObtenerKardex(DateTime fecha, long idAlmacen)
        {
            var result = Service.ObtenerKardex(fecha, idAlmacen);
            if (result == null)
                return NoContent();
            return Ok(result);
        }
        /// <summary>
        /// Obtiene el kardex de un almacen hasta la fecha indicada con únicamente los productos debajo del punto de reorden
        /// </summary>
        /// <param name="fecha">Fecha final del kardex</param>
        /// <param name="idAlmacen">Identificador unico de almacén</param>
        /// <returns>Kardex</returns>
        [HttpGet("bajostock/{fecha}/{idAlmacen}")]
        public IActionResult ObtenerBajoStock(DateTime fecha, long idAlmacen)
        {
            var result = Service.ObtenerBajoStock(fecha, idAlmacen);
            if (result == null)
                return NoContent();
            return Ok(result);
        }
        /// <summary>
        /// Obtiene las diferencias entre las existencias en sistema (kardex) y un inventario realizado (que ya se encuentre finalizado)
        /// Si la diferencia es negativa significa que hubo un excedente
        /// Si la diferencia es positva significa que hubo un faltante
        /// </summary>
        /// <param name="idInventario">Identificador único del inventario que será usado para obtener las diferencias contra las existencias</param>
        /// <returns>Kardex</returns>
        [HttpGet("diferencias/{idInventario}")]
        public IActionResult ObtenerDiferencias(long idInventario)
        {
            var result = Service.ObtenerDiferencias(idInventario);
            if (result == null)
                return NoContent();
            return Ok(result);
        }
        /// <summary>
        /// Crea un nuevo Inventario
        /// </summary>
        /// <param name="dto">Datos del Inventario</param>
        /// <param name="idUser">ID del usuario que crea el Inventario</param>
        /// <returns>Inventario</returns>
        [HttpPost("{idUser}")]
        public IActionResult Create(InventarioDto dto, long idUser)
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
        /// Actualiza un Inventario
        /// </summary>
        /// <param name="dto">Datos del Inventario</param>
        /// <param name="idUser">ID del usuario que actualiza el Inventario</param>
        /// <returns>Success</returns>
        [HttpPut("{idUser}")]
        public IActionResult Update(InventarioDto dto, long idUser)
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
        /// Desactiva un Inventario existente
        /// </summary>
        /// <param name="dto">Datos del Inventario (se requiere únicamente el ID)</param>
        /// <param name="idUser">ID del usuario que desactiva el Inventario</param>
        /// <returns>success</returns>
        [HttpDelete("{idUser}")]
        public IActionResult Delete(InventarioDto dto, long idUser)
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
