using CommonCore.Interfaces.Entities;

namespace CommonApplication.Dtos
{
    public class EstadoDto : IEstado
    {
        public string Nombre { get; set; }
        public long? Id { get; set; }
    }
}
