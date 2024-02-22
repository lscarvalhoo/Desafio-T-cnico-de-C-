using Dapper;
using Movimento.Application.Commands.Responses;
using Movimento.Domain.Entities;
using Movimento.Domain.Interfaces.Repositories;

namespace Movimento.Infrastructure.Persistence.Repository
{
    public class MovimentoRepository : IMovimentoRepository
    {
        private readonly IIdempotenciaRepository _idempotenciaRepository;

        public MovimentoRepository(IIdempotenciaRepository idempotenciaRepository)
        {
            _idempotenciaRepository = idempotenciaRepository;
        }

        public CriarMovimentoResponse NovoMovimento(Movimentacao movimentacao)
        {
            using (var connection = DbConnectionFactory.CreateConnection())
            {
                try
                {
                    connection.Open();
                    string query = $" INSERT INTO movimento (idmovimento, idcontacorrente, datamovimento, tipomovimento, valor) values ('{movimentacao.Id}', '{movimentacao.IdContaCorrente}', '{movimentacao.DataMovimento}', '{movimentacao.TipoMovimento}', {movimentacao.Valor});";

                    connection.Execute(query);
                    return new CriarMovimentoResponse
                    {
                        StatusCode = 200,
                        IdMovimento = movimentacao.Id,
                    };
                }
                catch (Exception ex)
                {
                    string mensagem = CriarIdempotencia(movimentacao, ex);
                    return new CriarMovimentoResponse
                    {
                        StatusCode = 400,
                        MensageErro = mensagem,
                    };
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
