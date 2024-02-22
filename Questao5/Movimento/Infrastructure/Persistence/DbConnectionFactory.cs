using Microsoft.Data.Sqlite;

public class DbConnectionFactory
{
    public static SqliteConnection CreateConnection()
    {
        var connectionStringBuilder = new SqliteConnectionStringBuilder();
        connectionStringBuilder.DataSource = "database.sqlite";

        var connection = new SqliteConnection(connectionStringBuilder.ConnectionString);
        connection.Open();
        return connection;
    }
}
