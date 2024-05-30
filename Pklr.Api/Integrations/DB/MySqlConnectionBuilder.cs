using System.Data;
using MySql.Data.MySqlClient;

namespace Pklr.Api.Integrations.DB;

public class MySqlConnectionBuilder(string connectionString)
{
    public IDbConnection Connect()
    {
        return new MySqlConnection(connectionString);
    }
}