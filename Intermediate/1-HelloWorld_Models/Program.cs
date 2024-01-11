using Dapper;
using Microsoft.Data.SqlClient;

namespace HelloWorld;

internal class Program
{

    static void Main(string[] args)
    {
        string connectionString = "Server=localhost;Database=DotNetCourseDatabase;Trusted_Connection=true;TrustServerCertificate=true";

        var dbConnection = new SqlConnection(connectionString);

        string sqlCommand = "SELECT GETDATE()";

        var result = dbConnection.QuerySingle<DateTime>(sqlCommand);

        System.Console.WriteLine(result);

    }

}
