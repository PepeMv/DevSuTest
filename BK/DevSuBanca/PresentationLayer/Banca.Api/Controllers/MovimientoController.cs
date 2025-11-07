using BancaNegocio;
using MediatR;
using Mensajeria;
using Microsoft.AspNetCore.Mvc;

namespace Banca.Api
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class MovimientoController : Controller
    {
        private readonly IMediator _mediator;
        public MovimientoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost(Name = "NuevoMovimiento")]
        [ProducesResponseType(typeof(Unit), StatusCodes.Status200OK)]
        public async Task<IActionResult> NuevoMovimiento([FromBody] NuevoMovimientoMe entrada)
        {
            var request = new NuevoMovimientoRequest { MensajeEntrada = entrada };
            var response = await _mediator.Send(request);
            return Ok(response);
        }


        [HttpPost(Name = "ActualizaMovimiento")]
        [ProducesResponseType(typeof(Unit), StatusCodes.Status200OK)]
        public async Task<IActionResult> ActualizaMovimiento([FromBody] ActualizaMovimientoMe entrada)
        {
            var request = new ActualizaMovimientoRequest { MensajeEntrada = entrada };
            var response = await _mediator.Send(request);
            return Ok(response);
        }


        [HttpPost(Name = "EliminaMovimiento")]
        [ProducesResponseType(typeof(Unit), StatusCodes.Status200OK)]
        public async Task<IActionResult> EliminaMovimiento([FromBody] EliminaMovimientoMe entrada)
        {
            var request = new EliminaMovimientoRequest { MensajeEntrada = entrada };
            var response = await _mediator.Send(request);
            return Ok(response);
        }


        [HttpPost(Name = "DameMovimientosCuentaRangoFechas")]
        [ProducesResponseType(typeof(Unit), StatusCodes.Status200OK)]
        public async Task<IActionResult> DameMovimientosCuentaRangoFechas([FromBody] DameMovimientosCuentaRangoFechasMe entrada)
        {
            var request = new DameMovimientosPorCuentaRangoFechasRequest { MensajeEntrada = entrada };
            var response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
