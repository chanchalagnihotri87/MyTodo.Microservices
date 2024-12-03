using Problems.API.Domain.Abstraction;

namespace Problems.API.Domain;

public class Problem
{
    public int Id { get; set; }
    public string Text { get; set; } = default!;
    public string Plan { get; set; } = default!;
    public int LifeAreaId { get; set; }
    public bool TwentyPercent { get; set; }
    public bool Completed { get; set; }
    public int Index { get; set; }
    public Guid User_Id { get; set; }
}
