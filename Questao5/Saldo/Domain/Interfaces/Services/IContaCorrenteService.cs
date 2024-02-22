using Saldo.Domain.Entities;

namespace Saldo.Domain.Interfaces.Services
{
    public interface IContaCorrenteService
    {
        public ContaCorrente ObterConta(string conta);
    }
}
