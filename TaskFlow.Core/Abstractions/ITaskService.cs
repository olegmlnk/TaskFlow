using TaskFlow.Core.Models;

namespace TaskFlow.Core.Abstractions
{
    public interface ITaskService
    {
        Task<long> CreateAsync(TaskModel task);
        Task<long> DeleteAsync(long id);
        Task<List<TaskModel>> GetAllTasks();
        Task<long> GetTaskById(long id);
        Task<long> UpdateTask(long id, string title, string description, string status, string priority, long userId);
    }
}