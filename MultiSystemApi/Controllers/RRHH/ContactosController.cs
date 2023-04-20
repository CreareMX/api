using EssentialCore.Shared;
using Microsoft.AspNetCore.Mvc;
using RRHHApplication.Dtos;
using RRHHApplication.Interfaces;

namespace MultiSystemApi.Controllers.RRHH
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactosController : ControllerBase
    {
        private IContactoService Service { get; set; }
        public ContactosController(IContactoService service)
        {
            Service = service;
        }

        [HttpGet("id/{id}")]
        public ContactoDto GetById(long id) => Service.GetById(id);
        [HttpGet("all")]
        public List<ContactoDto> GetAll() => Service.GetAll().ToList();
        [HttpPost("{idUser}")]
        public IActionResult Create(ContactoDto dto, long idUser)
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
        [HttpPut("{idUser}")]
        public IActionResult Update(ContactoDto dto, long idUser)
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
        public IActionResult Delete(ContactoDto dto, long idUser)
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
