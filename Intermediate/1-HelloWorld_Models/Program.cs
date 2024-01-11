using Dapper;
using Microsoft.Data.SqlClient;
using HelloWorld.Models;
using HelloWorld.Data;

namespace HelloWorld;

internal class Program
{

    static void Main(string[] args)
    {
        var dapper = new DataContextDapper();

        string sqlCommand = "SELECT GETDATE()";

        var databaseTime = dapper.LoadDataSingle<DateTime>(sqlCommand);

        System.Console.WriteLine(databaseTime);

        var myComputer = new Computer()
        {
            Motherboard = "B650m Aorus elite ax",
            HasWifi = true,
            HasLTE = false,
            ReleaseDate = DateTime.Now,
            Price = 2000.88m,
            VideoCard = "RTX 4070"
        };

        string sql = @"INSERT INTO TutorialAppSchema.Computer (
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
                                Computer.Motherboard,
                                Computer.HasWifi,
                                Computer.HasLTE,
                                Computer.ReleaseDate,
                                Computer.Price,
                                Computer.VideoCard 
                            FROM TutorialAppSchema.Computer";

        var computers = dapper.LoadData<Computer>(sqlSelect);

        foreach (var computer in computers)
        {
            System.Console.WriteLine(computer);
            System.Console.WriteLine("--------------------------");
        }
        Console.ReadKey();
    }

}
