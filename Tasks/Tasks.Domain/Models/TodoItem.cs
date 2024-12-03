using Tasks.Domain.Abstractions;
using Tasks.Domain.Events;

namespace Tasks.Domain.Models;

public class TodoItem : Aggregate
{
    public int Id { get; set; }
    public string Text { get; set; } = default!;
    public int TaskId { get; set; }
    public bool TwentyPercent { get; set; }
    public bool Completed { get; set; }
    public int Index { get; set; }
    public int? SprintId { get; set; }
    public DateTime? Date { get; set; }
    public Guid UserId { get; set; }
    public Task Task { get; set; } = default!;

    public void UpdateCompletedFlag(bool completed)
    {
        this.Completed = completed;

        this.AddDomainEvent(new TodoItemCompletedEvent(this));
    }
}
