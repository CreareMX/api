using EssentialApplication.dtos;
using EssentialApplication.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MultiSystemApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermisosRolesController : ControllerBase
    {
        private IPermisosRolService Service { get; set; }
        public PermisosRolesController(IPermisosRolService service)
        {
            Service = service;
        }

        [HttpGet("id/{id}")]
        public PermisosRolDto GetById(long id) => Service.GetById(id);
        [HttpGet("all")]
        public List<PermisosRolDto> GetAll() => Service.GetAll().ToList();
        [HttpPost("{idUser}")]
        public IActionResult Create(PermisosRolDto dto, long idUser)
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
        public IActionResult Update(PermisosRolDto dto, long idUser)
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
        public IActionResult Delete(PermisosRolDto dto, long idUser)
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
