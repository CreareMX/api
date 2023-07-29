using AlmacenApplication.Dtos.Kardex;

namespace AlmacenApplication.Interfaces
{
    public interface IInventariosService
    {
        KardexDto ObtenerKardex(DateTime fecha, long idAlmacen);
        KardexDto ObtenerBajoStock(DateTime fecha, long idAlmacen);
    }
}
