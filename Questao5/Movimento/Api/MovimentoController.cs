using MediatR;
using Microsoft.AspNetCore.Mvc;
using Movimento.Application.Commands.Requests;
using Movimento.Domain.Entities;
using Movimento.Domain.Interfaces.Services;

namespace Movimento.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovimentoController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MovimentoController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpPost]
        [Route("NovaMovimentacao")]
        public async Task<IActionResult> CriarProduto([FromBody] CriarMovimentoCommand command)
        {
            var productId = await _mediator.Send(command);
            return Ok(productId);
        }

        //[HttpGet]
        //[Route("ObterContaCorrente")]
        //public ActionResult<IEnumerable<ContaCorrente>> ObterContaCorrente()
        //{
        //    string idContaCorrente = "B6BAFC09-6967-ED11-A567-055DFA4A16C9";
        //    var products = _contaCorrenteService.ObterContaCorrente(idContaCorrente);

        //    return Ok(products);
        //}
    }
} 
