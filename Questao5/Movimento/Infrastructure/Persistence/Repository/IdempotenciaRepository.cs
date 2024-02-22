using Dapper;
using Movimento.Domain.Entities;
using Movimento.Domain.Interfaces.Repositories;
using System.Text.Json;
namespace Movimento.Infrastructure.Persistence.Repository
{
    public class IdempotenciaRepository : IIdempotenciaRepository
    {
        public const string MENSAGEM_IDEMPOTENCIA_REGISTRADA = "Aviso, falha na operação e será realizada novamente!";

        public string RegistraFalha(Idempotencia idempotencia)
        {
            var requisicao = new Movimentacao
            {
                Id = idempotencia.Requisicao.Id,
                IdContaCorrente = idempotencia.Requisicao.IdContaCorrente,
                DataMovimento = idempotencia.Requisicao.DataMovimento,
                TipoMovimento = idempotencia.Requisicao.TipoMovimento,
                Valor = idempotencia.Requisicao.Valor
            };  
            string requestJson = JsonSerializer.Serialize(requisicao);

            try
            {
                using (var connection = DbConnectionFactory.CreateConnection())
                {
                    connection.Open();
                    string query = $" INSERT INTO idempotencia (chave_idempotencia, requisicao, resultado) values ('{Guid.NewGuid()}', '{requestJson}', '{idempotencia.Resultado}')";

                    connection.Execute(query);
                }

                return MENSAGEM_IDEMPOTENCIA_REGISTRADA;
            }

            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
