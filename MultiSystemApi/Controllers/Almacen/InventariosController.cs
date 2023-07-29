using AlmacenApplication.Dtos.Kardex;
using AlmacenApplication.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MultiSystemApi.Controllers.Almacen
{
    /// <summary>
    /// Controlador del API de entradas de almacen
    /// </summary>
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class InventariosController : ControllerBase
    {
        private IInventariosService Service { get; set; }
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="service">Servicio de entradas de almacen</param>
        public InventariosController(IInventariosService service)
        {
            Service = service;
        }
        /// <summary>
        /// Obtiene el kardex de un almacen hasta la fecha indicada
        /// </summary>
        /// <param name="fecha">Fecha final del kardex</param>
        /// <param name="idAlmacen">Identificador unico de almacén</param>
        /// <returns>Kardex</returns>
        [HttpGet("kardex/{fecha}/{idAlmacen}")]
        public KardexDto ObtenerKardex(DateTime fecha, long idAlmacen) => Service.ObtenerKardex(fecha, idAlmacen);
        /// <summary>
        /// Obtiene el kardex de un almacen hasta la fecha indicada con únicamente los productos debajo del punto de reorden
        /// </summary>
        /// <param name="fecha">Fecha final del kardex</param>
        /// <param name="idAlmacen">Identificador unico de almacén</param>
        /// <returns>Kardex</returns>
        [HttpGet("bajostock/{fecha}/{idAlmacen}")]
        public KardexDto ObtenerBajoStock(DateTime fecha, long idAlmacen) => Service.ObtenerBajoStock(fecha, idAlmacen);
    }
}
