using ComprasCore.Entites;
using ComprasCore.Interfaces.Criterias;
using EssentialCore.Criterias;

namespace ComprasCore.Criterias
{
    public class OrdenCompraCriteria : BaseCriteria<OrdenCompra, long>, IOrdenCompraCriteria
    {
        public IOrdenCompraCriteria PorAlmacen(long idAlmacen)
        {
            _expression = x => x.IdAlmacen == idAlmacen && x.Activo;
            return this;
        }

        public IOrdenCompraCriteria PorSucursal(long idSucursal)
        {
            _expression = x => x.IdSucursal == idSucursal && x.Activo;
            return this;
        }
    }
}
