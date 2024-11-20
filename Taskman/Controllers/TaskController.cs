using Domain.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Interface;

namespace WebAPI.Controllers
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
        // GET: api/tasks
        [HttpGet]
        public ActionResult<List<TaskItem>> GetAllTasks()
        {
            var tasks = _taskService.GetAllTasks();
            return Ok(tasks);
        }

        // GET: api/tasks/5
        [HttpGet("{id}")]
        public ActionResult<TaskItem> GetTaskDetails(int id)
        {
            var task = _taskService.GetDetailsForTask(id);
            if (task == null)
            {
                return NotFound();
            }
            return Ok(task);
        }

        // POST: api/tasks
        [HttpPost]
        public ActionResult CreateNewTask([FromBody] TaskItem task)
        {
            if (task == null)
            {
                return BadRequest("Task cannot be null");
            }

            _taskService.CreateNewTask(task);
            return CreatedAtAction(nameof(GetTaskDetails), new { id = task.Id }, task);
        }

        // PUT: api/tasks/5
        [HttpPut("{id}")]
        public ActionResult UpdateTask(int id, [FromBody] TaskItem task)
        {
            //TODO: Exception handling
            var taskCheck = _taskService.GetDetailsForTask(id);
            if (taskCheck == null)
            {
                return NotFound();
            }

            _taskService.UpdateTask(id, task);
            return NoContent();
        }

        // DELETE: api/tasks/5
        [HttpDelete("{id}")]
        public ActionResult DeleteTask(int id)
        {
            var task = _taskService.GetDetailsForTask(id);
            if (task == null)
            {
                return NotFound();
            }

            _taskService.DeleteTask(id);
            return NoContent();
        }
    }
}
