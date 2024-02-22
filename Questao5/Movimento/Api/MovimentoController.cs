using MediatR;
using Microsoft.AspNetCore.Mvc;
using Movimento.Application.Commands.Requests;

namespace Movimento.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovimentoController : ControllerBase
    {
        private const int ERRO = 400;
        private readonly IMediator _mediator;

        public MovimentoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("NovaMovimentacao")]
        public async Task<IActionResult> CriarProduto([FromBody] CriarMovimentoCommand command)
        {
            var response = await _mediator.Send(command);

            if (response.StatusRequisicao.Code == ERRO)
                return BadRequest(response.StatusRequisicao);
            else
                return Ok(response.IdMovimento);
        } 
    }
}
