using CommonCore.Interfaces.Entities.Catalogs;

namespace AlmacenApplication.Dtos
{
    public class UnidadDto : IUnidad
    {
        public long? Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Abreviatura { get; set; }
        public decimal Contenido { get; set; }
    }
}
