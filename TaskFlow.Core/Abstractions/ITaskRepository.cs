using TaskFlow.Core.Models;

namespace TaskFlow.Core.Abstractions
{
    public interface ITaskRepository
    {
        Task<List<TaskModel>> GetAllAsync();
        Task<Guid> GetByIdAsync(Guid id);
        Task<Guid> CreateAsync(TaskModel task);
        Task<Guid> UpdateAsync(Guid id, string title, string description, string status, string priority);
        Task<Guid> DeleteAsync(Guid id);
    }
}
