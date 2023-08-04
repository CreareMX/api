using CommonCore.Interfaces.Entities.Catalogs;

namespace CommonApplication.Dtos
{
    public class SucursalDto : ISucursal
    {
        public string Nombre { get; set; }
        public long? Id { get; set; }
        public string Domicilio { get; set; }
        public string Telefono { get; set; }
    }
}
