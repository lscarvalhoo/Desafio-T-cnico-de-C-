using Microsoft.Data.Sqlite;

public class DbConnectionFactory
{
    public static SqliteConnection CreateConnection()
    {
        var connectionStringBuilder = new SqliteConnectionStringBuilder();
        connectionStringBuilder.DataSource = "database.sqlite"; // Nome do arquivo do banco de dados SQLite

        var connection = new SqliteConnection(connectionStringBuilder.ConnectionString);
        connection.Open();
        return connection;
    }
}
