using Application.Interfaces;
using Application.ViewModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TaskManagementAPI.Controllers
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

        // GET: api/<TaskController>
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok(await _taskService.GetTaskViewModelsAsync());
        }

        // GET api/<TaskController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            return Ok(await _taskService.GetTaskViewModelByIdAsync(id));
        }

        // POST api/<TaskController>
        [HttpPost]
        public async Task Post([FromBody] TaskViewModel value)
        {
            await _taskService.AddTaskAsync(value);
        }

        // PUT api/<TaskController>/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] TaskViewModel value)
        {
            await _taskService.UpdateTaskAsync(value);
        }

        // DELETE api/<TaskController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _taskService.DeleteTaskAsync(id);
        }
    }
}
