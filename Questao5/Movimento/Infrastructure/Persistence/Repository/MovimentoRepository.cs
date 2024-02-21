using Dapper;
using Movimento.Application.Commands.Responses;
using Movimento.Domain.Entities;
using Movimento.Domain.Interfaces.Repositories;

namespace Movimento.Infrastructure.Persistence.Repository
{
    public class MovimentoRepository : IMovimentoRepository
    {
        public CriarMovimentoResponse AddMovimentoAsync(Movimentacao movimentacao)
        {
            CriarMovimentoResponse customResult = new CriarMovimentoResponse();
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
                catch (Exception ex) {
                    return new CriarMovimentoResponse
                    {
                        StatusCode = 400,
                        MensageErro = ex.Message,
                    };
                }
            }
        }
    }
}
