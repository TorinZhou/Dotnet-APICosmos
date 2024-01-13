using Dapper;
using Microsoft.Data.SqlClient;
using HelloWorld.Models;
using HelloWorld.Data;
using Microsoft.Extensions.Configuration;

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

        bool result = dapper.ExecuteSqlWithPayload(sql, myComputer);

        string sqlSelect = @"SELECT 
                                Computers.ComputerId,
                                Computers.Motherboard,
                                Computers.HasWifi,
                                Computers.HasLTE,
                                Computers.ReleaseDate,
                                Computers.Price,
                                Computers.VideoCard 
                            FROM TutorialAppSchema.Computers";

        var computers = dapper.LoadData<Computer>(sqlSelect);

        foreach (var computer in computers)
        {
            System.Console.WriteLine(computer);
            System.Console.WriteLine("--------------------------");
        }
        using (var entityFrameworkCore = new DataContextEF(config))
        {
            entityFrameworkCore.Add(myFutureComputer);
            entityFrameworkCore.SaveChanges();
            var computersEF = entityFrameworkCore.Computers;
            foreach (var computer in computersEF)
            {
                System.Console.WriteLine(computer);
                System.Console.WriteLine("--------------------------");
            }
        }

        Console.ReadKey();
    }

}
