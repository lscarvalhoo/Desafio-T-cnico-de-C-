using MediatR;
using Saldo.Application.Queries.Requests;
using Saldo.Application.Queries.Responses;
using Saldo.Domain.Entities;
using Saldo.Domain.Enumerators;
using Saldo.Domain.Interfaces.Services;

namespace Saldo.Application.Handlers
{
    public class SaldoQueryHandler : IRequestHandler<ConsultaSaldoQuery, ConsultaSaldoResponse>
    {
        private const int ERRO = 400;
        private const int OK = 200;
        private readonly ISaldoService _saldoService;
        private readonly IContaCorrenteService _contaCorrenteService;
        public SaldoQueryHandler(ISaldoService saldoService, IContaCorrenteService contaCorrenteService)
        {
            _saldoService = saldoService;
            _contaCorrenteService = contaCorrenteService;
        }

        public async Task<ConsultaSaldoResponse> Handle(ConsultaSaldoQuery request, CancellationToken cancellationToken)
        {
            ConsultaSaldoResponse consultaSaldoResponse = new ConsultaSaldoResponse();
            string erro = ValidarParametros(request);
            if (erro == null)
            {
                SaldoConta saldo = _saldoService.ObterSaldo(request.Conta);
                consultaSaldoResponse.DadosConta = new DadosConta
                {
                    Conta = saldo.Conta,
                    Titular = saldo.Titular,
                    DataReposta = saldo.DataReposta,
                    ValorConta = saldo.ValorConta
                };
                consultaSaldoResponse.StatusRequisicao = new StatusRequisicao { Code = OK};
                return consultaSaldoResponse;
            }
            else
            {
                consultaSaldoResponse.StatusRequisicao = new StatusRequisicao { Code = ERRO, MensageErro = erro };

                return consultaSaldoResponse;
            }

        }

        private string ValidarParametros(ConsultaSaldoQuery request)
        {
            ContaCorrente conta = _contaCorrenteService.ObterConta(request.Conta);

            if (conta == null)
                return "INVALID_ACCOUNT";
            if (conta.Status != Status.Ativo)
                return "INACTIVE_ACCOUNT";
            else
                return null;
        }
    }
}
