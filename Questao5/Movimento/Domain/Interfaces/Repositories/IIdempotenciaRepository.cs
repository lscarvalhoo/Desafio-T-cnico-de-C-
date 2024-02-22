using Movimento.Domain.Entities;

namespace Movimento.Domain.Interfaces.Repositories
{
    public interface IIdempotenciaRepository
    {
        public string RegistraFalha(Idempotencia movimentacao);
    }
}
