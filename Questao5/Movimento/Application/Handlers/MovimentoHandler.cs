using MediatR;
using Movimento.Application.Commands.Requests;
using Movimento.Application.Commands.Responses;
using Movimento.Domain.Entities;
using Movimento.Domain.Interfaces.Services;

namespace Movimento.Application.Commands
{
    public class MovimentoCommandHandler : IRequestHandler<CriarMovimentoCommand, CriarMovimentoResponse>
    {
        private readonly IMovimentoService _movimentoService;

        public MovimentoCommandHandler(IMovimentoService movimentoService)
        {
            _movimentoService = movimentoService;
        }

        public async Task<CriarMovimentoResponse> Handle(CriarMovimentoCommand request, CancellationToken cancellationToken)
        { 
            var movimento = new Movimentacao
            {
                Id = Guid.NewGuid(),
                IdContaCorrente = request.IdContaCorrente,
                DataMovimento = request.DataMovimento,
                TipoMovimento = request.TipoMovimento,
                Valor = request.Valor
            };

            CriarMovimentoResponse customResult = _movimentoService.AddMovimentoAsync(movimento);
             
            return customResult;
        }
    }
}