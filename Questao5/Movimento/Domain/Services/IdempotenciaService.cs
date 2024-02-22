using Movimento.Domain.Entities;
using Movimento.Domain.Interfaces.Repositories;
using Movimento.Domain.Interfaces.Services;

namespace Movimento.Domain.Services
{
    public class IdempotenciaService : IIdempotenciaService
    {
        private readonly IIdempotenciaRepository _idempotenciaRepository;

        public IdempotenciaService(IIdempotenciaRepository idempotenciaRepository)
        {
            _idempotenciaRepository = idempotenciaRepository;
        }

        public string RegistraFalha(Idempotencia idempotencia)
        {
            return _idempotenciaRepository.RegistraFalha(idempotencia);
        }
    }
}
