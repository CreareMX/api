using CommonCore.Interfaces.Entities.Catalogs;

namespace CommonApplication.Dtos
{
    public class ConfiguracionDto : IConfiguracion
    {
        public string Nombre { get; set; }
        public long? Id { get; set; }
        public string Descripcion { get; set; }
        public string Valor { get; set; }
    }
}
