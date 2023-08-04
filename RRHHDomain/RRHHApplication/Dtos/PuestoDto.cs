using CommonCore.Interfaces.Entities.Rrhh;

namespace RRHHApplication.Dtos
{
    public class PuestoDto : IPuesto
    {
        public long? Id { get; set; }
        public string Nombre { get; set; }
    }
}
