using Movimento.Domain.Entities;

namespace Movimento.Domain.Interfaces.Services
{
    public interface IIdempotenciaService
    {
        public string RegistraFalha(Idempotencia idempotencia);
    }
}
