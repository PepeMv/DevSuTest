using BancaEntidades;
using Contexto;
using MediatR;
using Mensajeria;

namespace BancaNegocio
{
    public class DameMovimientosPorCuentaRangoFechasRequest : IRequest<List<ResumenMovimiento>>
    {
        public DameMovimientosCuentaRangoFechasMe MensajeEntrada { get; set; }
    }

    public class DameMovimientosPorCuentaRangoFechasHandler : IRequestHandler<DameMovimientosPorCuentaRangoFechasRequest, List<ResumenMovimiento>>
    {
        private readonly BancaContexto _ctx;

        public DameMovimientosPorCuentaRangoFechasHandler(BancaContexto ctx)
        {
            _ctx = ctx;
        }

        public async Task<List<ResumenMovimiento>> Handle(DameMovimientosPorCuentaRangoFechasRequest request, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;

            return
                _ctx
                .DameRegistros<Movimiento>(x => x.CuentaId == request.MensajeEntrada.IdentificadorCuenta &&
                                                request.MensajeEntrada.FechaInicio <= x.Fecha && x.Fecha <= request.MensajeEntrada.FechaFin)
                .OrderBy(x => x.Fecha)
                .Select(x => new ResumenMovimiento(x.Id, x.Fecha, x.TipoMovimiento, x.Valor, x.Saldo, x.CuentaId))       
                .ToList();
        }
    }
}
