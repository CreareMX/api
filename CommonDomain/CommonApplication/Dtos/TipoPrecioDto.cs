using CommonCore.Interfaces.Entities.Types;

namespace CommonApplication.Dtos
{
    public class TipoPrecioDto : ITipoPrecio
    {
        public string Nombre { get; set; }
        public long? Id { get; set; }
    }
}
