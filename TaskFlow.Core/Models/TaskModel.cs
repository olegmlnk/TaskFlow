namespace TaskFlow.Core.Models
{
    public class TaskModel
    {
        public const int MAX_TITLE_LENGTH = 255;
        public const int MAX_STATUS_LENGTH = 25;
        public const int MAX_PRIORITY_LENGTH = 25;
        private TaskModel(Guid id, string title, string description, string status, string priority, Guid userId)
        {
            Id = id;
            Title = title;
            Description = description;
            Status = status;
            Priority = priority;
            UserId = userId;
        }

        public Guid Id { get; }
        public string Title { get; } = string.Empty;
        public string Description { get; } = string.Empty;
        public string Status { get; } = string.Empty;
        public string Priority { get; } = string.Empty;
        public Guid UserId { get; }
        public Guid User { get; } 

        public static (TaskModel task, string error) Create(Guid id, string title, string description, string status, string priority, Guid userId)
        {
            var error = string.Empty;

            if (string.IsNullOrEmpty(title) || title.Length > MAX_TITLE_LENGTH)
            {
                Console.WriteLine("Title cannot be empty or longer than 255 symbols");
            }

            if (string.IsNullOrEmpty(status) || status.Length > MAX_STATUS_LENGTH)
            {
                Console.WriteLine("Status cannot be empty or longer than 25 symbols");
            }

            if (string.IsNullOrEmpty(priority) || priority.Length > MAX_PRIORITY_LENGTH)
            {
                Console.WriteLine("Priority cannot be empty or longer than 25 symbols");
            }


            var task = new TaskModel(id, title, description, status, priority, userId);

            return (task, error);
        }
    }
}
