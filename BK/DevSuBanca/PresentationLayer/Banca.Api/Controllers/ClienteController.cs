using BancaNegocio;
using MediatR;
using Mensajeria;
using Microsoft.AspNetCore.Mvc;

namespace Banca.Api
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ClienteController : Controller
    {
        private readonly IMediator _mediator;
        public ClienteController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpPost(Name = "NuevoCliente")]
        [ProducesResponseType(typeof(Unit), StatusCodes.Status200OK)]
        public async Task<IActionResult> NuevoCliente([FromBody] NuevoClienteMe entrada)
        {
            var request = new NuevoClienteRequest { MensajeEntrada = entrada };
            var response = await _mediator.Send(request);
            return Ok(response);
        }


        [HttpPost(Name = "ActualizaCliente")]
        [ProducesResponseType(typeof(Unit), StatusCodes.Status200OK)]
        public async Task<IActionResult> ActualizaCliente([FromBody] ActualizaClienteMe entrada)
        {
            var request = new ActualizaClienteRequest { MensajeEntrada = entrada };
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost(Name = "EliminaCliente")]
        [ProducesResponseType(typeof(Unit), StatusCodes.Status200OK)]
        public async Task<IActionResult> EliminaCliente([FromBody] EliminaClienteMe entrada)
        {
            var request = new EliminaClienteRequest { MensajeEntrada = entrada };
            var response = await _mediator.Send(request);
            return Ok(response);
        }


        [HttpPost(Name = "DameTodosClientes")]
        [ProducesResponseType(typeof(List<ResumenCliente>), StatusCodes.Status200OK)]
        public async Task<IActionResult> DameTodosClientes()
        {
            var request = new DameTodosClientesRequest { };
            var response = await _mediator.Send(request);
            return Ok(response);
        }


    }
}
