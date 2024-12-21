
namespace Objectives.API.Domain
{
    public class Objective
    {
        public int Id { get; set; }
        public string Text { get; set; } = default!;
        public string? Plan { get; set; }
        public int GoalId { get; set; }
        public bool TwentyPercent { get; set; }
        public bool Completed { get; set; }
        public int Index { get; set; }
        public Guid UserId { get; set; }
    }
}
