using CommonApplication.Dtos;
using CommonApplication.Interfaces;
using Microsoft.AspNetCore.Mvc;
using EssentialCore.Shared;

namespace MultiSystemApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        private ICategoriaService Service { get; set; }
        public CategoriasController(ICategoriaService service)
        {
            Service = service;
        }

        [HttpGet("id/{id}")]
        public CategoriaDto GetById(long id) => Service.GetById(id);
        [HttpGet("all")]
        public List<CategoriaDto> GetAll() => Service.GetAll().ToList();
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
