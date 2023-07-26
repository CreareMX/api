using AlmacenApplication.Dtos;
using CommonCore.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using AlmacenApplication.Interfaces;

namespace MultiSystemApi.Controllers.Transferencia
{
    /// <summary>
    /// Controlador del API de Transferencias
    /// </summary>
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TransferenciasController : ControllerBase
    {
        private ITransferenciaService Service { get; set; }
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="service">Servicio de Transferencias</param>
        public TransferenciasController(ITransferenciaService service)
        {
            Service = service;
        }
        /// <summary>
        /// Obtiene una Transferencia por medio de su ID
        /// </summary>
        /// <param name="id">Identificador único de Transferencia</param>
        /// <returns>Transferencia</returns>
        [HttpGet("id/{id}")]
        public TransferenciaDto GetById(long id) => Service.GetById(id);
        /// <summary>
        /// Obtiene toda la lista de Transferencias
        /// </summary>
        /// <returns>Transferencias</returns>
        [HttpGet("all")]
        public List<TransferenciaDto> GetAll() => Service.GetAll().ToList();
        /// <summary>
        /// Crea una nueva Transferencia
        /// </summary>
        /// <param name="dto">Datos de la Transferencia</param>
        /// <param name="idUser">ID del usuario que crea la Transferencia</param>
        /// <returns>Transferencia</returns>
        [HttpPost("{idUser}")]
        public IActionResult Create(TransferenciaDto dto, long idUser)
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
        /// Actualiza una Transferencia
        /// </summary>
        /// <param name="dto">Datos de la Transferencia</param>
        /// <param name="idUser">ID del usuario que actualiza la Transferencia</param>
        /// <returns>Success</returns>
        [HttpPut("{idUser}")]
        public IActionResult Update(TransferenciaDto dto, long idUser)
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
        /// Desactiva una Transferencia existente
        /// </summary>
        /// <param name="dto">Datos de la Transferencia (se requiere únicamente el ID)</param>
        /// <param name="idUser">ID del usuario que desactiva la Transferencia</param>
        /// <returns>success</returns>
        [HttpDelete("{idUser}")]
        public IActionResult Delete(TransferenciaDto dto, long idUser)
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
