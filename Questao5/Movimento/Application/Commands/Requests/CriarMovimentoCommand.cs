using MediatR;
using Movimento.Application.Commands.Responses;
using Movimento.Domain.Enumerators;

namespace Movimento.Application.Commands.Requests
{
    public class CriarMovimentoCommand : IRequest<CriarMovimentoResponse>
    {
        public string IdContaCorrente { get; set; }

        public DateTime DataMovimento { get; set; }

        public string TipoMovimento { get; set; }

        public decimal Valor { get; set; }
    }
}
