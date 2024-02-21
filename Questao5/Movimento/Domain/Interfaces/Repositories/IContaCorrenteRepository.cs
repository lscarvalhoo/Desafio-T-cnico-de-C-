using Movimentacao.Domain.Entities;

namespace Movimento.Domain.Interfaces.Repositories
{
    public interface IContaCorrenteRepository
    {
        public ContaCorrente ObterContaCorrente(string id);
    }
}
