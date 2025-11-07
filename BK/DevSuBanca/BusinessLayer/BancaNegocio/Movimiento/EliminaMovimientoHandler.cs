using BancaEntidades;
using Contexto;
using MediatR;
using Mensajeria;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancaNegocio
{
    public class EliminaMovimientoRequest : IRequest<Unit>
    {
        public EliminaMovimientoMe MensajeEntrada { get; set; }
    }

    public class EliminaMovimientoHandler : IRequestHandler<EliminaMovimientoRequest, Unit>
    {
        private readonly BancaContexto _ctx;

        public EliminaMovimientoHandler(BancaContexto ctx)
        {
            _ctx = ctx;
        }

        public async  Task<Unit> Handle(EliminaMovimientoRequest request, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;
            var movimiento =
               _ctx
               .Set<Movimiento>()
               .Where(x => x.Id == request.MensajeEntrada.IdentificadorMovimiento)
               .First();

            _ctx
                .Set<Movimiento>()
                .Remove(movimiento);

            return Unit.Value;
        }
    }
}
