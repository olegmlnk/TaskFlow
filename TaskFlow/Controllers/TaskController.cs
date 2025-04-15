using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskFlow.API.Contracts;
using TaskFlow.Core.Abstractions;
using TaskFlow.Core.Models;

namespace TaskFlow.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService _taskService;

        public TaskController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        [HttpGet("GetAllTasks")]
        public async Task<ActionResult<List<TaskResponse>>> GetAllTasks()
        {
           var tasks = await _taskService.GetAllTasks();

            var response = tasks.Select(task => new TaskResponse(
                task.Id,
                task.Title,
                task.Description,
                task.Status,
                task.Priority
            ));

            return Ok(response);
        }

        [HttpGet("GetTaskById")]
        public async Task<ActionResult<TaskModel>> GetTaskById(long id)
        {
            var task = await _taskService.GetTaskById(id);
            return Ok(task);
        }

        [HttpPost("CreateTask")]
        public async Task<ActionResult<long>> CreateTask(TaskRequest request)
        {
            var (task, error) = TaskModel.Create(
                long.NewGuid(),
                request.title,
                request.description,
                request.status,
                request.priority
            );

            if(!string.IsNullOrEmpty(error))
            {
                return BadRequest(error);
            }

            var taskId = await _taskService.CreateAsync(task);

            if(taskId == long.Empty)
            {
                return BadRequest("Task was not created");
            }

            return Ok("Task created succesfully");
        }

        [HttpPut("UpdateTask")]
        public async Task<ActionResult<long>> UpdateTask(long id, [FromBody] TaskRequest request)
        {
            var taskId = await _taskService.UpdateTask(id, request.title, request.description, request.status, request.priority);
            return Ok(taskId);
        }

        [HttpDelete("DeleteTask")]
        public async Task<ActionResult<long>> DeleteTask(long id)
        {
            var taskId = await _taskService.DeleteAsync(id);
            return Ok($"Task with ID {taskId} succesfully deleted.");
        }
    }
}
