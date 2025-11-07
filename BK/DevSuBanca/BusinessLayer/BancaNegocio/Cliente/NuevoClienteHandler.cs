using BancaEntidades;
using Contexto;
using MediatR;
using Mensajeria;

namespace BancaNegocio
{
    public class NuevoClienteRequest : IRequest<Unit>
    {
        public NuevoClienteMe MensajeEntrada { get; set; }
    }

    public class NuevoClienteHandler : IRequestHandler<NuevoClienteRequest, Unit>
    {
        private readonly BancaContexto _ctx;

        public NuevoClienteHandler(BancaContexto ctx)
        {
            _ctx = ctx;
        }

        public async Task<Unit> Handle(NuevoClienteRequest request, CancellationToken cancellationToken)
        => await
           new Persona(request.MensajeEntrada.Nombre,
                       request.MensajeEntrada.Genero,
                       request.MensajeEntrada.FechaNacimiento,
                       request.MensajeEntrada.Identificacion,
                       request.MensajeEntrada.Direccion,
                       request.MensajeEntrada.Telefono)
           .GuardaEnContexto(_ctx)
           .CreaCliente(request.MensajeEntrada.Contrasenia,
                        request.MensajeEntrada.Estado)
           .GuardaEnContextoAsyncUnit(_ctx);

    }
}
