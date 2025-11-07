using BancaEntidades;
using Contexto;
using MediatR;
using Mensajeria;

namespace BancaNegocio
{
    public class ActualizaMovimientoRequest : IRequest<Unit>
    {
        public ActualizaMovimientoMe MensajeEntrada { get; set; }
    }

    public class ActualizaMovimientoHandler : IRequestHandler<ActualizaMovimientoRequest, Unit>
    {
        private readonly BancaContexto _ctx;

        public ActualizaMovimientoHandler(BancaContexto ctx)
        {
            _ctx = ctx;
        }


        public async Task<Unit> Handle(ActualizaMovimientoRequest request, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;

            _ctx
                .Set<Movimiento>()
                .Where(x => x.Id == request.MensajeEntrada.IdentificadorMovimiento)
                .First()
                .Actualiza(x =>
                {
                    x.Fecha = request.MensajeEntrada.Fecha;
                    x.TipoMovimiento = request.MensajeEntrada.EsCredito ? Movimiento.CREDITO : Movimiento.DEBITO;
                    x.CuentaId = request.MensajeEntrada.CuentaId;
                })
                .AfectaSaldo(request.MensajeEntrada.EsCredito, request.MensajeEntrada.Valor);

            return Unit.Value;
        }
    }
}
