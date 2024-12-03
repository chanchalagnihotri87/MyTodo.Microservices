using Tasks.Domain.Abstractions;
using Tasks.Domain.Events;

namespace Tasks.Domain.Models;

public class Task 
{
    public int Id { get; set; }
    public string Text { get; set; } = default!;
    public int ObjectiveId { get; set; }
    public bool TwentyPercent { get; set; }
    public bool Completed { get; set; }
    public int Index { get; set; }
    public Guid UserId { get; set; }
    public ICollection<TodoItem> TodoItems { get; set; } = default!;

}
