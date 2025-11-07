using BancaEntidades;
using Contexto;
using MediatR;
using Mensajeria;

namespace BancaNegocio
{
    public class DameCuentasPorIdClienteRequest : IRequest<List<ResumenCuenta>>
    {
        public DameCuentasPorIdClienteMe MensajeEntrada { get; set; }
    }

    public class DameCuentasPorIdClienteHandler : IRequestHandler<DameCuentasPorIdClienteRequest, List<ResumenCuenta>>
    {
        private readonly BancaContexto _ctx;

        public DameCuentasPorIdClienteHandler(BancaContexto ctx)
        {
            _ctx = ctx;
        }

        public async Task<List<ResumenCuenta>> Handle(DameCuentasPorIdClienteRequest request, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;

            return
                _ctx
                .DameRegistros<Cuenta>(x => x.ClienteId == request.MensajeEntrada.IdentificadorCliente)
                .Select(x => new ResumenCuenta(x.Id,
                                               x.NumeroCuenta,
                                               x.ClienteId,
                                               x.TipoCuenta,
                                               x.SaldoInicial,
                                               x.Estado,
                                               x.Cliente.Persona.Nombre))
                .ToList();
        }
    }
}
