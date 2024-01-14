namespace HelloWorld.Models;

public class ComputerSnake
{
    // private string _motherboard;
    public int computer_id { get; set; }
    public string motherboard { get; set; } = "";
    public int? cpu_cores { get; set; } = 8; //Delete this question mark, the code would broke.EF Core don't like it. because in my database, some rows(rows created by dapper are all null for cpucores.)
    public bool has_wifi { get; set; }
    public bool has_lte { get; set; }
    public DateTime? release_date { get; set; }
    public decimal price { get; set; }
    public string video_card { get; set; } = "GTX 1060";


    public override string ToString()
    {
        return $"ComputerId: {computer_id}\nMotherboard: {motherboard}\nCPUCores: {cpu_cores}\nHasWifi: {has_wifi}\nHasLTE: {has_lte}\nReleaseDate: {release_date}\nPrice: {price}\nVideoCard: {video_card}";
    }
}