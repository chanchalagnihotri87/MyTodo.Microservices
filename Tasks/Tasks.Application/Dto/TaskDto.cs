namespace Tasks.Application.Dto;

public class TaskDto
{
    public int Id { get; set; }
    public string Text { get; set; } = default!;
    public int ObjectiveId { get; set; }
    public bool TwentyPercent { get; set; }
    public bool Completed { get; set; }
    public int Index { get; set; }
}
