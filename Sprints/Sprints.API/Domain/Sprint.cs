using Marten.Schema;

namespace Sprints.API.Domain
{
    public class Sprint
    {
        [Identity]
        public int Id { get; set; }
        public string Text { get; set; } = default!;
        public bool Completed { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Guid UserId { get; set; }
    }
}
