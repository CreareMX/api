using ContabilidadApplication.Dtos;
using ContabilidadApplication.Interfaces;
using EssentialCore.Shared;
using Microsoft.AspNetCore.Mvc;

namespace MultiSystemApi.Controllers.Contabilidad
{
    [Route("api/contabilidad/[controller]")]
    [ApiController]
    public class AbonosCuentasPorPagarController : ControllerBase
    {
        private IAbonoCuentaPorPagarService Service { get; set; }
        public AbonosCuentasPorPagarController(IAbonoCuentaPorPagarService service)
        {
            Service = service;
        }

        [HttpGet("id/{id}")]
        public AbonoCuentaPorPagarDto GetById(long id) => Service.GetById(id);
        [HttpGet("all")]
        public List<AbonoCuentaPorPagarDto> GetAll() => Service.GetAll().ToList();
        [HttpPost("{idUser}")]
        public IActionResult Create(AbonoCuentaPorPagarDto dto, long idUser)
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
        public IActionResult Update(AbonoCuentaPorPagarDto dto, long idUser)
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
        public IActionResult Delete(AbonoCuentaPorPagarDto dto, long idUser)
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
