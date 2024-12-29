using Application.Interfaces;
using Application.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace TaskManagementAPI.Endpoints
{
    public static class ProjectApi
    {
        public static void MapProjectEndpoints(this WebApplication app)
        {
            //var projectService = app.Services.GetRequiredService<IProjectService>();

            // GET: /project
            app.MapGet("/project", async (IProjectService projectService) =>
            {
                try
                {
                    return Results.Ok(await projectService.GetProjectViewModelsAsync());
                }
                catch
                {
                    return Results.Problem("An unexpected error occurred while getting project list.", statusCode: 500);
                }
            });//.RequireAuthorization(); // Aplica [Authorize]



            // GET: /project/{id}
            app.MapGet("/project/{id:int}", async (IProjectService projectService, int id) =>
            {
                try
                {
                    var project = await projectService.GetProjectViewModelByIdAsync(id);
                    if (project == null)
                        return Results.NotFound(new { message = $"The project with ID {id} was not found." });

                    return Results.Ok(project);
                }
                catch
                {
                    return Results.Problem("An unexpected error occurred while getting the project", statusCode: 500);
                }
            });

            // POST: /project
            app.MapPost("/project", async (IProjectService projectService, [FromBody] ProjectViewModel value) =>
            {
                try
                {
                    var project = await projectService.AddProjectAsync(value);
                    return Results.Created($"/project/{project.Id}", project);
                }
                catch (ValidationException ex)
                {
                    return Results.BadRequest(new { message = ex.Message });
                }
                catch
                {
                    return Results.Problem("An unexpected error occurred while creating the project.", statusCode: 500);
                }
            });

            // PUT: /project/{id}
            app.MapPut("/project/{id:int}", async (IProjectService projectService, int id, [FromBody] ProjectViewModel value) =>
            {
                try
                {
                    var project = await projectService.UpdateProjectAsync(id, value);
                    if (project == null)
                        return Results.NotFound(new { message = $"The project with ID {id} was not found." });

                    return Results.Ok(project);
                }
                catch
                {
                    return Results.Problem("An unexpected error occurred while updating the project.", statusCode: 500);
                }
            });

            // DELETE: /project/{id}
            app.MapDelete("/project/{id:int}", async (IProjectService projectService, int id) =>
            {
                try
                {
                    var result = await projectService.DeleteProjectAsync(id);
                    if (!result)
                        return Results.NotFound(new { message = $"The project with ID {id} was not found." });

                    return Results.NoContent();
                }
                catch
                {
                    return Results.Problem("An unexpected error occurred while deleting the project.", statusCode: 500);
                }
            });
        }
    }
}
