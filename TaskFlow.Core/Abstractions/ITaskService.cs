using TaskFlow.Core.Models;

namespace TaskFlow.Core.Abstractions
{
    public interface ITaskService
    {
        Task<Guid> CreateAsync(TaskModel task);
        Task<Guid> DeleteAsync(Guid id);
        Task<List<TaskModel>> GetAllTasks();
        Task<Guid> GetTaskById(Guid id);
        Task<Guid> UpdateTask(Guid id, string title, string description, string status, string priority, Guid userId);
    }
}