using CommonCore.Interfaces.Entities.Catalogs;

namespace CommonApplication.Dtos
{
    public class EstadoDto : IEstado
    {
        public string Nombre { get; set; }
        public long? Id { get; set; }
        public long IdSeccion { get; set; }
        public SeccionDto Seccion { get; set; }
    }
}
