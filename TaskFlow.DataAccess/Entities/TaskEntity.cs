using TaskFlow.Core.Models;

namespace TaskFlow.DataAccess.Entities
{
    public class TaskEntity
    {
        public long Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public string Priority { get; set; } = string.Empty;
        public long UserId { get; set; }
        public UserEntity? User { get; set; }
    }
}
