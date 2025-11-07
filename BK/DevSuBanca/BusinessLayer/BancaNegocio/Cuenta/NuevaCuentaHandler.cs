using BancaEntidades;
using Contexto;
using MediatR;
using Mensajeria;

namespace BancaNegocio
{
    public class NuevaCuentaRequest : IRequest<Unit>
    {
        public NuevaCuentaMe MensajeEntrada { get; set; }
    }

    public class NuevaCuentaHandler : IRequestHandler<NuevaCuentaRequest, Unit>
    {
        private readonly BancaContexto _ctx;

        public NuevaCuentaHandler(BancaContexto ctx)
        {
            _ctx = ctx;
        }

        public async Task<Unit> Handle(NuevaCuentaRequest request, CancellationToken cancellationToken)
        => await
            new Cuenta(request.MensajeEntrada.NumeroCuenta,
                       request.MensajeEntrada.ClienteId,
                       request.MensajeEntrada.TipoCuenta,
                       request.MensajeEntrada.SaldoInicial,
                       request.MensajeEntrada.Estado)
                .GuardaEnContextoAsyncUnit(_ctx);

    }
}
