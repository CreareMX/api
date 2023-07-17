using AlmacenApplication.Dtos;

namespace AlmacenApplication.Interfaces
{
    public interface IInventariosService
    {
        KardexDto ObtenerKardex(DateTime fecha, long idAlmacen);
    }
}
