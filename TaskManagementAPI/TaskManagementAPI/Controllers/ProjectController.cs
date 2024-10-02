using Application.Interfaces;
using Application.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

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
        public async Task<IActionResult> Get()
        {
            //try
            //{
                return Ok(await _projectService.GetProjectViewModelsAsync());
            //}
            //catch (Exception ex)
            //{
            //    // Register error when having logging error system
            //    // _logger.LogError($"Error occurred while getting project list: {ex.Message}");

            //    // Devolver una respuesta genérica de error 500
            //    return StatusCode(500, new { message = "An unexpected error occurred while getting project list." });
            //}
        }

        // GET api/<ProjectController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProject(int id)
        {
            try
            {
                var project = await _projectService.GetProjectViewModelByIdAsync(id);
                if (project == null)
                    return NotFound(new { message = $"The project with ID {id} was not found." });

                return Ok(project);
            }
            catch (Exception)
            {
                return StatusCode(500, new { message = $"An unexpected error occurred while getting the project {id}" });
            }
        }

        // POST api/<ProjectController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ProjectViewModel value)
        {
            try
            {
                var project = await _projectService.AddProjectAsync(value);
                return CreatedAtAction(nameof(GetProject), new { id = project.Id }, project);
            }
            catch (ValidationException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An unexpected error occurred while creating the project." });
            }
        }

        // PUT api/<ProjectController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] ProjectViewModel value)
        {
            try
            {
                var project = await _projectService.UpdateProjectAsync(id, value);
                if (project == null)
                    return NotFound(new { message = $"The project with ID {id} was not found." });
                return Ok(project);
            }
            catch (Exception)
            {
                return StatusCode(500, new { message = "An unexpected error occurred while updating the project." });
            }
        }

        // DELETE api/<ProjectController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var result = await _projectService.DeleteProjectAsync(id);
                if (!result)
                {
                    return NotFound(new { message = $"The project with ID {id} was not found." });
                }
                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(500, new { message = "An unexpected error occurred while deleting the project." });
            }
        }
    }
}
