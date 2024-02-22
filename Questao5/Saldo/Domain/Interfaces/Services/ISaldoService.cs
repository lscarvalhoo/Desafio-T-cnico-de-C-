using Saldo.Domain.Entities;

namespace Saldo.Domain.Interfaces.Services
{
    public interface ISaldoService
    {
        public SaldoConta ObterSaldo(string conta);
    }
}
