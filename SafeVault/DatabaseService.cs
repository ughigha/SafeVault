using System.Data.SQLite;

public class DatabaseService
{
private readonly string connectionString = "Data Source=C:\\Users\\ughig\\SafeVault\\database.sql;";

public void ExecuteParameterizedQuery(string query, Dictionary<string, object> parameters)
{
using (SQLiteConnection connection = new SQLiteConnection(connectionString))
{
connection.Open();
using (SQLiteCommand command = new SQLiteCommand(query, connection))
{
foreach (var parameter in parameters)
{
command.Parameters.AddWithValue(parameter.Key, parameter.Value);
}
command.ExecuteNonQuery();
}
}
}
}
