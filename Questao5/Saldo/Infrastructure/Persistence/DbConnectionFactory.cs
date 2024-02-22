using Microsoft.Data.Sqlite;
  
namespace Saldo.Infrastructure.Persistence
{
    public class DbConnectionFactory
    {
        public static SqliteConnection CreateConnection()
        {
            var connectionStringBuilder = new SqliteConnectionStringBuilder();
            connectionStringBuilder.DataSource = "C:\\Users\\leona\\Downloads\\Desafio Técnico de C#\\Questao5\\Movimento\\database.sqlite";

            var connection = new SqliteConnection(connectionStringBuilder.ConnectionString);
            connection.Open();
            return connection;
        }
    }
}
