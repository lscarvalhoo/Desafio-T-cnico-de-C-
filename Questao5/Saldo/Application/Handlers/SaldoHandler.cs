using MediatR;
using Saldo.Application.Queries.Requests;
using Saldo.Application.Queries.Responses;
using Saldo.Domain.Entities;
using Saldo.Domain.Interfaces.Services;

namespace Saldo.Application.Handlers
{
    public class SaldoQueryHandler : IRequestHandler<ConsultaSaldoQuery, ConsultaSaldoResponse>
    {
        private readonly ISaldoService _saldoService;  
        public SaldoQueryHandler(ISaldoService saldoService)
        {
            _saldoService = saldoService;
        }

        public async Task<ConsultaSaldoResponse> Handle(ConsultaSaldoQuery request, CancellationToken cancellationToken)
        {
            SaldoConta response = _saldoService.ObterSaldo(request.Conta);
            ConsultaSaldoResponse rep = new ConsultaSaldoResponse
            {
                Conta = response.Conta,
                Titular = response.Titular,
                DataReposta = response.DataReposta,
                ValorConta = response.ValorConta
            }; 

            return rep;
        }
    }
}
