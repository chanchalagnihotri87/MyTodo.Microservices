namespace LifeArea.API.Models;

public class LifeAreaType
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public string? Vision { get; set; }
    public string? Plan { get; set; }
}
