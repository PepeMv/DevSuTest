using BancaNegocio;
using MediatR;
using Mensajeria;
using Microsoft.AspNetCore.Mvc;

namespace Banca.Api
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class CuentaController : Controller
    {
        private readonly IMediator _mediator;
        public CuentaController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpPost(Name = "NuevaCuenta")]
        [ProducesResponseType(typeof(Unit), StatusCodes.Status200OK)]
        public async Task<IActionResult> NuevaCuenta([FromBody] NuevaCuentaMe entrada)
        {
            var request = new NuevaCuentaRequest { MensajeEntrada = entrada };
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost(Name = "ActualizaCuenta")]
        [ProducesResponseType(typeof(Unit), StatusCodes.Status200OK)]
        public async Task<IActionResult> ActualizaCuenta([FromBody] ActualizarCuentaMe entrada)
        {
            var request = new ActualizaCuentaRequest { MensajeEntrada = entrada };
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost(Name = "EliminaCuenta")]
        [ProducesResponseType(typeof(Unit), StatusCodes.Status200OK)]
        public async Task<IActionResult> EliminaCuenta([FromBody] EliminaCuentaMe entrada)
        {
            var request = new EliminaCuentaRequest { MensajeEntrada = entrada };
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost(Name = "DameCuentasPorIdCliente")]
        [ProducesResponseType(typeof(List<ResumenCuenta>), StatusCodes.Status200OK)]
        public async Task<IActionResult> DameCuentasPorIdCliente([FromBody] DameCuentasPorIdClienteMe entrada)
        {
            var request = new DameCuentasPorIdClienteRequest { MensajeEntrada = entrada };
            var response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
