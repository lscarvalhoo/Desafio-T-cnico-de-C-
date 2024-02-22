using Microsoft.Data.Sqlite;
  
namespace Saldo.Infrastructure.Persistence
{
    public class DbConnectionFactory
    {
        public static SqliteConnection CreateConnection()
        {
            var connectionStringBuilder = new SqliteConnectionStringBuilder();
            connectionStringBuilder.DataSource = "SQL_PATH";

            var connection = new SqliteConnection(connectionStringBuilder.ConnectionString);
            connection.Open();
            return connection;
        }
    }
}
