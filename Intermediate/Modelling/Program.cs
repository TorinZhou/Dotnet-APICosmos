using Dapper;
using Microsoft.Data.SqlClient;
using HelloWorld.Models;
using HelloWorld.Data;
using Microsoft.Extensions.Configuration;
using System.Text;
using System.Text.Json;
using AutoMapper;

namespace HelloWorld;

internal class Program
{

    static void Main(string[] args)
    {
        var config = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build(); //need a new package to gain access to this ConfigurationBuilder

        var dapper = new DataContextDapper(config);

        var computersJson = File.ReadAllText("ComputersSnake.json");

        var mapperConfiguration = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<ComputerSnake, Computer>();
        });
        var mapper = new Mapper(mapperConfiguration);
        // System.Console.WriteLine(computersJson);

        // var options = new JsonSerializerOptions()
        // {
        //     PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        // };

        // IEnumerable<Computer>? computers = JsonSerializer.Deserialize<IEnumerable<Computer>>(computersJson, options);

        // if (computers is not null)
        // {
        //     foreach (var computer in computers)
        //     {
        //         string sql = @"INSERT INTO TutorialAppSchema.Computers (
        //                     Motherboard,
        //                     HasWifi,
        //                     HasLTE,
        //                     ReleaseDate,
        //                     Price,
        //                     VideoCard
        //                     )
        //                     VALUES (
        //                         @Motherboard,
        //                         @HasWifi,
        //                         @HasLTE,
        //                         @ReleaseDate,
        //                         @Price,
        //                         @VideoCard
        //                     )";
        //         dapper.ExecuteSqlWithPayload(sql, computer);
        //     }
        // }


        // string computersJsonSystemTextJson = JsonSerializer.Serialize(computers, options);
        // File.WriteAllText("computersJsonSystemTextJson", computersJsonSystemTextJson);

        System.Console.WriteLine("Success. Press any key to Close.");
        Console.ReadKey();
    }

}
