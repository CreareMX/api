using ContabilidadApplication.Dtos;
using ContabilidadApplication.Interfaces;
using EssentialCore.Shared;
using Microsoft.AspNetCore.Mvc;

namespace MultiSystemApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonasController : ControllerBase
    {
        private IPersonaService Service { get; set; }
        public PersonasController(IPersonaService service)
        {
            Service = service;
        }

        [HttpGet("id/{id}")]
        public PersonaDto GetById(long id) => Service.GetById(id);
        [HttpGet("all")]
        public List<PersonaDto> GetAll() => Service.GetAll().ToList();
        [HttpPost("{idUser}")]
        public IActionResult Create(PersonaDto dto, long idUser)
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
        public IActionResult Update(PersonaDto dto, long idUser)
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
        public IActionResult Delete(PersonaDto dto, long idUser)
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
