using Movimento.Application.Commands.Responses;
using Movimento.Domain.Entities;

namespace Movimento.Domain.Interfaces.Repositories
{
    public interface IMovimentoRepository
    {
        public CriarMovimentoResponse AddMovimentoAsync(Movimentacao movimentacao);
    }
}
