using AlmacenApplication.Dtos;
using AlmacenApplication.Interfaces;
using EssentialCore.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MultiSystemApi.Controllers.Almacen
{
    /// <summary>
    /// Controlador del API de Conceptos
    /// </summary>
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ConceptosController : ControllerBase
    {
        private IConceptoService Service { get; set; }
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="service">Servicio de Conceptos</param>
        public ConceptosController(IConceptoService service)
        {
            Service = service;
        }
        /// <summary>
        /// Obtiene una Concepto por medio de su ID
        /// </summary>
        /// <param name="id">Identificador único de Concepto</param>
        /// <returns>Concepto</returns>
        [HttpGet("id/{id}")]
        public ConceptoDto GetById(long id) => Service.GetById(id);
        /// <summary>
        /// Obtiene toda la lista de Conceptos
        /// </summary>
        /// <returns>Conceptos</returns>
        [HttpGet("all")]
        public List<ConceptoDto> GetAll() => Service.GetAll().ToList();
        /// <summary>
        /// Crea una nueva Concepto
        /// </summary>
        /// <param name="dto">Datos de la Concepto</param>
        /// <param name="idUser">ID del usuario que crea la Concepto</param>
        /// <returns>Concepto</returns>
        [HttpPost("{idUser}")]
        public IActionResult Create(ConceptoDto dto, long idUser)
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
        /// Actualiza una Concepto
        /// </summary>
        /// <param name="dto">Datos de la Concepto</param>
        /// <param name="idUser">ID del usuario que actualiza la Concepto</param>
        /// <returns>Success</returns>
        [HttpPut("{idUser}")]
        public IActionResult Update(ConceptoDto dto, long idUser)
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
        /// Desactiva una Concepto existente
        /// </summary>
        /// <param name="dto">Datos de la Concepto (se requiere únicamente el ID)</param>
        /// <param name="idUser">ID del usuario que desactiva la Concepto</param>
        /// <returns>success</returns>
        [HttpDelete("{idUser}")]
        public IActionResult Delete(ConceptoDto dto, long idUser)
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
