using TaskFlow.Core.Models;

namespace TaskFlow.Core.Abstractions
{
    public interface ITaskRepository
    {
        Task<List<TaskModel>> GetAllTasks();
        Task<Guid> GetTaskById(Guid id);
        Task<Guid> CreateAsync(TaskModel task);
        Task<Guid> UpdateTask(Guid id, string title, string description, string status, string priority);
        Task<Guid> DeleteAsync(Guid id);
    }
}
