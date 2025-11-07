using BancaEntidades;
using Contexto;
using MediatR;
using Mensajeria;

namespace BancaNegocio
{
    public class EliminaClienteRequest : IRequest<Unit>
    {
        public EliminaClienteMe MensajeEntrada { get; set; }
    }

    public class EliminaClienteHandler : IRequestHandler<EliminaClienteRequest, Unit>
    {
        private readonly BancaContexto _ctx;

        public EliminaClienteHandler(BancaContexto ctx)
        {
            _ctx = ctx;
        }

        public async Task<Unit> Handle(EliminaClienteRequest request, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;

            var cliente =
                _ctx
                .Set<Cliente>()
                .Where(x => x.Id == request.MensajeEntrada.IdentificadorCliente)
                .First();

            var persona =
                _ctx
                .Set<Persona>()
                .Where(x => x.Id == cliente.PersonaId)
                .First();

            _ctx
                .Set<Persona>()
                .Remove(persona);

            _ctx
               .Set<Cliente>()
               .Remove(cliente);

            return Unit.Value;
        }
    }
}
