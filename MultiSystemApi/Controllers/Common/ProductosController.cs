using CommonApplication.Dtos;
using CommonApplication.Interfaces;
using EssentialCore.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MultiSystemApi.Controllers.Common
{
    /// <summary>
    /// Controlador del API de productos
    /// </summary>
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        private IProductoService Service { get; set; }
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="service">Servicio de productos</param>
        public ProductosController(IProductoService service)
        {
            Service = service;
        }
        /// <summary>
        /// Obtiene un producto por medio de su ID
        /// </summary>
        /// <param name="id">Identificador único del producto</param>
        /// <returns>Productos</returns>
        [HttpGet("id/{id}")]
        public ProductoDto GetById(long id) => Service.GetById(id);
        /// <summary>
        /// Obtiene toda la lista de productos
        /// </summary>
        /// <returns>Productos</returns>
        [HttpGet("all")]
        public List<ProductoDto> GetAll() => Service.GetAll().ToList();
        /// <summary>
        /// Crea un nuevo producto
        /// </summary>
        /// <param name="dto">Datos del producto</param>
        /// <param name="idUser">ID del usuario que crea el producto</param>
        /// <returns>Producto</returns>
        [HttpPost("{idUser}")]
        public IActionResult Create(ProductoDto dto, long idUser)
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
        /// Actualiza un producto
        /// </summary>
        /// <param name="dto">Datos del producto</param>
        /// <param name="idUser">ID del usuario que actualiza el producto</param>
        /// <returns>Success</returns>
        [HttpPut("{idUser}")]
        public IActionResult Update(ProductoDto dto, long idUser)
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
        /// Desactiva un producto existente
        /// </summary>
        /// <param name="dto">Datos del producto (se requiere únicamente el ID)</param>
        /// <param name="idUser">ID del usuario que desactiva el producto</param>
        /// <returns>success</returns>
        [HttpDelete("{idUser}")]
        public IActionResult Delete(ProductoDto dto, long idUser)
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
