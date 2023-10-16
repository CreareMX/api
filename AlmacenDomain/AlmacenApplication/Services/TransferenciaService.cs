using AlmacenApplication.Dtos;
using AlmacenApplication.Interfaces;
using AutoMapper;
using CommonApplication.Interfaces;
using CommonCore.Entities.Warehouse;
using CommonCore.Interfaces.Repositories.Warehouse;
using CommonCore.Services;

namespace AlmacenApplication.Services
{
    public class TransferenciaService : BaseService<ITransferenciaRepository, Transferencia, long, TransferenciaDto>, ITransferenciaService
    {
        readonly IEntradaAlmacenService _entradaAlmacen;
        readonly ISalidaAlmacenService _salidaAlmacen;
        readonly IUsuarioService _usuarioService;

        public TransferenciaService(ITransferenciaRepository repository, IEntradaAlmacenService entradaAlmacen, ISalidaAlmacenService salidaAlmacen,
            IUsuarioService usuarioService, IMapper mapper) : base(repository, mapper)
        {
            _entradaAlmacen = entradaAlmacen;
            _salidaAlmacen = salidaAlmacen;
            _usuarioService = usuarioService;
        }

        protected override void Validaciones(TransferenciaDto dto)
        {
            var entrada = this._entradaAlmacen.GetById(dto.IdEntradaAlmacen) ?? throw new Exception("No se ha seleccionado una entrada de almacén.");
            dto.IdEntradaAlmacen = entrada.Id.Value;

            var salida = this._salidaAlmacen.GetById(dto.IdSalidaAlmacen) ?? throw new Exception("No se ha seleccionado una salida de almacén.");
            dto.IdSalidaAlmacen = salida.Id.Value;

            var personaTransfiere = this._usuarioService.GetById(dto.IdUsuarioTransfiere) ?? throw new Exception("No se ha seleccionado un usuario de transferencia.");
            dto.IdUsuarioTransfiere = personaTransfiere.Id.Value;

            if (dto.FechaTranferencia > DateTime.Now)
                throw new Exception("La transferencia no puede hacerse en una fecha futura.");
        }
    }
}
