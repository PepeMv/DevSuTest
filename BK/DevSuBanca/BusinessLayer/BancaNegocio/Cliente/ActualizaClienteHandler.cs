using BancaEntidades;
using Contexto;
using MediatR;
using Mensajeria;

namespace BancaNegocio
{
    public class ActualizaClienteRequest : IRequest<Unit>
    {
        public ActualizaClienteMe MensajeEntrada { get; set; }
    }


    public class ActualizaClienteHandler : IRequestHandler<ActualizaClienteRequest, Unit>
    {
        private readonly BancaContexto _ctx;

        public ActualizaClienteHandler(BancaContexto ctx)
        {
            _ctx = ctx;
        }

        public async Task<Unit> Handle(ActualizaClienteRequest request, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;

            _ctx
                .Set<Cliente>()
                .Where(x => x.Id == request.MensajeEntrada.IdentificadorCliente)
                .First()
                .Actualiza(x =>
                {
                    x.Contrasenia = request.MensajeEntrada.Contrasenia;
                    x.Estado = request.MensajeEntrada.Estado;
                    x.Persona.Nombre = request.MensajeEntrada.Nombre;
                    x.Persona.Genero = request.MensajeEntrada.Genero;
                    x.Persona.FechaNacimiento = request.MensajeEntrada.FechaNacimiento;
                    x.Persona.Identificacion = request.MensajeEntrada.Identificacion;
                    x.Persona.Direccion = request.MensajeEntrada.Direccion;
                    x.Persona.Telefono = request.MensajeEntrada.Telefono;
                });

            return Unit.Value;
        }
    }
}
