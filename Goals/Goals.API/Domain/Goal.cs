using Marten.Schema;

namespace Goals.API.Domain
{
    public class Goal
    {
        [Identity]
        public int Id { get; set; }
        public string Text { get; set; } = default!;
        public string Plan { get; set; } = default!;
        public int ProblemId { get; set; }
        public bool TwentyPercent { get; set; }
        public bool Completed { get; set; }
        public int Index { get; set; }
        public Guid UserId { get; set; }
    }
}
