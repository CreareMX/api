using AlmacenApplication.Dtos;
using AlmacenApplication.Interfaces;
using AutoMapper;
using CommonCore.Entities.Warehouse;
using CommonCore.Interfaces.Repositories.Catalogs;
using CommonCore.Interfaces.Repositories.Warehouse;
using EssentialCore.Services;

namespace AlmacenApplication.Services
{
    public class TransferenciaService : BaseService<ITransferenciaRepository, Transferencia, long, TransferenciaDto>, ITransferenciaService
    {
        readonly IEntradaAlmacenService _entradaAlmacen;
        readonly ISalidaAlmacenService _salidaAlmacen;
        readonly IPersonaRepository _personaService;

        public TransferenciaService(ITransferenciaRepository repository, IEntradaAlmacenService entradaAlmacen, ISalidaAlmacenService salidaAlmacen, 
            IPersonaRepository personaService, IMapper mapper) : base(repository, mapper)
        {
            _entradaAlmacen = entradaAlmacen;
            _salidaAlmacen = salidaAlmacen;
            _personaService = personaService;
        }

        protected override void Validaciones(TransferenciaDto dto)
        {
            var entrada = this._entradaAlmacen.GetById(dto.IdEntradaAlmacen) ?? throw new Exception("No se ha selecionado una entrada de almacén.");
            dto.IdEntradaAlmacen = entrada.Id.Value;

            var salida = this._salidaAlmacen.GetById(dto.IdSalidaAlmacen) ?? throw new Exception("No se ha selecionado una salida de almancén.");
            dto.IdSalidaAlmacen = salida.Id.Value;

            var personaTransfiere = this._personaService.GetById(dto.IdUsuarioTransfiere) ?? throw new Exception("No se ha selecionado un usuario de transferencia.");
            dto.IdUsuarioTransfiere = personaTransfiere.Id.Value;

            if (dto.FechaTranferencia > DateTime.Now)
                throw new Exception("La transferencia no puede hacerse en una fecha futura.");
        }
    }
}
