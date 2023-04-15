using EssentialApplication.dtos;
using EssentialApplication.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MultiSystemApi.ContPermisolers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermisosController : ControllerBase
    {
        private IPermisoService Service { get; set; }
        public PermisosController(IPermisoService service)
        {
            Service = service;
        }

        [HttpGet("id/{id}")]
        public PermisoDto GetById(long id) => Service.GetById(id);
        [HttpGet("all")]
        public List<PermisoDto> GetAll() => Service.GetAll().ToList();
        [HttpPost("{idUser}")]
        public IActionResult Create(PermisoDto dto, long idUser)
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
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("{idUser}")]
        public IActionResult Update(PermisoDto dto, long idUser)
        {
            try
            {
                Service.Update(dto, idUser);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("{idUser}")]
        public IActionResult Delete(PermisoDto dto, long idUser)
        {
            try
            {
                Service.Delete(dto.Id, idUser);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
