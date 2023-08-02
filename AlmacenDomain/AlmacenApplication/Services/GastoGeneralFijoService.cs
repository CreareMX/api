using AlmacenApplication.Dtos;
using AlmacenApplication.Interfaces;
using AutoMapper;
using CommonCore.Interfaces.Entities.Catalogs;
using CommonCore.Interfaces.Repositories.Catalogs;
using CommonCore.Services;

namespace AlmacenApplication.Services
{
    public class GastoGeneralFijoService : BaseService<IGastoGeneralFijoRepository, GastoGeneralFijo, long, GastoGeneralFijoDto>, IGastoGeneralFijoService
    {
        readonly IConceptoService _concepto;
        public GastoGeneralFijoService(IGastoGeneralFijoRepository repository, IConceptoService concepto, IMapper mapper) : base(repository, mapper)
        {
            _concepto = concepto;
        }

        public IList<GastoGeneralFijoDto> Anuales()
        {
            var concepto = (_concepto.PorSeccion("GASTOS GENERALES FIJOS")?.FirstOrDefault(e => e.Nombre.Equals("ANUAL", StringComparison.InvariantCultureIgnoreCase))) ?? 
                throw new Exception("No existe un concepto ANUAL para la seccion GASTOS GENERALES FIJOS.");

            return EjecutaConsulta(concepto.Id.Value);
        }

        public IList<GastoGeneralFijoDto> Mensuales()
        {
            var concepto = (_concepto.PorSeccion("GASTOS GENERALES FIJOS")?.FirstOrDefault(e => e.Nombre.Equals("MENSUAL", StringComparison.InvariantCultureIgnoreCase))) ?? 
                throw new Exception("No existe un concepto MENSUAL para la seccion GASTOS GENERALES FIJOS.");

            return EjecutaConsulta(concepto.Id.Value);
        }

        public IList<GastoGeneralFijoDto> Quincenales()
        {
            var concepto = (_concepto.PorSeccion("GASTOS GENERALES FIJOS")?.FirstOrDefault(e => e.Nombre.Equals("QUINCENAL", StringComparison.InvariantCultureIgnoreCase))) ?? 
                throw new Exception("No existe un concepto QUINCENAL para la seccion GASTOS GENERALES FIJOS.");

            return EjecutaConsulta(concepto.Id.Value);
        }

        public IList<GastoGeneralFijoDto> EjecutaConsulta(long idConcepto)
        {
            var result = Repository.GetAll().Where(r => r.IdConcepto == idConcepto);
            if (result != null && result.Count() == 0)
                return null;

            return Mapper.Map<List<GastoGeneralFijoDto>>(result);
        }
    }
}
