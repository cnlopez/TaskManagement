using Application.Interfaces;
using Application.ViewModels;
using AutoMapper;
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
        public Task AddProjectAsync(ProjectViewModel project)
        {
            throw new NotImplementedException();
        }

        public Task DeleteProjectAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ProjectViewModel> GetProjectViewModelByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ProjectViewModel>> GetProjectViewModelsAsync()
        {
            var projects = await _projectRepository.GetAllProjectsAsync();
            var projectsVM = _mapper.Map< IEnumerable<ProjectViewModel>>(projects);
            return projectsVM;
        }

        public Task UpdateProjectAsync(ProjectViewModel project)
        {
            throw new NotImplementedException();
        }
    }
}
