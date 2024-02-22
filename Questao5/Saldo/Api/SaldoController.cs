using MediatR;
using Microsoft.AspNetCore.Mvc;
using Saldo.Application.Queries.Requests;

namespace Saldo.Api
{

    [Route("api/[controller]")]
    [ApiController]
    public class SaldoController : ControllerBase
    {
        private const int ERRO = 400;
        private readonly IMediator _mediator;

        public SaldoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("ConsultarSaldoQuery")]
        public async Task<IActionResult> CriarProduto([FromBody] ConsultaSaldoQuery query)
        {
            var response = await _mediator.Send(query);

            if (response.StatusRequisicao.Code == ERRO)
                return BadRequest(response.StatusRequisicao);
            else
                return Ok(response.DadosConta);
        }
    }
}
