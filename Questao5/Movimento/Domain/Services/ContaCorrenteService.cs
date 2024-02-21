using Movimentacao.Domain.Entities;
using Movimento.Domain.Interfaces.Repositories;
using Movimento.Domain.Interfaces.Services;

namespace Movimento.Domain.Services
{
    public class ContaCorrenteService : IContaCorrenteService
    {
        private readonly IContaCorrenteRepository _contaCorrenteRepository;

        public ContaCorrenteService(IContaCorrenteRepository contaCorrenteRepository)
        {
            _contaCorrenteRepository = contaCorrenteRepository;
        }

        public ContaCorrente ObterContaCorrente(string id)
        { 
            return _contaCorrenteRepository.ObterContaCorrente(id);
        }
    }
}
