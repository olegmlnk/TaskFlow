using Microsoft.EntityFrameworkCore;
using TaskFlow.Core.Abstractions;
using TaskFlow.Core.Models;
using TaskFlow.DataAccess.Data;
using TaskFlow.DataAccess.Entities;

namespace TaskFlow.DataAccess.Repositories
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

            await _context.Tasks.AddAsync(taskEntity);
            await _context.SaveChangesAsync();

            return task.Id;
        }

        public async Task<Guid> DeleteAsync(Guid id)
        {
            await _context.Tasks
                .Where(t => t.Id == id)
                .ExecuteDeleteAsync();
            
            return id;
        }

        public async Task<List<TaskModel>> GetAllTasks()
        {
            var taskEntities = await _context.Tasks
                .AsNoTracking()
                .ToListAsync();

            var tasks = taskEntities
                .Select(t => TaskModel.Create(t.Id, t.Title, t.Description, t.Status, t.Priority).task)
                .ToList();

            return tasks;
        }

        public async Task<Guid> GetTaskById(Guid id)
        {
            var task = await _context.Tasks.FindAsync(id);

            if (task == null)
                throw new KeyNotFoundException("Task not found");

            return task.Id;
        }

        public async Task<Guid> UpdateTask(Guid id, string title, string description, string status, string priority)
        {
            await _context.Tasks
                .Where(t => t.Id == id)
                .ExecuteUpdateAsync(x => x
                .SetProperty(x => x.Title, x => title)
                .SetProperty(x => x.Description, x => description)
                .SetProperty(x => x.Status, x => status)
                .SetProperty(x => x.Priority, x => priority));

            return id;
        }
    }
}
