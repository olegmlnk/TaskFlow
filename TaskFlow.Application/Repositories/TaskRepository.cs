using TaskFlow.Application.Entities;
using TaskFlow.Core.Abstractions;
using TaskFlow.Core.Models;
using TaskFlow.DataAccess.Data; 

namespace TaskFlow.Application.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly AppDbContext _context;

        public TaskRepository(AppDbContext context) 
        {
            _context = context;
        }

        public async Task<Guid> CreateAsync(TaskModel task)
        {
            var taskEntity = new TaskEntity
            {
                Id = task.Id,
                Title = task.Title,
                Description = task.Description,
                Status = task.Status,
                Priority = task.Priority
            };

            _context.Tasks.Add(taskEntity);
            await _context.SaveChangesAsync();

            return taskEntity.Id;
        }

        public async Task<Guid> DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<TaskModel>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Guid> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<Guid> UpdateAsync(Guid id, string title, string description, string status, string priority)
        {
            throw new NotImplementedException();
        }
    }
}

