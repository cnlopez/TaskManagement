using Application.Interfaces;
using Application.ViewModels;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _projectRepository;
        private readonly IMapper _mapper;
        public ProjectService(IProjectRepository projectRepository, IMapper mapper)
        {
            _projectRepository = projectRepository;
            _mapper = mapper;
        }
        public async Task<ProjectViewModel> AddProjectAsync(ProjectViewModel projectViewModel)
        {
            var project = _mapper.Map<Project>(projectViewModel);
            var projectDB = await _projectRepository.AddProjectAsync(project);
            var projectVM = _mapper.Map<ProjectViewModel>(projectDB);
            return projectVM;
        }

        public async Task<bool> DeleteProjectAsync(int id)
        {
            return await _projectRepository.DeleteProjectAsync(id);
        }

        public async Task<ProjectViewModel> GetProjectViewModelByIdAsync(int id)
        {
            var project = await _projectRepository.GetProjectByIdAsync(id);
            var projectVM = _mapper.Map<ProjectViewModel>(project);
            return projectVM;
        }

        public async Task<IEnumerable<ProjectViewModel>> GetProjectViewModelsAsync()
        {
            try
            {
                var projects = await _projectRepository.GetAllProjectsAsync();
                var projectsVM = _mapper.Map<IEnumerable<ProjectViewModel>>(projects);
                return projectsVM;
            }
            catch (Exception ex)
            {
                // aqui se puede usar un sistema de logging como Serilog o NLog
                Console.WriteLine($"Error al obtener los proyectos: {ex.Message}");

                // Lanza una excepción personalizada para que el controlador la maneje
                throw new ApplicationException("Error occurred while getting project list" + ex.Message, ex);
            }
        }

        public async Task<ProjectViewModel> UpdateProjectAsync(int id, ProjectViewModel projectViewModel)
        {
            var project = _mapper.Map<Project>(projectViewModel);
            var projectDB = await _projectRepository.UpdateProjectAsync(id, project);
            var projectVM = _mapper.Map<ProjectViewModel>(projectDB);
            return projectVM;
        }
    }
}
