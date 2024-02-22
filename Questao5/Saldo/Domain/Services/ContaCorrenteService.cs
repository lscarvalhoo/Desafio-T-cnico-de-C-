using Saldo.Domain.Entities;
using Saldo.Domain.Interfaces.Repository;
using Saldo.Domain.Interfaces.Services;
using Saldo.Infrastructure.Persistence.Repository;

namespace Saldo.Domain.Services
{
    public class ContaCorrenteService : IContaCorrenteService
    {
        private readonly IContaCorrenteRepository _contaCorrenteRepository;

        public ContaCorrenteService(IContaCorrenteRepository contaCorrenteRepository)
        {
            _contaCorrenteRepository = contaCorrenteRepository;
        } 

        public ContaCorrente ObterConta(string contaId)
        {
            return _contaCorrenteRepository.ObterConta(contaId);
        }
    }
}
