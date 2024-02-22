using Movimento.Application.Commands.Responses;
using Movimento.Domain.Entities;

namespace Movimento.Domain.Interfaces.Services
{
    public interface IMovimentoService
    {
        public CriarMovimentoResponse CriarMovimento(Movimentacao movimentacao);
    }
}
