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
        private const int OK   = 200;
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
            CriarMovimentoResponse criaMovimentoResponse = new CriarMovimentoResponse();
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
                customResult.StatusRequisicao = new StatusRequisicao { Code = OK };

                return customResult;
            }
            else
            {
                criaMovimentoResponse.StatusRequisicao = new StatusRequisicao { Code = ERRO, MensageErro = erro };
                return criaMovimentoResponse;
            }
        }

        private string ValidarParametros(CriarMovimentoCommand request)
        {
            ContaCorrente conta = _contaCorrenteService.ObterContaCorrente(request.IdContaCorrente);

            if (conta == null)
                return "INVALID_ACCOUNT";
            if (conta.Status != Status.Ativo)
                return "INACTIVE_ACCOUNT";
            if (request.Valor < 0)
                return "INVALID_VALUE";
            if (request.TipoMovimento.ToUpper() != "C" && request.TipoMovimento.ToUpper() != "D")
                return "INVALID_TYPE"; 
            else 
                return null;
        }
    }
}