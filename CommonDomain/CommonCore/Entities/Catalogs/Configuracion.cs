using CommonCore.Interfaces.Entities.Catalogs;

namespace CommonCore.Entities.Catalogs
{
    public class Configuracion : BaseEntityLongId, IConfiguracion
    {
        public string Descripcion { get; set; }
        public string Nombre { get; set; }
        public string Valor { get; set; }
    }
}
