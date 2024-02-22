using Saldo.Domain.Entities;

namespace Saldo.Domain.Interfaces.Repository
{
    public interface ISaldoRepository
    {
        public SaldoConta ObterSaldo(string conta);
    }
}
