using Movimentacao.Domain.Entities;

namespace Movimento.Domain.Interfaces.Services
{
    public interface IContaCorrenteService
    {
        public ContaCorrente ObterContaCorrente(string id);
    }
}
