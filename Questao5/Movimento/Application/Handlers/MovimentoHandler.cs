using MediatR;
using Movimento.Application.Commands.Requests;
using Movimento.Application.Commands.Responses;
using Movimento.Domain.Entities;
using Movimento.Domain.Enumerators;
using Movimento.Domain.Interfaces.Services;

namespace Movimento.Application.Commands
{
    public class MovimentoCommandHandler : IRequestHandler<CriarMovimentoCommand, CriarMovimentoResponse>
    {
        private const int ERRO = 400;
        private readonly IMovimentoService _movimentoService;
        private readonly IContaCorrenteService _contaCorrenteService;

        public MovimentoCommandHandler(IMovimentoService movimentoService,
                                       IContaCorrenteService contaCorrenteService)
        {
            _movimentoService = movimentoService;
            _contaCorrenteService = contaCorrenteService;
        }

        public async Task<CriarMovimentoResponse> Handle(CriarMovimentoCommand request, CancellationToken cancellationToken)
        {
            string erro = ValidarParametros(request);
            if (erro == null)
            {
                var movimento = new Movimentacao
                {
                    Id = Guid.NewGuid(),
                    IdContaCorrente = request.IdContaCorrente,
                    DataMovimento = request.DataMovimento,
                    TipoMovimento = request.TipoMovimento,
                    Valor = request.Valor
                };

                CriarMovimentoResponse customResult = _movimentoService.CriarMovimento(movimento);

                return customResult;
            }
            else
            {
                return new CriarMovimentoResponse
                {
                    StatusCode = ERRO,
                    MensageErro = erro
                };
            }
        }

        private string ValidarParametros(CriarMovimentoCommand request)
        {
            ContaCorrente conta = _contaCorrenteService.ObterContaCorrente(request.IdContaCorrente);

            if (conta == null)
                return "INVALID_ACCOUNT";
            if (conta.Ativo != Status.Ativo)
                return "INACTIVE_ACCOUNT";
            if (request.Valor < 0)
                return "INVALID_VALUE";
            if (request.TipoMovimento != "C" && request.TipoMovimento != "D")
                return "INVALID_TYPE"; 
            else 
                return null;
        }
    }
}