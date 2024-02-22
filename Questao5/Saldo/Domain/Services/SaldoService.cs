using Saldo.Domain.Entities;
using Saldo.Domain.Interfaces.Repository;
using Saldo.Domain.Interfaces.Services;

namespace Saldo.Domain.Services
{
    public class SaldoService : ISaldoService
    {
        private readonly ISaldoRepository _saldoRepository;

        public SaldoService(ISaldoRepository saldoRepository)
        {
            _saldoRepository = saldoRepository;
        }
        public SaldoConta ObterSaldo(string conta)
        {
            return _saldoRepository.ObterSaldo(conta);
        }
    }
}
