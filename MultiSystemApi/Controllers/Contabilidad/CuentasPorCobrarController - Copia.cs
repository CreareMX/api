using ContabilidadApplication.Dtos;
using ContabilidadApplication.Interfaces;
using EssentialCore.Shared;
using Microsoft.AspNetCore.Mvc;

namespace MultiSystemApi.Controllers.Contabilidad
{
    [Route("api/contabilidad/[controller]")]
    [ApiController]
    public class AbonosCuentasPorCobrarController : ControllerBase
    {
        private IAbonoCuentaPorCobrarService Service { get; set; }
        public AbonosCuentasPorCobrarController(IAbonoCuentaPorCobrarService service)
        {
            Service = service;
        }

        [HttpGet("id/{id}")]
        public AbonoCuentaPorCobrarDto GetById(long id) => Service.GetById(id);
        [HttpGet("all")]
        public List<AbonoCuentaPorCobrarDto> GetAll() => Service.GetAll().ToList();
        [HttpPost("{idUser}")]
        public IActionResult Create(AbonoCuentaPorCobrarDto dto, long idUser)
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
        public IActionResult Update(AbonoCuentaPorCobrarDto dto, long idUser)
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
        public IActionResult Delete(AbonoCuentaPorCobrarDto dto, long idUser)
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
