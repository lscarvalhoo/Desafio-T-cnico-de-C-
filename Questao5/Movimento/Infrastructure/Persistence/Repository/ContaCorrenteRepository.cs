using Dapper;
using Movimento.Domain.Entities;
using Movimento.Domain.Interfaces.Repositories;

public class ContaCorrenteRepository : IContaCorrenteRepository
{
    public ContaCorrente ObterContaCorrente(string id)
    {
        using (var connection = DbConnectionFactory.CreateConnection())
        {
            string query = $"SELECT idcontacorrente AS Id, numero AS Numero, nome AS Nome, ativo AS Ativo FROM contacorrente WHERE idcontacorrente = '{id}'";

            var conta = connection.QueryFirstOrDefault<ContaCorrente>(query);

            return conta;
        }
    }
}
