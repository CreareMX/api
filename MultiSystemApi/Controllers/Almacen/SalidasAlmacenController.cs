using AlmacenApplication.Dtos;
using AlmacenApplication.Interfaces;
using EssentialCore.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MultiSystemApi.Controllers.Almacen
{
    /// <summary>
    /// Controlador del API de Salidas de almacen
    /// </summary>
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class SalidasAlmacenController : ControllerBase
    {
        private ISalidaAlmacenService Service { get; set; }
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="service">Servicio de Salidas de almacen</param>
        public SalidasAlmacenController(ISalidaAlmacenService service)
        {
            Service = service;
        }
        /// <summary>
        /// Obtiene una Salida de Almacen por medio de su ID
        /// </summary>
        /// <param name="id">Identificador único de Salida de almacen</param>
        /// <returns>Salida de almacen</returns>
        [HttpGet("id/{id}")]
        public SalidaAlmacenDto GetById(long id) => Service.GetById(id);
        /// <summary>
        /// Obtiene toda la lista de Salidas de almacen
        /// </summary>
        /// <returns>Salidas de almacen</returns>
        [HttpGet("all")]
        public List<SalidaAlmacenDto> GetAll() => Service.GetAll().ToList();
        /// <summary>
        /// Crea una nueva Salida de almacen
        /// </summary>
        /// <param name="dto">Datos de la Salida de almacen</param>
        /// <param name="idUser">ID del usuario que crea la Salida de almacen</param>
        /// <returns>Salida de almacen</returns>
        [HttpPost("{idUser}")]
        public IActionResult Create(SalidaAlmacenDto dto, long idUser)
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
        /// Actualiza una Salida de almacen
        /// </summary>
        /// <param name="dto">Datos de la Salida de almacen</param>
        /// <param name="idUser">ID del usuario que actualiza la Salida de almacen</param>
        /// <returns>Success</returns>
        [HttpPut("{idUser}")]
        public IActionResult Update(SalidaAlmacenDto dto, long idUser)
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
        /// Actualiza el estatus de una entrada de almacen
        /// </summary>
        /// <param name="idEntrada">Identificador de la entrada</param>
        /// <param name="idEstado">Identificador del nuevo estado de la entrada</param>
        /// <param name="idUsuario">Identificador del usuario que modifica el registro</param>
        /// <returns>Success</returns>
        [HttpPut("actualiza/estatus/{idEntrada}/{idEstado}/{idUsuario}")]
        public IActionResult UpdateStatus(long idEntrada, long idEstado, long idUsuario)
        {
            try
            {
                Service.ActualizaEstado(idEntrada, idEstado, idUsuario);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ExceptionHelper.GetFullMessage(ex));
            }
        }
        /// <summary>
        /// Desactiva una Salida de almacen existente
        /// </summary>
        /// <param name="dto">Datos de la Salida de almacen (se requiere únicamente el ID)</param>
        /// <param name="idUser">ID del usuario que desactiva la Salida de almacen</param>
        /// <returns>success</returns>
        [HttpDelete("{idUser}")]
        public IActionResult Delete(SalidaAlmacenDto dto, long idUser)
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
