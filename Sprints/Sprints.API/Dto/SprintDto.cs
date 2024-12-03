namespace Sprints.API.Dto;

public class SprintDto
{
    public int Id { get; set; }
    public string Text { get; set; } = default!;
    public bool Completed { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
}
