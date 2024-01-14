using System.Text.Json.Serialization;

namespace HelloWorld.Models;

public class Computer
{
    // private string _motherboard;
    [JsonPropertyName("computer_id")]
    public int ComputerId { get; set; }

    [JsonPropertyName("motherboard")]
    public string Motherboard { get; set; } = "";

    [JsonPropertyName("cpu_cores")]
    public int? CPUCores { get; set; } = 8; //Delete this question mark, the code would broke.EF Core don't like it. because in my database, some rows(rows created by dapper are all null for cpucores.)

    [JsonPropertyName("has_wifi")]
    public bool HasWifi { get; set; }

    [JsonPropertyName("has_lte")]
    public bool HasLTE { get; set; }

    [JsonPropertyName("release_date")]
    public DateTime? ReleaseDate { get; set; }

    [JsonPropertyName("price")]
    public decimal Price { get; set; }

    [JsonPropertyName("video_card")]
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