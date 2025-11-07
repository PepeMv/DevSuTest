using BancaEntidades;
using Contexto;
using MediatR;
using Mensajeria;

namespace BancaNegocio
{
    public class DameTodosClientesRequest : IRequest<List<ResumenCliente>>
    {

    }
    public class DameTodosClientesHandler : IRequestHandler<DameTodosClientesRequest, List<ResumenCliente>>
    {
        private readonly BancaContexto _ctx;

        public DameTodosClientesHandler(BancaContexto ctx)
        {
            _ctx = ctx;
        }

        public async Task<List<ResumenCliente>> Handle(DameTodosClientesRequest request, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;

            return
                _ctx
                .DameRegistrosSinFiltro<Cliente>()
                .Select(x => new ResumenCliente(x.Id,
                                                x.Persona.Nombre,
                                                x.Persona.Genero,
                                                x.Persona.FechaNacimiento,
                                                x.Persona.Identificacion,
                                                x.Persona.Direccion,
                                                x.Persona.Telefono,
                                                x.Contrasenia,
                                                x.Estado))
                .ToList();

        }
    }
}
