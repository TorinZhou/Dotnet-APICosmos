using Dapper;
using Microsoft.Data.SqlClient;
using HelloWorld.Models;
using HelloWorld.Data;
using Microsoft.Extensions.Configuration;
using System.Text;
using System.Text.Json;

namespace HelloWorld;

internal class Program
{

    static void Main(string[] args)
    {
        var config = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build(); //need a new package to gain access to this ConfigurationBuilder

        var dapper = new DataContextDapper(config);

        var computersJson = File.ReadAllText("Computers.json");
        System.Console.WriteLine(computersJson);

        var computers = JsonSerializer.Deserialize<Computer>(computersJson);
    }

}
