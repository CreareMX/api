namespace AlmacenApplication.Dtos.Kardex
{
    public class ElementoKardexDto
    {
        public long Id { get; set; }
        public string Nombre { get; set; }

        public ElementoKardexDto() { }
        public ElementoKardexDto(long id, string nombre) {
            Id = id;
            Nombre = nombre;
        }
    }
}
