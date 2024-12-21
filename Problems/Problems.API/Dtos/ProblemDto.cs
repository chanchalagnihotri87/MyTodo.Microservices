
namespace Problems.API.Dtos;

public class ProblemDto
{
    public int Id { get; set; }
    public string Text { get; set; } = default!;
    public string Plan { get; set; } = default!;
    public int LifeAreaId { get; set; }
    public bool TwentyPercent { get; set; }
    public bool Completed { get; set; }
    public int Index { get; set; }
}
