namespace HelloWorld.Models;

public class Computer
{
    // private string _motherboard;
    public int ComputerId { get; set; }
    public string Motherboard { get; set; } = "";
    public int? CPUCores { get; set; } = 8; //Delete this question mark, the code would broke.EF Core don't like it. because in my database, some rows(rows created by dapper are all null for cpucores.)
    public bool HasWifi { get; set; }
    public bool HasLTE { get; set; }
    public DateTime ReleaseDate { get; set; }
    public decimal Price { get; set; }
    public string VideoCard { get; set; } = "GTX 1060";

    public Computer()
    {
        if (VideoCard == null)
        {
            VideoCard = "";
        }
        if (Motherboard == null)
        {
            Motherboard = "";
        }
    }
    public override string ToString()
    {
        return $"ComputerId: {ComputerId}\nMotherboard: {Motherboard}\nCPUCores: {CPUCores}\nHasWifi: {HasWifi}\nHasLTE: {HasLTE}\nReleaseDate: {ReleaseDate}\nPrice: {Price}\nVideoCard: {VideoCard}";
    }
}