using BancaEntidades;
using Contexto;
using MediatR;
using Mensajeria;

namespace BancaNegocio
{
    public class ActualizaCuentaRequest : IRequest<Unit>
    {
        public ActualizarCuentaMe MensajeEntrada { get; set; }
    }

    public class ActualizaCuentaHandler : IRequestHandler<ActualizaCuentaRequest, Unit>
    {
        private readonly BancaContexto _ctx;

        public ActualizaCuentaHandler(BancaContexto ctx)
        {
            _ctx = ctx;
        }

        public async Task<Unit> Handle(ActualizaCuentaRequest request, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;

            _ctx
                .Set<Cuenta>()
                .Where(x => x.Id == request.MensajeEntrada.IdentificadorCuenta)
                .First()
                .Actualiza(x =>
                {
                    x.NumeroCuenta = request.MensajeEntrada.NumeroCuenta;
                    x.ClienteId = request.MensajeEntrada.ClienteId;
                    x.TipoCuenta = request.MensajeEntrada.TipoCuenta;
                    x.SaldoInicial = request.MensajeEntrada.SaldoInicial;
                    x.Estado = request.MensajeEntrada.Estado;
                });

            return Unit.Value;

        }
    }
}
