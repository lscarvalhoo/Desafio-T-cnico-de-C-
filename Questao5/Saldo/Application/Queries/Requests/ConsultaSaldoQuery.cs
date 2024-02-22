using MediatR;
using Saldo.Application.Queries.Responses;

namespace Saldo.Application.Queries.Requests
{
    public class ConsultaSaldoQuery : IRequest<ConsultaSaldoResponse>
    {
        public string Conta { get; set; }
    }
}
