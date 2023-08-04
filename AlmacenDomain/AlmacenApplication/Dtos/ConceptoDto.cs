using CommonApplication.Dtos;
using CommonCore.Interfaces.Entities.Catalogs;

namespace AlmacenApplication.Dtos
{
    public class ConceptoDto : IConcepto
    {
        public long? Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public long IdSeccion { get; set; }
        public SeccionDto Seccion { get; set; }
    }
}
