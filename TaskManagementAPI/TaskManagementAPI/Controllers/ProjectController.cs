using Application.Interfaces;
using Application.ViewModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TaskManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService _projectService;
        public ProjectController(IProjectService projectService)
        {
            _projectService = projectService;
        }
        // GET: api/<ProjectController>
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok(await _projectService.GetProjectViewModelsAsync());
        }

        // GET api/<ProjectController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            return Ok(await _projectService.GetProjectViewModelByIdAsync(id));
        }

        // POST api/<ProjectController>
        [HttpPost]
        public async Task Post([FromBody] ProjectViewModel value)
        {
            await _projectService.AddProjectAsync(value);
        }

        // PUT api/<ProjectController>/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] ProjectViewModel value)
        {
            await _projectService.UpdateProjectAsync(id, value);
        }

        // DELETE api/<ProjectController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _projectService.DeleteProjectAsync(id);
        }
    }
}
