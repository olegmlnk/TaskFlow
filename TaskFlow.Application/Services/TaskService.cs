using Microsoft.Win32.SafeHandles;
using TaskFlow.Core.Abstractions;
using TaskFlow.Core.Models;

namespace TaskFlow.Application.Services
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _taskRepository;

        public TaskService(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public async Task<List<TaskModel>> GetAllTasks()
        {
            return await _taskRepository.GetAllTasks();
        }

        public async Task<long> GetTaskById(long id)
        {
            return await _taskRepository.GetTaskById(id);
        }

        public async Task<long> CreateAsync(TaskModel task)
        {
            return await _taskRepository.CreateAsync(task);
        }

        public async Task<long> UpdateTask(long id, string title, string description, string status, string priority)
        {
            return await _taskRepository.UpdateTask(id, title, description, status, priority);
        }

        public async Task<long> DeleteAsync(long id)
        {
            return await _taskRepository.DeleteAsync(id);
        }
    }
}
