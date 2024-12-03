using Marten.Schema;

namespace Objectives.API.Domain
{
    public class Objective
    {
        [Identity]
        public int Id { get; set; }
        public string Text { get; set; } = default!;
        public string Plan { get; set; } = default!;
        public int GoalId { get; set; }
        public bool TwentyPercent { get; set; }
        public bool Completed { get; set; }
        public int Index { get; set; }
        public Guid UserId { get; set; }
    }
}
