using Dapper;
using Movimento.Application.Commands.Responses;
using Movimento.Domain.Entities;
using Movimento.Domain.Interfaces.Repositories;

namespace Movimento.Infrastructure.Persistence.Repository
{
    public class MovimentoRepository : IMovimentoRepository
    {
        private readonly IIdempotenciaRepository _idempotenciaRepository;
        private const int OK   = 200;
        private const int ERRO = 400;

        public MovimentoRepository(IIdempotenciaRepository idempotenciaRepository)
        {
            _idempotenciaRepository = idempotenciaRepository;
        }

        public CriarMovimentoResponse NovoMovimento(Movimentacao movimentacao)
        {
            CriarMovimentoResponse criaMovimentoResponse = new CriarMovimentoResponse();
            using (var connection = DbConnectionFactory.CreateConnection())
            {
                try
                {
                    connection.Open();
                    string query = $" INSERT INTO movimento (idmovimento, idcontacorrente, datamovimento, tipomovimento, valor) values ('{movimentacao.Id}', '{movimentacao.IdContaCorrente}', '{movimentacao.DataMovimento}', '{movimentacao.TipoMovimento.ToUpper()}', {movimentacao.Valor});";

                    connection.Execute(query);
                    criaMovimentoResponse = new CriarMovimentoResponse
                    { 
                        IdMovimento = movimentacao.Id,
                    };

                    return criaMovimentoResponse;
                }
                catch (Exception ex)
                {
                    string mensagem = CriarIdempotencia(movimentacao, ex);
                    criaMovimentoResponse.StatusRequisicao = new StatusRequisicao
                    {
                        Code = ERRO
                    };

                    return criaMovimentoResponse;
                }
            }
        }

        private string CriarIdempotencia(Movimentacao movimentacao, Exception ex)
        {
            Idempotencia idempotencia = new Idempotencia
            {
                ChaveIdempotencia = Guid.NewGuid(),
                Requisicao = movimentacao,
                Resultado = ex.Message 
            };

            return _idempotenciaRepository.RegistraFalha(idempotencia);
        }
    }
}
