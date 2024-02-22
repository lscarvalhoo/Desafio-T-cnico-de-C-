using Dapper;
using Microsoft.Data.Sqlite;
using Saldo.Domain.Entities;
using Saldo.Domain.Interfaces.Repository;

namespace Saldo.Infrastructure.Persistence.Repository
{
    public class ContaCorrenteRepository : IContaCorrenteRepository
    {
        public ContaCorrente ObterConta(string contaId)
        {
            using (var connection = DbConnectionFactory.CreateConnection())
            {
                string query = $"SELECT idcontacorrente AS Id, numero AS Numero, nome AS Nome, ativo AS Status FROM contacorrente WHERE idcontacorrente = '{contaId}'"; 
                var conta = connection.QueryFirstOrDefault<ContaCorrente>(query);

                return conta;
            }
        }
    }
}
