using Microsoft.AspNetCore.Mvc;
using Movimentacao.Domain.Entities;
using Movimento.Domain.Interfaces.Services;

namespace Movimento.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovimentoController : ControllerBase
    {
        private readonly IContaCorrenteService _contaCorrenteService;

        public MovimentoController(IContaCorrenteService contaCorrenteService)
        {
            _contaCorrenteService = contaCorrenteService;
        } 

        [HttpGet]
        [Route("ObterContaCorrente")]
        public ActionResult<IEnumerable<ContaCorrente>> ObterContaCorrente()
        {
            string idContaCorrente = "B6BAFC09-6967-ED11-A567-055DFA4A16C9";
            var products = _contaCorrenteService.ObterContaCorrente(idContaCorrente);

            return Ok(products);
        }
    }
}
