using Dapper;
using Microsoft.Data.Sqlite;
using Saldo.Domain.Entities;
using Saldo.Domain.Interfaces.Repository;

namespace Saldo.Infrastructure.Persistence.Repository
{
    public class SaldoRepository : ISaldoRepository
    {
        private const string CREDITADOS = "C";
        private const string DEBITADOS  = "D";
        public SaldoConta ObterSaldo(string contaId)
        {
            using (var connection = DbConnectionFactory.CreateConnection())
            {
                ContaCorrente conta = ObterDadosConta(contaId, connection);
                List<Movimentacao> movimentos = ObterMovimentacoes(contaId, connection); 

                return new SaldoConta
                {
                    Conta = conta.Numero,
                    Titular = conta.Nome,
                    DataReposta = DateTime.Now,
                    ValorConta = ObterValor(movimentos)

                };
            }
        }

        private decimal ObterValor(List<Movimentacao> movimentos)
        {
            var valoresDebitados = movimentos.Where(d => d.TipoMovimento == DEBITADOS).Sum(item => item.Valor);
            var valoresCreditados = movimentos.Where(d => d.TipoMovimento == CREDITADOS).Sum(item => item.Valor);

            return valoresCreditados - valoresDebitados;
        }

        private List<Movimentacao> ObterMovimentacoes(string contaId, SqliteConnection connection)
        {
            string query = $"SELECT tipomovimento AS TipoMovimento, valor AS Valor FROM movimento WHERE idcontacorrente = '{contaId}'";
            var conta = connection.Query<Movimentacao>(query).AsList();

            return conta;
        }

        private static ContaCorrente ObterDadosConta(string contaId, SqliteConnection connection)
        {
            string query = $"SELECT idcontacorrente AS Id, numero AS Numero, nome AS Nome, ativo AS Ativo FROM contacorrente WHERE idcontacorrente = '{contaId}'";
            var conta = connection.QueryFirstOrDefault<ContaCorrente>(query);

            return conta;
        }
    }
}
