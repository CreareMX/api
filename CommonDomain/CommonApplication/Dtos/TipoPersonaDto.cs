using CommonCore.Interfaces.Entities;

namespace CommonApplication.Dtos
{
    public class TipoPersonaDto : ITipoPersona
    {
        public string Nombre { get; set; }
        public long? Id { get; set; }
        public bool EsPersonaMoral { get; set; }
    }
}
