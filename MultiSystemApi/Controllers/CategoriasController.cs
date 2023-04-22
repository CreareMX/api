using CommonApplication.Dtos;
using CommonApplication.Interfaces;
using Microsoft.AspNetCore.Mvc;
using EssentialCore.Shared;

namespace MultiSystemApi.Controllers
{
    /// <summary>
    /// Controlador del API de categorías
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        private ICategoriaService Service { get; set; }
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="service">Servicio de categorías</param>
        public CategoriasController(ICategoriaService service)
        {
            Service = service;
        }
        /// <summary>
        /// Obtiene una categoria por medio de su ID
        /// </summary>
        /// <param name="id">Identificador único de categoría</param>
        /// <returns>Categoría</returns>
        [HttpGet("id/{id}")]
        public CategoriaDto GetById(long id) => Service.GetById(id);
        /// <summary>
        /// Obtiene toda la lista de categorías
        /// </summary>
        /// <returns>Categorías</returns>
        [HttpGet("all")]
        public List<CategoriaDto> GetAll() => Service.GetAll().ToList();
        /// <summary>
        /// Crea una nueva categoría
        /// </summary>
        /// <param name="dto">Datos de la categoría</param>
        /// <param name="idUser">ID del usuario que crea la categoría</param>
        /// <returns>Categoría</returns>
        [HttpPost("{idUser}")]
        public IActionResult Create(CategoriaDto dto, long idUser)
        {
            try
            {
                var entity = Service.Create(dto, idUser);
                if (entity == null)
                    return NoContent();
                return Ok(entity);
            }
            catch(Exception ex)
            {
                return BadRequest(ExceptionHelper.GetFullMessage(ex));
            }
        }
        /// <summary>
        /// Actualiza una categoría
        /// </summary>
        /// <param name="dto">Datos de la categoría</param>
        /// <param name="idUser">ID del usuario que actualiza la categoría</param>
        /// <returns>Success</returns>
        [HttpPut("{idUser}")]
        public IActionResult Update(CategoriaDto dto, long idUser)
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
        /// Desactiva una categoría existente
        /// </summary>
        /// <param name="dto">Datos de la categoría (se requiere únicamente el ID)</param>
        /// <param name="idUser">ID del usuario que desactiva la categoría</param>
        /// <returns>success</returns>
        [HttpDelete("{idUser}")]
        public IActionResult Delete(CategoriaDto dto, long idUser)
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
