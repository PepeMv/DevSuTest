using BancaEntidades;
using Contexto;
using MediatR;
using Mensajeria;

namespace BancaNegocio
{

    public class NuevoMovimientoRequest : IRequest<Unit>
    {
        public NuevoMovimientoMe MensajeEntrada { get; set; }
    }

    public class NuevoMovimientoHandler : IRequestHandler<NuevoMovimientoRequest, Unit>
    {
        private readonly BancaContexto _ctx;

        public NuevoMovimientoHandler(BancaContexto ctx)
        {
            _ctx = ctx;
        }

        public async Task<Unit> Handle(NuevoMovimientoRequest request, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;

            new Movimiento(request.MensajeEntrada.Fecha,
                           request.MensajeEntrada.EsCredito,
                           request.MensajeEntrada.CuentaId)
                .GuardaEnContexto(_ctx)
                .AfectaSaldo(request.MensajeEntrada.EsCredito,
                             request.MensajeEntrada.Valor);
            return Unit.Value;
        }
    }
}
