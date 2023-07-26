using ContabilidadApplication.Dtos;
using ContabilidadApplication.Interfaces;
using CommonCore.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MultiSystemApi.Controllers.Contabilidad
{
    /// <summary>
    /// Controlador del API de datos fiscales
    /// </summary>
    [Authorize]
    [Route("api/contabilidad/[controller]")]
    [ApiController]
    public class DatosFiscalesController : ControllerBase
    {
        private IDatosFiscalesService Service { get; set; }
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="service">Servicio de datos fiscales</param>
        public DatosFiscalesController(IDatosFiscalesService service)
        {
            Service = service;
        }
        /// <summary>
        /// Obtiene datos fiscales por medio de su ID
        /// </summary>
        /// <param name="id">Identificador único de la entidad de datos fiscales</param>
        /// <returns>Datos fiscales</returns>
        [HttpGet("id/{id}")]
        public DatosFiscalesDto GetById(long id) => Service.GetById(id);
        /// <summary>
        /// Obtiene toda la lista de datos fiscales
        /// </summary>
        /// <returns>Datos fiscales</returns>
        [HttpGet("all")]
        public List<DatosFiscalesDto> GetAll() => Service.GetAll().ToList();
        /// <summary>
        /// Crea una nueva entidad de datos fiscales
        /// </summary>
        /// <param name="dto">Datos de la entidad de datos fiscales</param>
        /// <param name="idUser">ID del usuario que crea entidad de datos fiscales</param>
        /// <returns>Datos fiscales</returns>
        [HttpPost("{idUser}")]
        public IActionResult Create(DatosFiscalesDto dto, long idUser)
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
        /// Actualiza una entidad de datos fiscales
        /// </summary>
        /// <param name="dto">Datos de la entidad de datos fiscales</param>
        /// <param name="idUser">ID del usuario que actualiza la entidad de datos fiscales</param>
        /// <returns>Success</returns>
        [HttpPut("{idUser}")]
        public IActionResult Update(DatosFiscalesDto dto, long idUser)
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
        public IActionResult Delete(DatosFiscalesDto dto, long idUser)
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
