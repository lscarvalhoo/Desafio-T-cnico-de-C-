using Saldo.Domain.Entities;

namespace Saldo.Domain.Interfaces.Repository
{
    public interface IContaCorrenteRepository
    {
        public ContaCorrente ObterConta(string conta);
    }
}
