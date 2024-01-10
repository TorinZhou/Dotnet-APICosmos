using Dapper;
using HelloWorld.Models;
using Microsoft.Data.SqlClient;

namespace HelloWorld;


internal class Program
{


    static void Main(string[] args)
    {
        string connectionString = "Server=localhost;Database=DotNetCourseDatabase;Trusted_Connection=true,TrustServerCertificate=true";

        var dbConnection = new SqlConnection(connectionString);

        string sqlCommand = "SELECT GETDATE()";

        var result = dbConnection.QuerySingle<DateTime>(sqlCommand);

        System.Console.WriteLine(result);

        // Computer myComputer = new Computer()
        // {
        //     Motherboard = "Z690",
        //     HasWifi = true,
        //     HasLTE = false,
        //     ReleaseDate = DateTime.Now,
        //     Price = 943.87m,
        //     VideoCard = "RTX 2060"
        // };
        // myComputer.HasWifi = false;
        // Console.WriteLine(myComputer.Motherboard);
        // Console.WriteLine(myComputer.HasWifi);
        // Console.WriteLine(myComputer.ReleaseDate);
        // Console.WriteLine(myComputer.VideoCard);
    }

}
