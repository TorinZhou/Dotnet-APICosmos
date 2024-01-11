namespace HelloWorld.Models;

public class Computer
{
    // private string _motherboard;
    public string Motherboard { get; set; }
    public int CPUCores { get; set; }
    public bool HasWifi { get; set; }
    public bool HasLTE { get; set; }
    public DateTime ReleaseDate { get; set; }
    public decimal Price { get; set; }
    public string VideoCard { get; set; }

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
        return $"Motherboard: {Motherboard}\nCPUCores: {CPUCores}\nHasWifi: {HasWifi}\nHasLTE: {HasLTE}\nReleaseDate: {ReleaseDate}\nPrice: {Price}\nVideoCard: {VideoCard}";
    }
}