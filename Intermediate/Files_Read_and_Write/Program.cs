using Dapper;
using Microsoft.Data.SqlClient;
using HelloWorld.Models;
using HelloWorld.Data;
using Microsoft.Extensions.Configuration;
using System.Text;

namespace HelloWorld;

internal class Program
{

    static void Main(string[] args)
    {
        var config = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build(); //need a new package to gain access to this ConfigurationBuilder

        var myComputer = new Computer()
        {
            Motherboard = "B650m Aorus elite ax",
            HasWifi = true,
            HasLTE = false,
            ReleaseDate = DateTime.Now,
            Price = 2000.88m,
            VideoCard = "RTX 4070"
        };
        var myFutureComputer = new Computer()
        {
            Motherboard = "B650m Aorus pro ax",
            HasWifi = true,
            HasLTE = true,
            ReleaseDate = DateTime.Now,
            Price = 4000.88m,
            VideoCard = "RTX 4090"
        };

        var dapper = new DataContextDapper(config);
        string sql = @"INSERT INTO TutorialAppSchema.Computers (
                            Motherboard,
                            HasWifi,
                            HasLTE,
                            ReleaseDate,
                            Price,
                            VideoCard
                        )
                        VALUES (
                            @Motherboard,
                            @HasWifi,
                            @HasLTE,
                            @ReleaseDate,
                            @Price,
                            @VideoCard
                        )";

        // bool result = dapper.ExecuteSqlWithPayload(sql, myComputer);

        // File.WriteAllText("log.txt", sql, Encoding.UTF8);

        using (var sw = new StreamWriter(path: "log.txt", append: true))
        {
            sw.WriteLine(DateTime.Now.ToString());
            sw.WriteLine(sql);
        }

        using (var sr = new StreamReader(path: "log.txt"))
        {
            var result = sr.ReadToEnd();
            Console.WriteLine(result);
        }

        // Console.ReadKey();
    }

}
