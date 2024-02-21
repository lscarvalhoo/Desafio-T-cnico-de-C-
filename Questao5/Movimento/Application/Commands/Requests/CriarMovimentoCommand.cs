using MediatR;
using Movimento.Application.Commands.Responses;

namespace Movimento.Application.Commands.Requests
{
    public class CriarMovimentoCommand : IRequest<CriarMovimentoResponse>
    {
        public string IdContaCorrente { get; set; }
        public DateTime DataMovimento { get; set; }
        public char TipoMovimento { get; set; }
        public decimal Valor { get; set; }
    }
}
