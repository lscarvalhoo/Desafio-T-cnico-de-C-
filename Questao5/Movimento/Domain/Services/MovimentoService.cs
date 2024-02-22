using Movimento.Application.Commands.Responses;
using Movimento.Domain.Entities;
using Movimento.Domain.Interfaces.Repositories;
using Movimento.Domain.Interfaces.Services;

namespace Movimento.Domain.Services
{
    public class MovimentoService : IMovimentoService
    {
        private readonly IMovimentoRepository _movimentoRepository;

        public MovimentoService(IMovimentoRepository movimentoRepository)
        {
            _movimentoRepository = movimentoRepository;
        }  

        public CriarMovimentoResponse CriarMovimento(Movimentacao movimentacao)
        {
            return _movimentoRepository.NovoMovimento(movimentacao);
        }
    }
}
