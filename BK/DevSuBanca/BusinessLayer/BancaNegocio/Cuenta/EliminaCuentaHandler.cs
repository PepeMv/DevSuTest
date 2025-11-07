using BancaEntidades;
using Contexto;
using MediatR;
using Mensajeria;

namespace BancaNegocio
{
    public class EliminaCuentaRequest : IRequest<Unit>
    {
        public EliminaCuentaMe MensajeEntrada { get; set; }
    }

    public class EliminaCuentaHandler : IRequestHandler<EliminaCuentaRequest, Unit>
    {
        private readonly BancaContexto _ctx;

        public EliminaCuentaHandler(BancaContexto ctx)
        {
            _ctx = ctx;
        }

        public async Task<Unit> Handle(EliminaCuentaRequest request, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;
            var cuenta =
                _ctx
                .Set<Cuenta>()
                .Where(x => x.Id == request.MensajeEntrada.IdentificadorCuenta)
                .First();

            _ctx
                .Set<Cuenta>()
                .Remove(cuenta);

            return Unit.Value;
        }
    }
}
